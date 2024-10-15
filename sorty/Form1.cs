using System;
using System.Diagnostics;
namespace sorty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string CreateString(int[] tab)
        {
            string Napis = "";
            for (int i = 0; i < tab.Length; i++)
            {
                Napis = Napis + tab[i] + ", ";
            }
            return Napis;
        }

        public void GenerateArray(int[] tab, int i)
        {
            for (int j = 0; j < i; j++)
            {
                tab[j] = rnd.Next(0, 100);
            }
        }

        int[] tab = { 37, 12, 27, 51, 64, 10, 15, 73, 87 };
        Random rnd = new Random();

        private void button2_Click(object sender, EventArgs e)
        {
            GenerateArray(tab, tab.Length);
            label3.Text = CreateString(tab);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string wynik;
            label3.Text = CreateString(tab);

            Stopwatch tim = new Stopwatch();
            switch (comboBox1.SelectedItem.ToString())
            {
                case "bubble":
                    tim.Start();
                    tab = BubbleSort(tab);
                    tim.Stop();
                    break;
                case "insert":
                    tim.Start();
                    tab = InsertSort(tab);
                    tim.Stop();
                    break;
                case "merge":
                    tim.Start();
                    tab = MergeSort(tab);
                    tim.Stop();
                    break;
                case "count":
                    tim.Start();
                    tab = CountingSort(tab);
                    tim.Stop();
                    break;
                case "quick":
                    tim.Start();
                    tab = QuickSort(tab);
                    tim.Stop();
                    break;
            }
            wynik = TabToString(tab);
            TimeSpan stime = tim.Elapsed;
            label1.Text = "Posortowana tabela: " + wynik;
            label2.Text = "Czas sortowania: " + stime.TotalMilliseconds.ToString() + " ms";

        }

        int[] BubbleSort(int[] tab)
        {
            bool a = false;
            while (!a)
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

        int[] InsertSort(int[] tab)
        {
            List<int> tab2 = new List<int> { tab[0] };
            for (int i = 1; i < tab.Length; i++)
            {
                int j = 0;
                int cur = tab[i];
                while (j < tab2.Count && tab2[j] < cur)
                {
                    j++;
                }

                tab2.Insert(j, cur);
            }
            int[] tab3 = tab2.ToArray();
            return tab3;

        }

        int[] MergeSort(int[] tab)
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

        int[] Merge(int[] left, int[] right)
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

        int[] CountingSort(int[] array)
        {
            if (array.Length == 0)
            {
                return array;
            }

            int maxWar = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxWar)
                {
                    maxWar = array[i];
                }
            }

            int[] count = new int[maxWar + 1];

            for (int i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
            }

            int index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                while (count[i] > 0)
                {
                    array[index++] = i;
                    count[i]--;
                }
            }

            return array;
        }

        int[] QuickSort(int[] tab)
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

        string TabToString(int[] tab)
        {
            string tts = string.Join(" ", tab);
            return tts;
        }
    }
}
