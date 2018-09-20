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
        
        static ZwemvestOpslag zwemvestenStapel = new ZwemvestOpslag();
        static WakeboardOpslag wakeboardStapel = new WakeboardOpslag();
        
        static LijnenUitgerangeerd lijnenUitgerangeerd = new LijnenUitgerangeerd();
        static ObstakelsInHetWater obstakelsInHetWater = new ObstakelsInHetWater();


        static void Main(string[] args)
        {

            //skies wakeboards zwemvesten
            VulOpslag();

            ///////////////////////////////////////
            //Voordat events is uitgelegd...
            ///////////////////////////////////////
            VoegRandomSportersToe(wachtrijBeginWaterskibaan.Wachtrij, 1000);
            VoegRandomSportersToe(wachtrijInstructie.Wachtrij, 1000);
            //VoegRandomSportersToe(wachtrijStarten.Wachtrij, 1000);
            VoegRandomUitrustingToe(zwemvestenStapel, 1000, SportUitrustingType.zwemvest);
            VoegRandomUitrustingToe(wakeboardStapel, 1000, SportUitrustingType.wakeboard);
            //VoegRandomUitrustingToe(skiStapel, 1000, SportUitrustingType.skies);

            ///////////////////////////////////////
            //Nadat events is uitgelegd
            ///////////////////////////////////////
            //WaterSkiBaanEvents waterSkiBaanEvents = new WaterSkiBaanEvents();
            //event nieuwe bezoeker
            //waterSkiBaanEvents.SubcribeHandlerNieuweBezoeker(wachtrijBeginWaterskibaan.VoegSporterToeAanRij);
            //event instructie afgelopen
            //waterSkiBaanEvents.SubcribeHandlerInstructieAfgelopen(SportersPakkenUitrusting);
            //waterSkiBaanEvents.SubcribeHandlerInstructieAfgelopen(SportersPakkenZwemvest);
            //waterSkiBaanEvents.SubcribeHandlerInstructieAfgelopen(SportersVerlatenInstructie);
            //waterSkiBaanEvents.SubcribeHandlerInstructieAfgelopen(SportersGaanNaarInstructie);

            //voordat events is uitgelegd


            for (int i = 0; i < 100; i++)
            {


                //waterSkiBaanEvents.TriggerNieuweBezoeker(new Skier());
                //waterSkiBaanEvents.TriggerNieuweBezoeker(new Wakeboarder());
                //    waterSkiBaanEvents.TriggerInstructieAfgelopen(wachtrijInstructie.GetAlleCursisten());
                //    waterSkiBaanEvents.TriggerLijnenVerplaatsen(lijnenInGebruik);

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
            var cursisten = args.Sporters;

            cursisten.ForEach(c =>
            {

                if (c is Skier)
                {
                    throw new NotImplementedException("cursist moet skies pakken van stapel. Maar dit is nog niet geïmplementeerd");
                }
                else
                {
                    c.Uitrusting = wakeboardStapel.PakWakeboard();
                }

            });
        }

        static void SportersPakkenZwemvest(object sender, SportersEventArgs args)
        {
            var cursisten = args.Sporters;

            cursisten.ForEach(c =>
            {

                c.Zwemvest = zwemvestenStapel.PakZwemvest();
            });
        }

        static public void SportersVerlatenInstructie(object sender, SportersEventArgs args)
        {
            var sporters = args.Sporters;
            wachtrijInstructie.GroepVerlaatRij();
            //wachtrijStarten.GroepSportersNeemtPlaatsInRij(sporters);
        }

        static public void SportersGaanNaarInstructie(object sender, SportersEventArgs args)
        {
            List<Sporter> cursisten = new List<Sporter>();
            for (var i = 0; i < WachtrijInstructie.MAX_CURSISTEN; i++)
            {
                if (wachtrijBeginWaterskibaan.Wachtrij.Count > 0)
                {
                    wachtrijInstructie.Wachtrij.Enqueue(wachtrijBeginWaterskibaan.Wachtrij.Dequeue());
                }

            }
        }

        static void VoegRandomSportersToe(Queue<Sporter> queue, int aantal)
        {
            for (int i = 0; i < aantal; i++)
            {
                if ((i % 2) == 0)
                {
                    queue.Enqueue(new Wakeboarder());
                }
                else
                {
                    queue.Enqueue(new Skier());
                }
            }
        }

        static void VoegRandomUitrustingToe(IOpslag stapel, int aantal, SportUitrustingType type)
        {
            for (int i = 0; i < aantal; i++)
            {
                if (type == SportUitrustingType.zwemvest)
                {
                    stapel.Afgeven(new Zwemvest(RandomInteger()));
                }
                else if (type == SportUitrustingType.wakeboard)
                {
                    stapel.Afgeven(new Wakeboard(RandomInteger()));
                }
                else if (type == SportUitrustingType.skies)
                {
                    //stapel.Afgeven(new Skies(RandomInteger()));
                }
            }
        }

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
                //skiStapel.Afgeven(new Skies(RandomInteger()));
            }
        }

        static Random _r = new Random();

        static int RandomInteger()
        {
            return _r.Next();
        }
    }
}
