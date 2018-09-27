using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaterSkiBaan.Events;
using WaterSkiBaan.Kabelbaan;
using WaterSkiBaan.Sporters;
using WaterSkiBaan.SportOpslag;
using WaterSkiBaan.SportUitrusting;
using WaterSkiBaan.Wachtrijen;

namespace WaterSkiBaan
{
    class Program
    {
        static WachtrijBeginWaterskibaan wachtrijBeginWaterskibaan = new WachtrijBeginWaterskibaan();
        static WachtrijInstructie wachtrijInstructie = new WachtrijInstructie();
        static WachtrijStarten _wachtrijStarten = new WachtrijStarten();

        static ZwemvestOpslag zwemvestenStapel = new ZwemvestOpslag();
        static WakeboardOpslag wakeboardStapel = new WakeboardOpslag();
        static SkieOpslag skiStapel = new SkieOpslag();


        static LijnenVoorraad _lijnenVoorraad = new LijnenVoorraad();
        static LijnenInGebruik lijnenInGebruik = new LijnenInGebruik() {LijnenVoorraad = _lijnenVoorraad};
        static ObstakelsInHetWater obstakelsInHetWater = new ObstakelsInHetWater();


        static void Main(string[] args)
        {
//            for (int i = 0; i < 5; i++)
//            {
//                lijnenInGebruik.NeemLijnInGebruik(new Lijn(0));
//            }

            //skies wakeboards zwemvesten
            VulOpslag();

            ///////////////////////////////////////
            //Voordat events is uitgelegd...
            ///////////////////////////////////////
//            VoegRandomSportersToe(wachtrijBeginWaterskibaan.Wachtrij, 1000);
//            VoegRandomSportersToe(wachtrijInstructie.Wachtrij, 1000);
            //VoegRandomSportersToe(wachtrijStarten.Wachtrij, 1000);
//            VoegRandomUitrustingToe(zwemvestenStapel, 1000, SportUitrustingType.zwemvest);
//            VoegRandomUitrustingToe(wakeboardStapel, 1000, SportUitrustingType.wakeboard);
            //VoegRandomUitrustingToe(skiStapel, 1000, SportUitrustingType.skies);

            ///////////////////////////////////////
            //Nadat events is uitgelegd
            ///////////////////////////////////////
            WaterSkiBaanEvents waterSkiBaanEvents = new WaterSkiBaanEvents();
//                event nieuwe bezoeker
            waterSkiBaanEvents.SubcribeHandlerNieuweBezoeker(wachtrijBeginWaterskibaan.VoegSporterToeAanRij);
            waterSkiBaanEvents.SubscribeHandlerLijnenVerplaatsen(ControleerPositie1);
            waterSkiBaanEvents.SubscribeHandlerLijnenVerplaatsen(HoogPositieOp);
            waterSkiBaanEvents.SubscribeHandlerLijnenVerplaatsen(ControlesVoor5);

//            waterSkiBaanEvents.SubscribeHandlerInstructieBegint()
//            waterSkiBaanEvents.SubscribeHandlerLijnenVerplaatsen(VerplaatsDeLijnen);
//                event instructie afgelopen
            waterSkiBaanEvents.SubcribeHandlerInstructieAfgelopen(SportersPakkenUitrusting);
            waterSkiBaanEvents.SubcribeHandlerInstructieAfgelopen(SportersPakkenZwemvest);
            waterSkiBaanEvents.SubcribeHandlerInstructieAfgelopen(SportersVerlatenInstructie);
            waterSkiBaanEvents.SubcribeHandlerInstructieAfgelopen(SportersGaanNaarInstructie);

            //voordat events is uitgelegd


            for (int i = 0; i < 100; i++)
            {
                waterSkiBaanEvents.TriggerNieuweBezoeker(new Skier());
                waterSkiBaanEvents.TriggerNieuweBezoeker(new Wakeboarder());
//                waterSkiBaanEvents.TriggerInstructieBegint();
                waterSkiBaanEvents.TriggerInstructieAfgelopen(wachtrijInstructie.GetAlleCursisten());
                waterSkiBaanEvents.TriggerLijnenVerplaatsen(lijnenInGebruik);
                Console.WriteLine(lijnenInGebruik.Lijnen.Count);
                if (lijnenInGebruik.Lijnen.Count > 0)
                {
                    Console.WriteLine(lijnenInGebruik.Lijnen.Last.Value.Positie);
                }


                //print overzicht stapels uitrusting
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine("STAPELS");
                Console.WriteLine($"ZWEMVESTEN \t {Program.zwemvestenStapel.ToString()}");
                Console.WriteLine($"SKIES \t niet geïmplementeerd");
                Console.WriteLine($"WAKEBOARDS \t {Program.wakeboardStapel.ToString()}");

                //print overzicht wachtrijen
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine("WACHTRIJEN/GROEPEN");
                Console.WriteLine($"ENTREE \t {Program.wachtrijBeginWaterskibaan.ToString()}");
                Console.WriteLine($"INSTRUCTIE \t {Program.wachtrijInstructie.ToString()}");
                Console.WriteLine($"STARTEN \t niet geïmplementeerd");

                Thread.Sleep(1000);
            }

            while (true)
            {
                Thread.Sleep(1000);
            }
        }

