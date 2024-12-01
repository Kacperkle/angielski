using System;
using System.IO;
using System.Windows;

namespace angielski
{
    public partial class Nauka : Window
    {
        public int iloscSlow = 0;
        public int punkty = 0;
        public string porownanie;
        private Random random;
        public Nauka()
        {
            InitializeComponent();
            random = new Random();
            Losowanie();
        }
        private void Wroc(object sender, RoutedEventArgs e)
        {
            if(punkty >= 20)
            {
                MainWindow secondWindow = new MainWindow();
                secondWindow.Show();
                this.Close();
            }
            else
            {
                int a = 20 - punkty;
                MessageBox.Show("Musi jeszcze udzielić " + a + " poprawnych odpowiedzi.");
            }
        }
        public void Losowanie()
        {
            string path = "slowka.txt";
            string[] wiersze = File.ReadAllLines(path);
            int liczba = random.Next(0, wiersze.Length);
            string wylosowanyWiersz = wiersze[liczba];
            string[] slowka = wylosowanyWiersz.Split('-');

            if (slowka.Length == 2)
            {
                string angielski = slowka[0];
                string polski = slowka[1];
                iloscSlow++;
                if (iloscSlow % 2 == 0)
                {
                    textAngielski.Text = angielski;
                    textPolski.Text = "";
                    porownanie = polski;
                }
                else
                {
                    textPolski.Text = polski;
                    textAngielski.Text = "";
                    porownanie = angielski;
                }
            }
            else
            {
                MessageBox.Show("Błędny format wiersza.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Sprawdz(object sender, RoutedEventArgs e)
        {
            string angielski = textAngielski.Text;
            string polski = textPolski.Text;
            if (iloscSlow % 2 == 0)
            {
                if(polski == porownanie)
                {
                    punkty++;
                }
                else
                {
                    MessageBox.Show("Poprawny zapis słowa " + angielski + " to " + porownanie + ".");
                }
            }
            else
            {
                if(angielski == porownanie)
                {
                    punkty++;
                }
                else
                {
                    MessageBox.Show("Poprawny zapis słowa " + polski + " to " + porownanie + ".");
                }
            }
            tPunkty.Text = punkty.ToString();
            tSlowa.Text = iloscSlow.ToString();
            Losowanie();
        }
    }
}
