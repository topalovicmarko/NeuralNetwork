using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NNmreza
{
    class Sloj
    {
        private Neuron[] sloj;

        public Sloj(int brojNeurona, int brojUlaza, string fja)
        {
            sloj = new Neuron[brojNeurona];

            for(int i = 0;i<sloj.Length;i++)
            {
                sloj[i] = new Neuron(brojUlaza, fja);
            }
        }

        public double[] izracunaj(double[] x)
        {
            double[] y = new double[sloj.Length];

            for (int i = 0; i < sloj.Length; i++)
                y[i] = sloj[i].izracunaj(x);

            return y;
        }

        public void reset()
        {
            for (int i = 0; i < sloj.Length; i++)
                sloj[i].resetNeurona();
        }

        public void stampaj(ListBox listBox)
        {
            listBox.Items.Add("=======================================");
            for(int i = 0;i<sloj.Length;i++)
            {
                listBox.Items.Add($"     >> NEURON {i+1} <<     ");
                sloj[i].stampaj(listBox);
            }
            listBox.Items.Add("=======================================");
        }

        public Neuron getNeuron(int i)
        {
            return sloj[i];
        }

        public int getBrNeurona()
        {
            return sloj.Length;
        }

    }
}
