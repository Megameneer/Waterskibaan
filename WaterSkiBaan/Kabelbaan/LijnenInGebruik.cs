using System.Collections.Generic;

namespace WaterSkiBaan.Kabelbaan
{
    public class LijnenInGebruik
    {
        public LinkedList<Lijn> Lijnen { get; set; }
        public Queue<Lijn> LijnenUitgerangeerd { get; set; }

        public LijnenInGebruik()
        {
            Lijnen = new LinkedList<Lijn>();
            LijnenUitgerangeerd = new Queue<Lijn>();
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            lijn.Positie = 0;
            Lijnen.AddFirst(lijn);
        }

        public void StelLijnBuitenGebruik(Lijn lijn)
        {
            Lijnen.Remove(lijn);
            LijnenUitgerangeerd.Enqueue(lijn);
        }
    }
}