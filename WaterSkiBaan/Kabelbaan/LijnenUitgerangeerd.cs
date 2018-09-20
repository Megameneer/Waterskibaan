using System.Collections.Generic;

namespace WaterSkiBaan.Kabelbaan
{
    public class LijnenUitgerangeerd
    {
        public List<Lijn> Lijnen = new List<Lijn>();

        public LijnenUitgerangeerd()
        {
            Lijnen.Add(new Lijn(2));
            Lijnen.Add(new Lijn(3));
            Lijnen.Add(new Lijn(4));
            Lijnen.Add(new Lijn(5));
            Lijnen.Add(new Lijn(6));
            Lijnen.Add(new Lijn(7));
            Lijnen.Add(new Lijn(8));
            Lijnen.Add(new Lijn(9));
            Lijnen.Add(new Lijn(10));
            Lijnen.Add(new Lijn(11));

        }
    }
}