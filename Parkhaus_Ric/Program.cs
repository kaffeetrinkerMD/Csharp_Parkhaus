using Parken;
using System;

namespace Parkhaus_Ric
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            // ... und die Gebühr pro Zeiteinheit
            const decimal gebuehr = 0.6m;

            // Für die Berechnung der Parkdauer müssen bekannt sein:
            // 1. der Parkbeginn
            var parkbeginn = -1;

            // 2. das Parkende
            var parkende = -1;

            // Für ein Parkhaus ist nur der zu erhaltende Betrag je Fahrzeug relevant
            // Dazu wird für jeden Parkvorgang je Fahrzeug ein Objekt vom Typ Parkhaus initialisiert
            // Das Objekt für das Fahrzeug wird durch das jeweilige Parkhaus-Objekt erzeugt (Kapselung)

            #region Parkvorgang 1 (Parkende liegt vor Parkbeginn)

            parkbeginn = -1;
            parkende = 24;

            Console.WriteLine("Parkvorgang 1:");

            if (parkbeginn <= parkende)
            {
                // Objekt ph vom Typ Parkhaus wird initialisiert
                var ph1 = new Parkhaus(parkbeginn, parkende, gebuehr);    
                
                // Wertüberprüfung
                Console.WriteLine("Gebühr: {0} +++ Beginn: {1} +++ Ende: {2}", ph1.Gebuehr, ph1.ParkBeginn,ph1.ParkEnde);

                //betrag = ph.ErmittelnBetrag();
                //Console.WriteLine("Parkbetrag für Parkvorgang 1: {0}", betrag);

                Console.WriteLine("Betrag für Parkvorgang 1: {0}", ph1.ErmittelnBetrag());
            }
            else
            {
                // Objekt ph vom Typ Parkhaus wird initialisiert
                var ph1 = new Parkhaus(parkbeginn, parkende,gebuehr);   

                Console.WriteLine("Parkende ({0}) kann nicht kleiner sein, als Parkbeginn ({1})", parkende, parkbeginn);
                Console.WriteLine("Betrag für Parkvorgang 1: {0}", ph1.ErmittelnBetrag());
            }

            #endregion Parkvorgang 1 (Parkende liegt vor Parkbeginn)

            // *********************************************************************************************************** //
        }
    }
}