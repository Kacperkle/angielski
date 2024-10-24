using System;
using System.Collections.Generic;
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
using System.IO;

namespace angielski
{
    public partial class Lista : Window
    {
        public Lista()
        {
            InitializeComponent();
            LoadTextFile();
        }

        private void LoadTextFile()
        {
            string filePath = "C:\\Users\\kacpe\\source\\repos\\angielski\\angielski\\slowka.txt";
            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                txtBlockContent.Text = fileContent;
            }
            else
            {
                txtBlockContent.Text = "Plik nie został znaleziony.";
            }
        }
        private void Wroc(object sender, RoutedEventArgs e)
        {
            MainWindow secondWindow = new MainWindow();
            secondWindow.Show();
            this.Close();
        }
    }
}
