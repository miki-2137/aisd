using System.CodeDom.Compiler;
using System.Collections.Concurrent;

namespace sorty_miki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] tab = { 1, 2 };
        Random rnd = new Random();
        public void Generuj(int[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = rnd.Next(0, 100);
            }
        }
        public void Swap(int[] tab, int a, int b)
        {
            int temp = tab[a];
            tab[a] = tab[b];
            tab[b] = temp;
        }
        public void BubbleSort(int[] tab)
        {
            for(int i = 0; i < tab.Length - 1; i++)
            {
                for(int j = 0; j < tab.Length - i - 1; j++)
                {
                    if (tab[j] > tab[j + 1])
                    {
                        Swap(tab, j, j + 1);
                    }
                }
            }
        }
        public void CountingSort(int[] tab)
        {
            int max = tab.Max();
            int[] count = new int[max + 1];
            int[] sorted = new int[tab.Length];
            for(int i = 0; i < tab.Length; i++)
            {
                count[tab[i]]++;
            }
            for(int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }
            for(int i = 0; i < tab.Length; i++)
            {
                sorted[count[tab[i]] - 1] = tab[i];
                count[tab[i]]--;
            }
            Array.Copy(sorted, tab, tab.Length);
        }
        public void InsertSort(int[] tab)
        {
            for(int i = 0; i < tab.Length; i++)
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
        public void QuickSort(int[] tab, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(tab, start, end);
                QuickSort(tab, start, pivot - 1);
                QuickSort(tab, pivot + 1, end);
            }
        }
        public int Partition(int[] tab, int start, int end)
        {
            int pivot = tab[end];
            int i = start - 1;
            for (int j = start; j < end; j++)
            {
                if (tab[j] < pivot)
                {
                    i++;
                    Swap(tab, i, j);
                }
            }
            i++;
            Swap(tab, i, end);
            return i;
        }
        public void MergeSort(int[] tab)
        {
            if (tab.Length <= 1) return;

            int mid = tab.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[tab.Length - mid];

            Array.Copy(tab, 0, left, 0, mid);
            Array.Copy(tab, mid, right, 0, tab.Length - mid);

            MergeSort(left);
            MergeSort(right);
            Merge(tab, left, right);
        }
        public void Merge(int[] tab, int[] left, int[] right)
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
        private void button1_Click(object sender, EventArgs e)
        {
            int i = decimal.ToInt32(numericUpDown1.Value);
            int[] tab2 = new int[i];
            Generuj(tab2);
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
                CountingSort(tab);
            }
            if (radioButton3.Checked == true)
            {
                InsertSort(tab);
            }
            if (radioButton4.Checked == true)
            {
                QuickSort(tab, 0, tab.Length - 1);
            }
            if (radioButton5.Checked == true)
            {
                MergeSort(tab);
            }
            textBox2.Text = string.Join(" ", tab);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
