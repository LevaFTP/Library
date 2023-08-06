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
    public partial class Zwrot : Window
    {
        public Zwrot()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Bname.Text != String.Empty & Author.Text != String.Empty)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileRead = new FileStream(@"SB.dat", FileMode.Open);
                FileStream fileSave = new FileStream(@"SBtmp.dat", FileMode.OpenOrCreate);
                BinaryReader read = new BinaryReader(fileRead);
                while(read.PeekChar() >= 0)
                {
                    StudentBooks SB = (StudentBooks)formatter.Deserialize(fileRead);
                    Books tmpBook1 = SB.Book1;
                    Books tmpBook2 = SB.Book2;
                    Books tmpBook3 = SB.Book3;
                    Students student = SB.Student;
                    if ((tmpBook1.NameBook == Bname.Text & tmpBook1.Author == Author.Text) || (tmpBook2.NameBook == Bname.Text & tmpBook2.Author == Author.Text) || (tmpBook3.NameBook == Bname.Text & tmpBook3.Author == Author.Text))
                    {
                        if (SB.Book3 != null & SB.Book2 != null & SB.Book1 != null)
                        {
                            if(tmpBook1.NameBook == Bname.Text)
                            {
                                StudentBooks tmp = new StudentBooks(student, tmpBook2, tmpBook3);
                                formatter.Serialize(fileSave, tmp);

                                FileStream fileBOOK = new FileStream(@"Books.dat", FileMode.Append);
                                formatter.Serialize(fileBOOK, tmpBook1);
                                fileBOOK.Close();
                            }
                            if(tmpBook2.NameBook == Bname.Text)
                            {
                                StudentBooks tmp = new StudentBooks(student, tmpBook1, tmpBook3);
                                formatter.Serialize(fileSave, tmp);

                                FileStream fileBOOK = new FileStream(@"Books.dat", FileMode.Append);
                                formatter.Serialize(fileBOOK, tmpBook2);
                                fileBOOK.Close();
                            }
                            if(tmpBook3.NameBook == Bname.Text)
                            {
                                StudentBooks tmp = new StudentBooks(student, tmpBook1, tmpBook2);
                                formatter.Serialize(fileSave, tmp);

                                FileStream fileBOOK = new FileStream(@"Books.dat", FileMode.Append);
                                formatter.Serialize(fileBOOK, tmpBook3);
                                fileBOOK.Close();
                            }
                        }
                        if (SB.Book3 == null & SB.Book2 != null & SB.Book1 != null)
                        {
                            if(tmpBook2.NameBook == Bname.Text)
                            {
                                StudentBooks tmp = new StudentBooks(student, tmpBook1);
                                formatter.Serialize(fileSave, tmp);

                                FileStream fileBOOK = new FileStream(@"Books.dat", FileMode.Append);
                                formatter.Serialize(fileBOOK, tmpBook2);
                                fileBOOK.Close();
                            }
                            if (tmpBook1.NameBook == Bname.Text)
                            {
                                StudentBooks tmp = new StudentBooks(student, tmpBook2);
                                formatter.Serialize(fileSave, tmp);

                                FileStream fileBOOK = new FileStream(@"Books.dat", FileMode.Append);
                                formatter.Serialize(fileBOOK, tmpBook1);
                                fileBOOK.Close();
                            }
                        }
                        if (SB.Book2 == null & SB.Book3 == null)
                        {
                            FileStream fileSTUD = new FileStream(@"Students.dat", FileMode.Append);
                            formatter.Serialize(fileSTUD, student);
                            fileSTUD.Close();
                            FileStream fileBOOK = new FileStream(@"Books.dat", FileMode.Append);
                            formatter.Serialize(fileBOOK, tmpBook1);
                            fileBOOK.Close();
                        }
                    }
                    else
                    {
                        formatter.Serialize(fileSave, SB);
                    }
                    
                }

                read.Close();
                fileSave.Close();
                fileRead.Close();
                File.Delete(@"SB.dat");
                File.Move(@"SBtmp.dat", @"SB.dat");
            }
            var Refresh = this.Owner as MainWindow;
            Refresh.Refresh();
            this.Close();
        }
    }
}
