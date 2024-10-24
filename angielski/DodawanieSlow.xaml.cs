using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace angielski
{
    public partial class DodawanieSlow : Window
    {
        public DodawanieSlow()
        {
            InitializeComponent();
        }
        private void Wroc(object sender, RoutedEventArgs e)
        {
            MainWindow secondWindow = new MainWindow();
            secondWindow.Show();
            this.Close();
        }
        private void Dodaj(object sender, RoutedEventArgs e)
        {
            string path = "C:\\Users\\kacpe\\source\\repos\\angielski\\angielski\\slowka.txt";
            string angielski = textAngielski.Text;
            string polski = textPolski.Text;
            string zapis = angielski + "-" + polski;

            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(zapis);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania pliku: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}