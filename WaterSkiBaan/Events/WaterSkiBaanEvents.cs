using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterSkiBaan.Kabelbaan;
using WaterSkiBaan.Sporters;

namespace WaterSkiBaan.Events
{
    public class WaterSkiBaanEvents
    {
        /**
         *  NIEUWE BEZOEKER
         */
        private event EventHandler<SporterEventArgs> NieuweBezoeker;

        public void SubcribeHandlerNieuweBezoeker(EventHandler<SporterEventArgs> methode)
        {
            NieuweBezoeker += methode;
        }

        public void TriggerNieuweBezoeker(Sporter sporter)
        {
            NieuweBezoeker?.Invoke(this, new SporterEventArgs(sporter));
        }

        /**
         * 
         * INSTRUCTIE AFGELOPEN
         * 
         * Acties:
         * - Sporter die instructie hebben gehad spullen laten pakken (wakeboard/skies en een zwemvest)
         * - Sporters van instructie rij naar naar WachtRijStarten
         * - Sporters van WachtrijBeginWaterskibaan naar WachtrijInstructie
         */
        private event EventHandler<SportersEventArgs> InstructieAfgelopen;

        public void SubcribeHandlerInstructieAfgelopen(EventHandler<SportersEventArgs> methode)
        {
            InstructieAfgelopen += methode;
        }

        public void TriggerInstructieAfgelopen(List<Sporter> sporters)
        {
            InstructieAfgelopen?.Invoke(this, new SportersEventArgs(sporters));
        }

        public delegate void LijnenVerplaatsenDelegate();

        private event EventHandler<LijnEventArgs> LijnenVerplaatsen;
//        private event EventHandler<SportersEventArgs> LijnenVerplaatsen;

        public void SubscribeHandlerLijnenVerplaatsen(EventHandler<LijnEventArgs> method)
        {
            LijnenVerplaatsen += method;
        }

        public void TriggerLijnenVerplaatsen(LijnenInGebruik lijnenInGebruik)
        {
            LijnenVerplaatsen?.Invoke(this, new LijnEventArgs(lijnenInGebruik));
        }

        private event EventHandler<EventArgs> InstructieBegint; 
        public void TriggerInstructieBegint()
        {
            InstructieBegint?.Invoke(this, new EventArgs());
        }
    }
}