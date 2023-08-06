using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_ll
{
    [Serializable]
    class StudentBooks
    {
        public Students Student;
        public Books Book1;
        public Books Book2;
        public Books Book3;

        public StudentBooks(Students student, Books book1)
        {
            Student = student;
            Book1 = book1;
            Book2 = null;
            Book3 = null;
        }
        public StudentBooks(Students student, Books book1, Books book2)
        {
            Student = student;
            Book1 = book1;
            Book2 = book2;
            Book3 = null;
        }
        public StudentBooks(Students student, Books book1, Books book2, Books book3)
        {
            Student = student;
            Book1 = book1;
            Book2 = book2;
            Book3 = book3;
        }
    }
}
