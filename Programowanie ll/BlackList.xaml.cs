using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows;
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
    /// Логика взаимодействия для BlackList.xaml
    /// </summary>
    public partial class BlackList : Window
    {

        public void Refresh()
        {
            Blist.Items.Clear();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(@"BL.dat", FileMode.OpenOrCreate);
            BinaryReader read = new BinaryReader(file);
            string tmp;
            try
            {
                while (read.PeekChar() >= 0)
                {
                    Students student = (Students)formatter.Deserialize(file);
                    tmp = student.Name + "\t";
                    tmp += student.LastName + "\t\t";
                    tmp += student.NRalbumu;
                    Blist.Items.Add(tmp);
                }
            }
            catch
            {
            }
            read.Close();
            file.Close();
        }
        public BlackList()
        {
            InitializeComponent();
            Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != String.Empty & Lastname.Text != String.Empty & NRalbumu.Text != String.Empty)
            {
                Students student = new Students(Name.Text, Lastname.Text, null, NRalbumu.Text);
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = new FileStream(@"BL.dat", FileMode.Append);
                formatter.Serialize(file, student);
                file.Close();
                Refresh();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Name.Text != String.Empty & Lastname.Text != String.Empty & NRalbumu.Text != String.Empty)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileRead = new FileStream(@"BL.dat", FileMode.OpenOrCreate);
                FileStream fileSave = new FileStream(@"BLtmp.dat", FileMode.OpenOrCreate);
                BinaryReader read = new BinaryReader(fileRead);
                try
                {
                    while (read.PeekChar() >= 0)
                    {
                        Students student = (Students)formatter.Deserialize(fileRead);
                        if (Name.Text == student.Name & Lastname.Text == student.LastName & NRalbumu.Text == student.NRalbumu) { }
                        else
                        {
                            formatter.Serialize(fileSave, student);
                        }

                    }
                    read.Close();
                    fileRead.Close();
                    fileSave.Close();
                    File.Delete(@"BL.dat");
                    File.Move(@"BLtmp.dat", @"BL.dat");
                }
                catch { }
            }
            Refresh();
        }
    }
}
