using System;
using WaterSkiBaan.Kabelbaan;

namespace WaterSkiBaan.Events
{
    public class LijnEventArgs : EventArgs
    {
        public LijnenInGebruik LijnenInGebruik { get; set; }

        public LijnEventArgs(LijnenInGebruik lijnenInGebruik)
        {
            LijnenInGebruik = lijnenInGebruik;
        }
    }
}