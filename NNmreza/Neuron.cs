using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NNmreza
{
    class Neuron
    {
        private double[] w;
        private double b;
        private string fja;
        private double y;
        private double delta;

        //----------------------------------------------------

        #region konstruktor

        public Neuron(int brUlaza, string fja)
        {
            w = new double[brUlaza];
            b = 0;
            this.fja = fja;
        }

        #endregion

        //----------------------------------------------------

        #region metode

        public double izracunaj(double[] x)
        {
            y = 0;
            double suma = 0;

            for (int i = 0; i < w.Length; i++)
                suma = suma + x[i] * w[i];

            suma += b;

            if (fja == "STEP")
            {
                if (suma >= 0)
                    y = 1;
                else
                    y = 0;
            }
            else if (fja == "LIN")
            {
                y = suma;
            }
            else if (fja == "SIG")
            {
                y = 1 / (1 + Math.Exp(-suma));
            }
            else if (fja == "TANG") //DODATO
            {
                y = (Math.Exp(suma) - Math.Exp(-suma)) / (Math.Exp(suma) + Math.Exp(-suma));
            }

            return y;
        }

        public double Yprim()
        {
            double yPrim = 0;

            switch(fja)
            {
                case "STEP":
                case "LIN":
                    yPrim = 1;
                    break;
                case "SIG":
                    yPrim = y * (1 - y);
                    break;
            }

            return yPrim;
        }

        public void resetNeurona(int min, int max)
        {
            Thread.Sleep(500);

            Random rnd = new Random();

            b = rnd.NextDouble() * (max - min) + min;

            for (int i = 0; i < w.Length; i++)
                w[i] = rnd.NextDouble() * (max - min) + min;

        }

        public void resetNeurona()
        {
            resetNeurona(-1, 1);
        }

        public void stampaj(ListBox listbox)
        {
            listbox.Items.Add("---------------------------------");
            for (int i = 0; i < w.Length; i++)
                listbox.Items.Add($"w({i + 1}) = {w[i]}");
            listbox.Items.Add($"b = {b}");
            listbox.Items.Add($"Fja = {fja}");
            listbox.Items.Add("---------------------------------");
        }


        #endregion

        //----------------------------------------------------

        #region getSetMetode

        public double getLastY()
        {
            return y;
        }

        public void setDelta(double novaDelta)
        {
            delta = novaDelta;
        }

        public double getDelta()
        {
            return delta;
        }

        public int getBrUlaza()
        {
            return w.Length;
        }

        public double getW(int i)
        {
            return w[i];
        }

        public void setW(int i, double novaW)
        {
            w[i] = novaW;
        }

        public double getB()
        {
            return b;
        }

        public void setB(double noviB)
        {
            b = noviB;
        }

        public string getFja()
        {
            return fja;
        }

        #endregion

        //----------------------------------------------------


    }
}
