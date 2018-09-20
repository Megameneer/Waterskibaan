using System.Collections.Generic;
using System.Text;
using WaterSkiBaan.SportOpslag;
using WaterSkiBaan.SportUitrusting;

namespace WaterSkiBaan.SportOpslag
{
    public class ZwemvestOpslag : IOpslag
    {
        private Stack<Zwemvest> _opslag { get; set; } = new Stack<Zwemvest>();

        public void Afgeven(SportArtikel sportartikel)
        {
            var zwemvest = (Zwemvest)sportartikel;
            _opslag.Push(zwemvest);
        }

        public Zwemvest PakZwemvest()
        {
            return _opslag.Pop();
        }

        public override string ToString()
        {
            var opslagArray =_opslag.ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < opslagArray.Length; i++)
            {
                sb.Append("* ");
            }
            return $"({opslagArray.Length.ToString()}) {sb.ToString()}";
        }
    }
}