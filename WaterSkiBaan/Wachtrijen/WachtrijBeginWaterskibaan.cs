using System.Collections.Generic;
using System.Text;
using WaterSkiBaan.Events;
using WaterSkiBaan.Sporters;

namespace WaterSkiBaan.Wachtrijen
{
    public class WachtrijBeginWaterskibaan
    {
        public Queue<Sporter> Wachtrij { get; set; } = new Queue<Sporter>();

        public void VoegSporterToeAanRij(object sender, SporterEventArgs args)
        {
            Wachtrij.Enqueue(args.Sporter);
        }

        public override string ToString()
        {
            var wachtrijArray = Wachtrij.ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < wachtrijArray.Length; i++)
            {
                sb.Append("* ");
            }
            return $"({wachtrijArray.Length.ToString()}) {sb.ToString()}";
        }
    }
}