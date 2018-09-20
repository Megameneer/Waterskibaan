using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterSkiBaan.Sporters;

namespace WaterSkiBaan.Kabelbaan
{
    public class Lijn
    {
        public Lijn(int positie)
        {
            Positie = positie;
        }

        public int Positie { get; set; }
        public Sporter Sporter { get; set; }
    }
}
