using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterSkiBaan.Personen
{
    public abstract class Person
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string HeleNaam
        {
            get
            {
                return Voornaam + " " + Achternaam;
            }
        }
    }
}
