using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterSkiBaan.Personen;
using WaterSkiBaan.SportUitrusting;

namespace WaterSkiBaan.Sporters
{
    public abstract class Sporter : Person
    {
        public Zwemvest Zwemvest { get; set; }
        public SportArtikel Uitrusting { get; set; }
        public int AantalRonden { get; set; } = 2;
    }
}
