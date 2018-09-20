using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaterSkiBaan.Events;
using WaterSkiBaan.Sporters;

namespace WaterSkiBaan.Wachtrijen
{
    public class WachtrijInstructie
    {
        public Queue<Sporter> Wachtrij { get; set; } = new Queue<Sporter>();

        public const int MAX_CURSISTEN = 10;

        public void VoegSporterToeAanRij(object sender, SporterEventArgs args)
        {
            Wachtrij.Enqueue(args.Sporter);
        }

        public List<Sporter> GetAlleCursisten()
        {
            return Wachtrij.Take(Wachtrij.Count).ToList();
        }

        public void GroepVerlaatRij()
        {
            Wachtrij.Clear();
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