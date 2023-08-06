using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_ll
{
    [Serializable]
    class Books
    {
        public string NameBook { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }

        public Books(string NBook, string author, string year)
        {
            NameBook = NBook;
            Author = author;
            Year = year;
        }
    }
}
