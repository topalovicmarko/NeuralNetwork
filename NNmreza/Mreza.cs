using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NNmreza
{
    class Mreza
    {
        private Sloj[] mreza;

        public Mreza(int brUlaza, int[] config, string[] fje)
        {
            mreza = new Sloj[config.Length];

            mreza[0] = new Sloj(config[0], brUlaza, fje[0]);

            for (int i = 1; i < mreza.Length; i++)
                mreza[i] = new Sloj(config[i], config[i - 1], fje[i]);

        }

        public double[] izracunaj(double[] x)
        {
            double[] y = mreza[0].izracunaj(x);

            for (int i = 1; i < mreza.Length; i++)
                y = mreza[i].izracunaj(y);

            return y;
        }

        public void stampaj(ListBox listBox)
        {
            listBox.Items.Add($"***************************************");
            for(int i =0;i<mreza.Length;i++)
            {
                listBox.Items.Add($"    >> SLOJ {i + 1} <<    ");
                mreza[i].stampaj(listBox);
            }
            listBox.Items.Add($"***************************************");
        }

        public void reset()
        {
            for(int i = 0; i < mreza.Length; i++)
            {
                mreza[i].reset();
            }
        }

        public Sloj getSloj(int i)
        {
            return mreza[i];
        }

        public int getBrSlojeva()
        {
            return mreza.Length;
        }


    }
}
