using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NNmreza
{
    public partial class Form1 : Form
    {
        Mreza mreza;
        Obuka obuka;
        double[][] ulazi;
        double[][] izlazi;
        double[][] testUlazi;
        double[][] testIzlazi;


        public Form1()
        {
            InitializeComponent();

            NapraviUlazeIzlaze();
            Init_mreze();

            bool obukauspesna = obuka.obuci(mreza, ulazi, izlazi);
            
            if (obukauspesna)
            {
                prikazMreze.Items.Add("Obucavanje mreze je uspesno!");
            }
            else
            {
                prikazMreze.Items.Add("Obucavanje mreze nije uspesno!");
            }

            prikazMreze.Items.Add("Parametri obuke su: ");
            prikazMreze.Items.Add("Br.iteracija: " + obuka.getBrIteracija());
            prikazMreze.Items.Add("Greska: " + obuka.getErr());

            if (obukauspesna)
            {
                prikazMreze.Items.Add("Testiranje mreze je u procentima: " + obuka.testMreze(mreza, testUlazi, testIzlazi, 0.03) + "%");
            }

            mreza.stampaj(prikazMreze);
            
        }
        public void Init_mreze()
        {
            mreza = new Mreza(4, new int[] { 4, 1 }, new string[] { "SIG", "STEP" });
            obuka = new Obuka(0.09, 0.01, 1000);
        }
        public void NapraviUlazeIzlaze()
        {
            ulazi = new double[][]
            {
                new double[] {1, 0.85, 0.85, 0},
                new double[] {1, 0.80, 0.90, 1},
                new double[] {0.5, 0.83, 0.86, 0},
                new double[] {0, 0.70, 0.96, 0},
                new double[] {0, 0.68, 0.80, 0},
                new double[] {0, 0.65, 0.70, 1},
                new double[] {0.5, 0.64, 0.65, 1},
                new double[] {1, 0.72, 0.95, 0},
                new double[] {1, 0.69, 0.70, 0},
                new double[] {0, 0.75, 0.80, 0},
                new double[] {1, 0.75, 0.70, 1}
            };
            izlazi = new double[][]
            {
                new double[] {0},
                new double[] {0},
                new double[] {1},
                new double[] {1},
                new double[] {1},
                new double[] {0},
                new double[] {1},
                new double[] {0},
                new double[] {1},
                new double[] {1},
                new double[] {1}
            };
            testUlazi = new double[][]
            {
                new double[] {0.5, 0.72, 0.90, 1},
                new double[] {0.5, 0.81, 0.75, 0},
                new double[] {0, 0.71, 0.91, 1}
            };
            testIzlazi = new double[][]
            {
                new double[] {1},
                new double[] {1},
                new double[] {0}
            };
        }

    }
}