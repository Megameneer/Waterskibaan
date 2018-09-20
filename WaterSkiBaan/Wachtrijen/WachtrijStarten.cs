using System.Collections.Generic;
using WaterSkiBaan.Sporters;

namespace WaterSkiBaan.Wachtrijen
{
    public class WachtrijStarten
    {
        public Queue<Sporter> Wachtrij { get; set; }

        public void VoegSporterToeAanRij(Sporter sporter)
        {
            Wachtrij.Enqueue(sporter);
        }

        public WachtrijStarten()
        {
            Wachtrij = new Queue<Sporter>();
        }
    }
}