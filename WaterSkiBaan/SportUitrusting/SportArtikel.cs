using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterSkiBaan.SportUitrusting
{
    public enum SportUitrustingType { skies, wakeboard, zwemvest};

    public class SportArtikel
    {
        public int ID { get; }

        public SportArtikel(int id)
        {
            ID = id;
        }
    }
}
