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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization;

namespace Programowanie_ll
{
    public partial class MainWindow : Window
    {
        public void Refresh()
        {
            List2.Items.Clear();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(@"Books.dat", FileMode.OpenOrCreate);
            BinaryReader read = new BinaryReader(file);
            string tmp;
            try
            {
                while(read.PeekChar() >= 0)
                { 
                    Books book = (Books)formatter.Deserialize(file);
                    tmp = book.NameBook + "\t";
                    tmp += book.Author + "\t";
                    tmp += book.Year;
                    List2.Items.Add(tmp);
                }
            }
            catch
            {
            }
            read.Close();
            file.Close();

            List1.Items.Clear();
            FileStream file1 = new FileStream(@"SB.dat", FileMode.OpenOrCreate);
            BinaryReader read1 = new BinaryReader(file1);
            try
            {
                while (read1.PeekChar() >= 0)
                {
                    StudentBooks sb = (StudentBooks)formatter.Deserialize(file1);
                    tmp = sb.Student.Name + " ";
                    tmp += sb.Student.LastName + "\t";
                    tmp += sb.Student.NRalbumu + " :";
                    List1.Items.Add(tmp);
                    tmp = sb.Book1.NameBook + "\t";
                    tmp += sb.Book1.Author + "\t";
                    tmp += sb.Book1.Year;
                    List1.Items.Add(tmp);
                    if(sb.Book2 != null)
                    {
                        tmp = sb.Book2.NameBook + "\t";
                        tmp += sb.Book2.Author + "\t";
                        tmp += sb.Book2.Year;
                        List1.Items.Add(tmp);
                    }
                    if(sb.Book3 != null)
                    {
                        tmp = sb.Book3.NameBook + "\t";
                        tmp += sb.Book3.Author + "\t";
                        tmp += sb.Book3.Year;
                        List1.Items.Add(tmp);
                    }
                }
            }
            catch
            {
            }
            read1.Close();
            file1.Close();

            List3.Items.Clear();
            FileStream file3 = new FileStream(@"Students.dat", FileMode.OpenOrCreate);
            BinaryReader read3 = new BinaryReader(file3);
            try
            {
                while (read3.PeekChar() >= 0)
                {
                    Students student = (Students)formatter.Deserialize(file3);
                    tmp = student.Name + " ";
                    tmp += student.LastName + "   ";
                    tmp += student.Kierunek + "   ";
                    tmp += student.NRalbumu;
                    List3.Items.Add(tmp);
                }
            }
            catch {}
            read3.Close();
            file3.Close();
        }
        public bool BL(string name, string lname, string nralbumu)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileRead = new FileStream(@"BL.dat", FileMode.OpenOrCreate);
            BinaryReader read = new BinaryReader(fileRead);
            int N = 0;
            try
            {
                while (read.PeekChar() >= 0)
                {
                    Students student = (Students)formatter.Deserialize(fileRead);
                    if (name == student.Name & lname == student.LastName & nralbumu == student.NRalbumu)
                    {
                        read.Close();
                        fileRead.Close();
                        return false;
                    }
                    else
                    {
                        N++;
                    }
                }
                if(N >= 0)
                {
                    read.Close();
                    fileRead.Close();
                    return true;
                }
                read.Close();
                fileRead.Close();
                return true;
            }
            catch { return true; }
        }
        private void Zwrot(object sender, RoutedEventArgs e)
        {
            Zwrot zwrot = new Zwrot();
            zwrot.Owner = this;
            zwrot.Show();
        }
        private void Dac_ksiazke(object sender, RoutedEventArgs e)
        {
            Dac_ksiazke ksiazke = new Dac_ksiazke();
            ksiazke.Owner = this;
            ksiazke.Show();
        }
        private void Usun_ksiazke(object sender, RoutedEventArgs e)
        {
            Usun_ksiazke DELLksizke = new Usun_ksiazke();
            DELLksizke.Owner = this;
            DELLksizke.Show();
        }
        private void Dodac_ksizke(object sender, RoutedEventArgs e)
        {
            Dodac_ksiazke ADDksizke = new Dodac_ksiazke();
            ADDksizke.Owner = this;
            ADDksizke.Show();
        }
        private void Dodac_studenta(object sender, RoutedEventArgs e)
        {
            Dodac_Studenta ADDstudent = new Dodac_Studenta();
            ADDstudent.Owner = this;
            ADDstudent.Show();
        }
        private void Usun_studenta(object sender, RoutedEventArgs e)
        {
            Usun_studenta DELLstudent = new Usun_studenta();
            DELLstudent.Owner = this;
            DELLstudent.Show();
        }
        private void Open_BlackList(object sender, RoutedEventArgs e)
        {
            BlackList list = new BlackList();
            list.Show();
        }
        public MainWindow()
        {
            InitializeComponent();
            Refresh();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void List2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
        }
    }
}
