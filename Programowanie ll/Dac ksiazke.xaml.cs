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
    /// Логика взаимодействия для Dac_ksiazke.xaml
    /// </summary>
    public partial class Dac_ksiazke : Window
    {
        public Dac_ksiazke()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(name.Text != String.Empty & lastname.Text != String.Empty & NRalbumu.Text != String.Empty & Bname.Text != String.Empty & author.Text != string.Empty)
            {
                int N = 0;
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileRead = new FileStream(@"Students.dat", FileMode.OpenOrCreate);
                FileStream fileSave = new FileStream(@"StudentsTMP.dat", FileMode.OpenOrCreate);
                BinaryReader read = new BinaryReader(fileRead);
                try
                {
                    while (read.PeekChar() >= 0)
                    {
                        Students student = (Students)formatter.Deserialize(fileRead);
                        if (name.Text == student.Name & lastname.Text == student.LastName & NRalbumu.Text == student.NRalbumu) 
                        {
                            N++;
                            FileStream fileRead2 = new FileStream(@"Books.dat", FileMode.OpenOrCreate);
                            FileStream fileSave2 = new FileStream(@"BooksTMP.dat", FileMode.OpenOrCreate);
                            BinaryReader read2 = new BinaryReader(fileRead2);
                            try
                            {
                                while (read2.PeekChar() >= 0)
                                {
                                    Books book = (Books)formatter.Deserialize(fileRead2);
                                    if (Bname.Text == book.NameBook & author.Text == book.Author) 
                                    {
                                        StudentBooks sb = new StudentBooks(student, book);
                                        FileStream fileSB = new FileStream(@"SB.dat", FileMode.Append);
                                        formatter.Serialize(fileSB, sb);
                                        fileSB.Close();
                                    }
                                    else
                                    {
                                        formatter.Serialize(fileSave2, book);
                                    }

                                }
                                read2.Close();
                                fileRead2.Close();
                                fileSave2.Close();
                                File.Delete(@"Books.dat");
                                File.Move(@"BooksTMP.dat", @"Books.dat");
                            }
                            catch { }
                        }
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

                    if(N == 0)
                    {
                        BinaryFormatter formatter2 = new BinaryFormatter();
                        FileStream ADDbook = new FileStream(@"SB.dat", FileMode.Open);
                        FileStream ADDbook2 = new FileStream(@"SBtmp.dat", FileMode.OpenOrCreate);
                        BinaryReader readBOOK = new BinaryReader(ADDbook);
                        while (readBOOK.PeekChar() >= 0)
                        {
                            StudentBooks studentB = (StudentBooks)formatter2.Deserialize(ADDbook);
                            if (studentB.Student.Name == name.Text & studentB.Student.LastName == lastname.Text & studentB.Student.NRalbumu == NRalbumu.Text)
                            {
                                if (studentB.Book2 == null)
                                {
                                    FileStream fileR = new FileStream(@"Books.dat", FileMode.OpenOrCreate);
                                    FileStream fileS = new FileStream(@"BooksTMP.dat", FileMode.OpenOrCreate);
                                    BinaryReader r2 = new BinaryReader(fileR);
                                    try
                                    {
                                        while (r2.PeekChar() >= 0)
                                        {
                                            Books book = (Books)formatter2.Deserialize(fileR);
                                            if (Bname.Text == book.NameBook & author.Text == book.Author)
                                            {
                                                Students A = studentB.Student;
                                                Books book1 = studentB.Book1;
                                                StudentBooks studentB2 = new StudentBooks(A, book1, book);
                                                formatter2.Serialize(ADDbook2, studentB2);
                                            }
                                            else
                                            {
                                                formatter2.Serialize(fileS, book);
                                            }

                                        }
                                        r2.Close();
                                        fileR.Close();
                                        fileS.Close();
                                        File.Delete(@"Books.dat");
                                        File.Move(@"BooksTMP.dat", @"Books.dat");
                                        N++;
                                    }
                                    catch { }
                                }
                                if (studentB.Book3 == null & N == 0)
                                {
                                    FileStream fileR2 = new FileStream(@"Books.dat", FileMode.OpenOrCreate);
                                    FileStream fileS2 = new FileStream(@"BooksTMP.dat", FileMode.OpenOrCreate);
                                    BinaryReader r3 = new BinaryReader(fileR2);
                                    try
                                    {
                                        while (r3.PeekChar() >= 0)
                                        {
                                            Books book = (Books)formatter2.Deserialize(fileR2);
                                            if (Bname.Text == book.NameBook & author.Text == book.Author)
                                            {
                                                StudentBooks studentB2 = new StudentBooks(studentB.Student, studentB.Book1, studentB.Book2, book);
                                                formatter2.Serialize(ADDbook2, studentB2);
                                            }
                                            else
                                            {
                                                formatter2.Serialize(fileS2, book);
                                            }

                                        }
                                        r3.Close();
                                        fileR2.Close();
                                        fileS2.Close();
                                        File.Delete(@"Books.dat");
                                        File.Move(@"BooksTMP.dat", @"Books.dat");
                                    }
                                    catch { }
                                }
                                if (studentB.Book2 != null & studentB.Book3 != null)
                                {
                                    formatter2.Serialize(ADDbook2, studentB);
                                }

                            }
                            else
                            {
                                formatter2.Serialize(ADDbook2, studentB);
                            }
                        }
                        readBOOK.Close();
                        ADDbook2.Close();
                        ADDbook.Close();
                        File.Delete(@"SB.dat");
                        File.Move(@"SBtmp.dat", @"SB.dat");
                    }
                }
                catch { }
            }
            var Refresh = this.Owner as MainWindow;
            Refresh.Refresh();
            this.Close();
        }
    }
}
