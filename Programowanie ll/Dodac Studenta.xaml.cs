using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Programowanie_ll
{
    /// <summary>
    /// Логика взаимодействия для Dodac_Studenta.xaml
    /// </summary>
    public partial class Dodac_Studenta : Window
    {
        public Dodac_Studenta()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (name.Text != String.Empty & lastname.Text != String.Empty & kierunek.Text != string.Empty & NRalbumu.Text != string.Empty)
            {
                var BL = this.Owner as MainWindow;
                if (BL.BL(name.Text, lastname.Text, NRalbumu.Text) != false)
                {
                    Students student = new Students(name.Text, lastname.Text, kierunek.Text, NRalbumu.Text);
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream file = new FileStream(@"Students.dat", FileMode.Append);
                    formatter.Serialize(file, student);
                    file.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error, student in BlackList!");
                }
                var Refresh = this.Owner as MainWindow;
                Refresh.Refresh();
                this.Close();
            }
        }
    }
}
