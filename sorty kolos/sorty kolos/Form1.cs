using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sorty_kolos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] tab = { 1, 2, 3 };

        Random rnd = new Random();
        public void Generuj(int[] tab, int i)
        {
            for (int j = 0; j < i; j++)
            {
                tab[j] = rnd.Next(0, 100);
            }
        }

        public void BubbleSort(int[] tab)
        {
            for(int i = 0; i < tab.Length - 1; i++)
            {
                for(int j = 0; j < tab.Length - i - 1; j++)
                {
                    if (tab[j] > tab[j + 1])
                    {
                        int temp = tab[j];
                        tab[j] = tab[j + 1];
                        tab[j + 1] = temp;
                    }
                }
            }
        }
        public void InsertSort(int[] tab)
        {
            for (int i = 1; i < tab.Length; i++)
            {
                int temp = tab[i];
                int j = i - 1;

                while (j >= 0 && tab[j] > temp)
                {
                    tab[j + 1] = tab[j];
                    j--;
                }
                tab[j + 1] = temp;
            }
        }
        public void MergeSort(int[] tab)
        {
            if (tab.Length <= 1) return;

            int mid = tab.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[tab.Length - mid];

            int i = 0;
            int j = 0;

            for(; i < tab.Length; i++)
            {
                if (i < mid)
                {
                    left[i] = tab[i];
                }
                else
                {
                    right[j] = tab[i];
                    j++;
                }
            }
            MergeSort(left);
            MergeSort(right);
            Merge(left, right, tab);
        }
        public void Merge(int[] left, int[] right, int[] tab)
        {
            int i = 0, l = 0, r = 0;
            while (l < left.Length && r < right.Length)
            {
                if (left[l] < right[r])
                {
                    tab[i] = left[l];
                    i++;
                    l++;
                }
                else
                {
                    tab[i] = right[r];
                    i++;
                    r++;
                }
            }
            while (l < left.Length)
            {
                tab[i] = left[l];
                i++;
                l++;
            }
            while (r < right.Length)
            {
                tab[i] = right[r];
                i++;
                r++;
            }
        }
        public void CountingSort(int[] tab)
        {
            int max = tab.Max();
            int[] countTab = new int[max + 1];
            for(int i = 0; i < tab.Length; i++)
            {
                countTab[tab[i]]++;
            }
            int index = 0;
            for (int i = 0; i < countTab.Length; i++)
            {
                while (countTab[i] > 0)
                {
                    tab[index] = i;
                    index++;
                    countTab[i]--;
                }
            }
        }
        public void QuickSort(int[] tab, int start, int end)
        {
            if (end <= start) return;
            int pivot = partition(tab, start, end);
            QuickSort(tab, start, pivot - 1);
            QuickSort(tab, pivot + 1, end);
        }
        public int partition(int[] array, int start, int end)
        {
            int pivot = tab[end];
            int i = start - 1;
            for(int j = start; j < end; j++)
            {
                if (tab[j] < pivot)
                {
                    i++;
                    int temp = tab[i];
                    tab[i] = tab[j];
                    tab[j] = temp;
                }
            }
            i++;
            int temp2 = tab[i];
            tab[i] = tab[end];
            tab[end] = temp2;
            return i;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int i = decimal.ToInt32(numericUpDown1.Value);
            int[] tab2 = new int[i];
            Generuj(tab2, i);
            textBox1.Text = string.Join(" ", tab2);
            tab = tab2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                BubbleSort(tab);
            }
            if (radioButton2.Checked == true)
            {
                InsertSort(tab);
            }
            if (radioButton3.Checked == true)
            {
                MergeSort(tab);
            }
            if (radioButton4.Checked == true)
            {
                CountingSort(tab);
            }
            if (radioButton5.Checked == true)
            {
                QuickSort(tab, 0, tab.Length-1);
            }
            textBox2.Text = string.Join(" ", tab);
        }
    }
}
