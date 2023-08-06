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
    /// Логика взаимодействия для Usun_studenta.xaml
    /// </summary>
    public partial class Usun_studenta : Window
    {
        public Usun_studenta()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (name.Text != String.Empty & lastname.Text != String.Empty & NRalbumu.Text != String.Empty)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileRead = new FileStream(@"Students.dat", FileMode.OpenOrCreate);
                FileStream fileSave = new FileStream(@"StudentsTMP.dat", FileMode.OpenOrCreate);
                BinaryReader read = new BinaryReader(fileRead);
                try
                {
                    while (read.PeekChar() >= 0)
                    {
                        Students student = (Students)formatter.Deserialize(fileRead);
                        if (name.Text == student.Name & lastname.Text == student.LastName & NRalbumu.Text == student.NRalbumu) { }
                        else
                        {
                            formatter.Serialize(fileSave, student);
                        }

                    }
                    read.Close();
                    fileRead.Close();
                    fileSave.Close();
                    File.Delete(@"Students.dat");
                    File.Move(@"StudentsTMP.dat", @"Students.dat");
                }
                catch { }
            }
            var Refresh = this.Owner as MainWindow;
            Refresh.Refresh();
            this.Close();
        }
    }
}
