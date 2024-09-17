using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNmreza
{
    class Obuka
    {
        //konstanta obuke
        private double ni;
        //maksimalna greska
        private double maxErr;
        //maksimalni broj iteracija
        private int maxIt;

        private double sumErr;
        private int it;

        public Obuka(double ni, double maxErr, int maxIt)
        {
            this.ni = ni;
            this.maxErr = maxErr;
            this.maxIt = maxIt;
        }

        public bool obuci(Neuron n, double[][] ulazi, double[] izlazi)
        {
            it = 0;
            sumErr = 0;

            n.resetNeurona();

            do
            {
                it++;
                sumErr = 0;

                for(int i = 0;i < ulazi.Length; i++)
                {
                    double[] x = ulazi[i];
                    double yZel = izlazi[i];

                    //1.izracuna izlaz neurona
                    n.izracunaj(x);

                    //2. delta neurona
                    double tErr = yZel - n.getLastY();
                    double delta = tErr * n.Yprim();
                    sumErr += (tErr * tErr) / 2;

                    //3. podesavanje w i b
                    for(int j = 0; j < n.getBrUlaza(); j++)
                    {
                        double novaW = n.getW(j) + ni * delta * x[j];
                        n.setW(j, novaW);
                    }

                    double noviB = n.getB() + ni * delta;
                    n.setB(noviB);
                }
            } while (it < maxIt && sumErr > maxErr);

            return sumErr <= maxErr;
        }

        public bool obuci(Mreza m, double[][] x, double[][] y) 
        {
            it = 0;

            m.reset();

            do
            {
                it++;
                sumErr = 0;

                for(int i = 0; i < x.Length; i++)
                {
                    //#################################################################
                    //1. izracunaj izlaze svih neurona
                    //TODO - dodati prvu tacku obuke neurona
                    ////START
                    m.izracunaj(x[i]);
                    ////END
                    //#################################################################

                    //2. racunanje delta svih neurona
                    for (int s = m.getBrSlojeva() - 1; s >= 0; s--)
                    {
                        Sloj sloj = m.getSloj(s);

                        if(s == m.getBrSlojeva() - 1)
                        {
                            //#################################################################
                            //u pitanju je izlazni sloj
                            //TODO - dodati
                            //START
                            for(int n = 0;n < sloj.getBrNeurona();n++)
                            {
                                Neuron neuron = sloj.getNeuron(n);
                                double yZelj = y[i][n];

                                double err = yZelj - neuron.getLastY();
                                double delta = err * neuron.Yprim();
                                neuron.setDelta(delta);
                                sumErr += (err * err) / 2;
                            }
                            //END
                            //#################################################################
                        }
                        else
                        {
                            //u pitanju su ostali slojevi
                            for(int n = 0; n < sloj.getBrNeurona(); n++)
                            {
                                Neuron neuron = sloj.getNeuron(n);

                                Sloj slojIspred = m.getSloj(s + 1);
                                double sumDelta = 0;
                                for(int t = 0; t<slojIspred.getBrNeurona();t++)
                                {
                                    Neuron neuronIspred = slojIspred.getNeuron(t);

                                    sumDelta += neuronIspred.getDelta() * neuronIspred.getW(n);
                                }

                                double delta = sumDelta * neuron.Yprim();
                                neuron.setDelta(delta);

                            }
                        }
                    }

                    //3. podesavanje tezina i bijasa
                    for(int s = 0; s < m.getBrSlojeva(); s++)
                    {
                        Sloj sloj = m.getSloj(s);

                        if(s == 0)
                        {
                            //#################################################################
                            //ulazni sloj
                            //TODO - dodati podesavanje tezina i bijasa za prvi sloj
                            ////START
                            for (int n = 0; n < sloj.getBrNeurona(); n++)
                            {
                                Neuron neuron = sloj.getNeuron(n);

                                //podesavanje tezina neurona
                                for (int t = 0; t < neuron.getBrUlaza(); t++)
                                {
                                    double novaW = neuron.getW(t) + ni * neuron.getDelta() * x[i][t];
                                    neuron.setW(t, novaW);
                                }

                                //podesavanje bijasa
                                double noviB = neuron.getB() + ni * neuron.getDelta();
                                neuron.setB(noviB);
                            }
                            ////END
                            //#################################################################
                        }
                        else
                        {
                            //ostali slojevi
                            for(int n = 0; n < sloj.getBrNeurona(); n++)
                            {
                                Neuron neuron = sloj.getNeuron(n);

                                Sloj slojIza = m.getSloj(s - 1);

                                //podesavanje tezina
                                for(int t = 0; t < neuron.getBrUlaza(); t++)
                                {
                                    double novaW = neuron.getW(t) + ni * neuron.getDelta() * slojIza.getNeuron(t).getLastY();
                                    neuron.setW(t, novaW);
                                }

                                //podesavanje bijasa
                                double noviB = neuron.getB() + ni * neuron.getDelta();
                                neuron.setB(noviB);
                            }
                        }
                    }
                }
            } while (it < maxIt && sumErr > maxErr);

            return sumErr <= maxErr;
        }

        public double testMreze(Mreza m, double[][] testX, double[][] testY, double odstupanje)
        {
            double pogodak = 0;
            double brojTestnihPodataka = 0;

            for(int i = 0; i < testX.Length; i++)
            {
                m.izracunaj(testX[i]);

                for(int n = 0; n < m.getSloj(m.getBrSlojeva()-1).getBrNeurona(); n++)
                {
                    brojTestnihPodataka++;
                    double izlazN = m.getSloj(m.getBrSlojeva() - 1).getNeuron(n).getLastY();

                    if (izlazN >= (testY[i][n] - odstupanje) && izlazN <= (testY[i][n] + odstupanje))
                    {
                        pogodak++;
                    }
                }
            }

            return (pogodak*100)/brojTestnihPodataka;
        }
        


        public int getBrIteracija()
        {
            return it;
        }

        public double getErr()
        {
            return sumErr;
        }

    }
}
