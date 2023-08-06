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
    public partial class Dodac_ksiazke : Window
    {
        public Dodac_ksiazke()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(BName.Text != String.Empty & AAuthor.Text != String.Empty & YYear.Text != String.Empty)
            {
                Books book = new Books(BName.Text, AAuthor.Text, YYear.Text);
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = new FileStream(@"Books.dat", FileMode.Append);
                formatter.Serialize(file, book);
                file.Close();
                this.Close();
            }
            var Refresh = this.Owner as MainWindow;
            Refresh.Refresh();
        }
    }
}
