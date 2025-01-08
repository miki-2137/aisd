using System;

public class LongestCommonSubsequence
{
    public static int DlugoscNWP(string s1, string s2)
    {
        int m = s1.Length;
        int n = s2.Length;
        int[,] tab = new int[m + 1, n + 1];

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    tab[i, j] = tab[i - 1, j - 1] + 1;
                }
                else
                {
                    tab[i, j] = Math.Max(tab[i - 1, j], tab[i, j - 1]);
                }
            }
        }

        int index = tab[m, n];
        char[] nwp = new char[index];
        int k = m, l = n;
        while (k > 0 && l > 0)
        {
            if (s1[k - 1] == s2[l - 1])
            {
                nwp[index - 1] = s1[k - 1];
                k--;
                l--;
                index--;
            }
            else if (tab[k - 1, l] > tab[k, l - 1])
            {
                k--;
            }
            else
            {
                l--;
            }
        }

        Console.WriteLine("nwp: " + new string(nwp));
        return tab[m, n];
    }

    public static void Main(string[] args)
    {
        string s1 = "abaabbaaa";
        string s2 = "babab";
        Console.WriteLine("dlugosc nwp: " + DlugoscNWP(s1, s2));
    }
}
