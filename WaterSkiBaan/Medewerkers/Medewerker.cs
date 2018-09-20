using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterSkiBaan.Personen;

namespace WaterSkiBaan.Medewerkers
{
    public abstract class Medewerker : Person
    {
        public int ID { get; set; }
    }
}
