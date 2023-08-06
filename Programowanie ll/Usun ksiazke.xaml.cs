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
    /// Логика взаимодействия для Usun_ksiazke.xaml
    /// </summary>
    public partial class Usun_ksiazke : Window
    {
        public Usun_ksiazke()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(BName.Text != String.Empty & AAuthor.Text != string.Empty)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileRead = new FileStream(@"Books.dat", FileMode.OpenOrCreate);
                FileStream fileSave = new FileStream(@"BooksTMP.dat", FileMode.OpenOrCreate);
                BinaryReader read = new BinaryReader(fileRead);
                try
                {
                    while (read.PeekChar() >= 0)
                    {
                        Books book = (Books)formatter.Deserialize(fileRead);
                        if(BName.Text == book.NameBook & AAuthor.Text == book.Author) { }
                        else
                        {
                            formatter.Serialize(fileSave, book);
                        }

                    }
                    read.Close();
                    fileRead.Close();
                    fileSave.Close();
                    File.Delete(@"Books.dat");
                    File.Move(@"BooksTMP.dat", @"Books.dat");
                }
                catch{}
            }
            var Refresh = this.Owner as MainWindow;
            Refresh.Refresh();
            this.Close();
        }
    }
}
