using System.Collections.Generic;
using System.Linq;

namespace WaterSkiBaan.Kabelbaan
{
    public class LijnenInGebruik
    {
        public LinkedList<Lijn> Lijnen { get; set; }
        public LijnenVoorraad LijnenVoorraad { get; set; }
//        public Queue<Lijn> LijnenUitgerangeerd { get; set; }

        public LijnenInGebruik()
        {
            Lijnen = new LinkedList<Lijn>();
//            LijnenUitgerangeerd = new Queue<Lijn>();
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            Lijnen.AddFirst(lijn);
//            LijnenPositieVerhogen();
//            for (int i = 1; i <= Lijnen.Count; i++)
//            {
//                Lijnen.SkipWhile()
//            }
        }

        public void StelLijnBuitenGebruik(Lijn lijn)
        {
            Lijnen.Remove(lijn);
            LijnenVoorraad.Lijnen.Enqueue(lijn);
//            LijnenDoorschuiven();
        }

//        public void VerplaatsDeLijnen()
//        {
//            LinkedList<Lijn> nieuweLijnen = new LinkedList<Lijn>();
//            nieuweLijnen.AddFirst()
//            for (int i = 0; i < (Lijnen.Count - 1); i++)
//            {
//                Lijnen.
//            }
//        }

        public void LijnenPositieVerhogen()
        {
            int i = 1;
            foreach (Lijn lijnInGebruik in Lijnen)
            {
                if (lijnInGebruik != null)
                {
                    lijnInGebruik.Positie = i;
                    i++;
                }
            }
        }

//        private void LijnenDoorschuiven()
//        {
//            LijnenPositieVerhogen();
//            Lijn laatsteLijn = Lijnen.Last.Value;
//            StelLijnBuitenGebruik(laatsteLijn);
//            NeemLijnInGebruik(laatsteLijn);
//        }
    }
}