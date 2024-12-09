using System;

public class Class1
{
	public Class1()
	{
		int[] tab = { 1, 2 };
		Random rnd = new Random();
		public void Generuj(int[] tab, int i)
		{
			for(int j = 0; j < i; j++)
			{
				tab[j] = rnd.Next(0,100);
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
		public void CountingSort(int[] tab)
		{
			int max = tab.Max();
			int[] count = new int[max + 1];
			for(int i = 0; i < tab.Length; i++)
			{
				count[tab[i]]++;
			}
			int index = 0;
			for(int i = 0; i < count.Length; i++)
			{
				while (count[i] > 0)
				{
                    count[index] = i;
                    index++;
					count[i]--;
                }
			}
		}
		public void InsertSort(int[] tab)
		{
			for(int i = 1; i < tab.Length; i++)
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
	}
}
