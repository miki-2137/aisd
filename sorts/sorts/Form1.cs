using System;
using System.Linq;

namespace sorts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] tab = { 9, 1, 8, 2, 7, 3, 6, 5, 4 };
        public int[] BubbleSort(int[] tab)
        {
            bool a = false;

            while (a == false)
            {
                a = true;
                for (int i = 0; i < tab.Length - 1; i++)
                {
                    if (tab[i] > tab[i + 1])
                    {
                        int temp = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = temp;
                        a = false;
                    }
                }
            }
            return tab;
        }
        public int[] InsertSort(int[] tab)
        {
            for (int i = 1; i < tab.Length; i++)
            {
                int temp = tab[i];
                int j = i - 1;

                while (j >= 0 && tab[j] > temp)
                {
                    tab[j+1] = tab[j];
                    j--;
                }
                tab[j + 1] = temp;
            }
            return tab;
        }
        public int[] MergeSort(int[] tab)
        {
            if (tab.Length <= 1)
            {
                return tab;
            }

            int mid = tab.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[tab.Length - mid];

            Array.Copy(tab, 0, left, 0, mid);

            Array.Copy(tab, mid, right, 0, tab.Length - mid);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        public int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    result[resultIndex++] = left[leftIndex++];
                }
                else
                {
                    result[resultIndex++] = right[rightIndex++];
                }
            }

            while (leftIndex < left.Length)
            {
                result[resultIndex++] = left[leftIndex++];
            }

            while (rightIndex < right.Length)
            {
                result[resultIndex++] = right[rightIndex++];
            }

            return result;
        }
        public int[] QuickSort(int[] tab)
        {
            if (tab.Length <= 1)
            {
                return tab;
            }
            int pivot = tab[tab.Length / 2];
            int[] mniej = tab.Where(x => x < pivot).ToArray();
            int[] equal = tab.Where(x => x == pivot).ToArray();
            int[] wiecej = tab.Where(x => x > pivot).ToArray();
            return QuickSort(mniej).Concat(equal).Concat(QuickSort(wiecej)).ToArray();
        }
        public int[] CountingSort(int[] tab)
        {
            if (tab.Length == 0)
            {
                return tab;
            }

            int maxWar = tab[0];
            for (int i = 1; i < tab.Length; i++)
            {
                if (tab[i] > maxWar)
                {
                    maxWar = tab[i];
                }
            }

            int[] count = new int[maxWar + 1];

            for (int i = 0; i < tab.Length; i++)
            {
                count[tab[i]]++;
            }

            int index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                while (count[i] > 0)
                {
                    tab[index++] = i;
                    count[i]--;
                }
            }

            return tab;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) 
            {
                BubbleSort(tab);
            }
            if (radioButton2.Checked == true) 
            {
                InsertSort(tab);
            }
            if(radioButton3.Checked == true)
            {
                tab = MergeSort(tab);
            }
            if(radioButton4.Checked == true)
            {
                CountingSort(tab);
            }
            if(radioButton5.Checked == true)
            {
                tab = QuickSort(tab);
            }
            string wynik = string.Join(" ", tab);
            MessageBox.Show(wynik);
        }
    }
}