        static void SportersPakkenUitrusting(object sender, SportersEventArgs args)
        {
            Console.WriteLine("SportersPakkenUitrusting");
            var cursisten = args.Sporters;

            cursisten.ForEach(c =>
            {
                if (c is Skier)
                {
                    c.Uitrusting = skiStapel.PakSkies();
//                    throw new NotImplementedException("cursist moet skies pakken van stapel. Maar dit is nog niet geïmplementeerd");
                }
                else
                {
                    c.Uitrusting = wakeboardStapel.PakWakeboard();
                }
            });
        }

        static void SportersPakkenZwemvest(object sender, SportersEventArgs args)
        {
            Console.WriteLine("SportersPakkenZwemvest");
            var cursisten = args.Sporters;

            cursisten.ForEach(c => { c.Zwemvest = zwemvestenStapel.PakZwemvest(); });
        }

        static public void SportersVerlatenInstructie(object sender, SportersEventArgs args)
        {
            Console.WriteLine("SportersVerlatenInstructie");
//            var sporters = args.Sporters;
            wachtrijInstructie.GroepVerlaatRij();
            args.Sporters.ForEach(sporter => _wachtrijStarten.VoegSporterToeAanRij(sporter));
//            _wachtrijStarten.VoegSporterToeAanRij();
        }

        static public void SportersGaanNaarInstructie(object sender, SportersEventArgs args)
        {
            Console.WriteLine("SportersGaanNaarInstructie");
//            List<Sporter> cursisten = new List<Sporter>();
//            List<Sporter> cursisten = args.Sporters;
            for (var i = 0; i < WachtrijInstructie.MAX_CURSISTEN; i++)
            {
                if (wachtrijBeginWaterskibaan.Wachtrij.Count > 0)
                {
                    wachtrijInstructie.Wachtrij.Enqueue(wachtrijBeginWaterskibaan.Wachtrij.Dequeue());
                }
            }

            Console.WriteLine(wachtrijInstructie);
        }

        static public void ControleerPositie1(object sender, LijnEventArgs args)
        {
            LijnenInGebruik lijnenInGebruik = args.LijnenInGebruik;
            // als positie 1 bezet is met een lijn
            // eerst controleren of er uberhaupt een positie 1 is
            if (lijnenInGebruik.Lijnen.Count > 0)
            {
                // dan kunnen we controleren of positie 1 bezet is met een lijn
                if (lijnenInGebruik.Lijnen.First.Value.Equals(null))
                {
                    // zo nee
                    // voeg een nieuwe lijn in
                    lijnenInGebruik.NeemLijnInGebruik(lijnenInGebruik.LijnenVoorraad.Lijnen.Dequeue());
                    // zet de skier in de wachtrij op deze lijn
                    lijnenInGebruik.Lijnen.First.Value.Sporter = _wachtrijStarten.Wachtrij.Dequeue();
                }
            }
        }

        static public void HoogPositieOp(object sender, LijnEventArgs args)
        {
            LijnenInGebruik lijnenInGebruik = args.LijnenInGebruik;
            foreach (Lijn lijn in lijnenInGebruik.Lijnen)
            {
                Console.WriteLine("De lijn is misschien null");
                if (!lijn.Equals(null))
                {
                    Console.WriteLine("De lijn is zeker weten geen null");
                    lijn.Positie++;
                }
            }
        }

        static public void ControlesVoor5(object sender, LijnEventArgs args)
        {
            LijnenInGebruik lijnenInGebruik = args.LijnenInGebruik;
            if (lijnenInGebruik.Lijnen.Count > 0)
            {
                
            }
        }

//        static void VoegRandomSportersToe(Queue<Sporter> queue, int aantal)
//        {
//            for (int i = 0; i < aantal; i++)
//            {
//                if ((i % 2) == 0)
//                {
//                    queue.Enqueue(new Wakeboarder());
//                }
//                else
//                {
//                    queue.Enqueue(new Skier());
//                }
//            }
//        }

//        static void VoegRandomUitrustingToe(IOpslag stapel, int aantal, SportUitrustingType type)
//        {
//            for (int i = 0; i < aantal; i++)
//            {
//                if (type == SportUitrustingType.zwemvest)
//                {
//                    stapel.Afgeven(new Zwemvest(RandomInteger()));
//                }
//                else if (type == SportUitrustingType.wakeboard)
//                {
//                    stapel.Afgeven(new Wakeboard(RandomInteger()));
//                }
//                else if (type == SportUitrustingType.skies)
//                {
//                    //stapel.Afgeven(new Skies(RandomInteger()));
//                }
//            }
//        }

        static void VulOpslag()
        {
            for (var i = 0; i < 20; i++)
            {
                zwemvestenStapel.Afgeven(new Zwemvest(RandomInteger()));
            }

            for (var i = 0; i < 20; i++)
            {
                wakeboardStapel.Afgeven(new Wakeboard(RandomInteger()));
            }

            for (var i = 0; i < 20; i++)
            {
                skiStapel.Afgeven(new Skies(RandomInteger()));
            }
        }

        static Random _r = new Random();

        static int RandomInteger()
        {
            return _r.Next();
        }
    }
}