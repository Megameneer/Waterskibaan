using System;
using WaterSkiBaan.Sporters;

namespace WaterSkiBaan.Events
{
    public class SporterEventArgs : EventArgs
    {
        public Sporter Sporter { get; set; }

        public SporterEventArgs(Sporter sporter)
        {
            Sporter = sporter;
        }
    }
}