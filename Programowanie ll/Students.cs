using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_ll
{
    [Serializable]
    class Students
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Kierunek { get; set; }
        public string NRalbumu { get; set; }

        public Students(string name, string lname, string kierunek, string nralbumu)
        {
            Name = name;
            LastName = lname;
            Kierunek = kierunek;
            NRalbumu = nralbumu;
        }
    }
}
