namespace bubble
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] tab;
            tab = new int[] { 2, 3, 1, 8, 7 };
            bool a = false;

            while (a == false) {
                a = true;
                for (int i = 0; i < tab.Length - 1; i++) {
                    if (tab[i] > tab[i + 1]) {
                        int temp = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = temp;
                        a = false;
                    }
                }
            }
            string wynik = string.Join(" ", tab);
            MessageBox.Show(wynik);
        }
    }
}
