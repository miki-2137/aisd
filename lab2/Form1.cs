using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var posortowana = InsertSort(tab);
            var wynik = TabToString(posortowana);
            TextBox.Text = wynik;

            int[] InsertSort(int[] tab)
            {

            }

            string TabToString(int[] tab,int len)
            {

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            void SCAL(int[] T, int p, int q, int r)
            {

            }

            void MS(int[] T, int p, int r)
            {
                if (p < r)
                {
                    int q = (p + r) / 2;
                    MS(T, p, q);
                    MS(T, q + 1, r);
                    SCAL(T, p, q, r);
                }
            }
        }
    }
}
