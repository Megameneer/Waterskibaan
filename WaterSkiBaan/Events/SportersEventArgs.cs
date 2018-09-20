using System;
using System.Collections.Generic;
using WaterSkiBaan.Sporters;

namespace WaterSkiBaan.Events
{
    public class SportersEventArgs : EventArgs
    {
        public List<Sporter> Sporters { get; set; }

        public SportersEventArgs(List<Sporter> sporters)
        {
            Sporters = sporters;
        }
    }
}