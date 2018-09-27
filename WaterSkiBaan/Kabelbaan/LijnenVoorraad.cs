using System.Collections.Generic;

namespace WaterSkiBaan.Kabelbaan
{
    public class LijnenVoorraad
    {
        public Queue<Lijn> Lijnen { get; set; } = new Queue<Lijn>();

        public LijnenVoorraad()
        {
            Lijnen.Enqueue(new Lijn(2));
            Lijnen.Enqueue(new Lijn(3));
            Lijnen.Enqueue(new Lijn(4));
            Lijnen.Enqueue(new Lijn(5));
            Lijnen.Enqueue(new Lijn(6));
            Lijnen.Enqueue(new Lijn(7));
            Lijnen.Enqueue(new Lijn(8));
            Lijnen.Enqueue(new Lijn(9));
            Lijnen.Enqueue(new Lijn(10));
            Lijnen.Enqueue(new Lijn(11));
        }
    }
}