using System.Collections.Generic;
using WaterSkiBaan.SportOpslag;

namespace WaterSkiBaan.SportUitrusting
{
    public class SkieOpslag : IOpslag
    {
        private Stack<Skies> _opslag;

        public SkieOpslag()
        {
            _opslag = new Stack<Skies>();
        }

        public void Afgeven(SportArtikel artikel)
        {
            if (artikel is Skies skies)
            {
                _opslag.Push(skies);
            }
        }

        public Skies PakSkies() => _opslag.Pop();
    }
}