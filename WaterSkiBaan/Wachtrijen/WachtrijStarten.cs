using System.Collections.Generic;
using WaterSkiBaan.Events;
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

        public void VoegSporterToeAanRij(object sender, SporterEventArgs args)
        {
            this.VoegSporterToeAanRij(args.Sporter);
        }

        public WachtrijStarten()
        {
            Wachtrij = new Queue<Sporter>();
        }
    }
}