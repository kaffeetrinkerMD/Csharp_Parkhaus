using System;

// Hier wird alles implementiert, was ein Parkhaus betreffen kann

namespace Parken
{
    /// <summary>
    /// <b>Parkhaus</b> gibt den ermittelten Betrag für die Parkdauer zurück.
    /// Durch das aufrufende Programm müssen die Eigenschaften Gebuehr, ParkBeginn und ParkEnde festgelegt werden.
    /// Andernfalls erfolgt eine default- Wertzuweisung
    /// </summary>
    public class Parkhaus
    {
        // Deklarierung von Eigenschaften (Properties) und Variablen (Feldern)
        // Felder nehmen Daten auf und werden intern zur Weiterverarbeitung benutzt
        // sie sollten niemals als <public> deklariert werden

        // Parkgebühr
        private static decimal _gebuehr;

        // Parkbeginn
        private static int _parkBeginn;

        // Parkende
        private static int _parkEnde;

        private readonly Pkw _auto;

        public decimal Gebuehr
        {
            get { return _gebuehr; }
            set
            {
                if (value == 0)
                {
                    _gebuehr = 0.0m;
                }
                else
                {
                    _gebuehr = value;
                }
            }
        }

        public int ParkBeginn
        {
            get { return _parkBeginn; }
            set { _parkBeginn = value; }
        }

        public int ParkEnde
        {
            get { return _parkEnde; }
            set{ _parkEnde = value; }
        }

        // Konstruktor
        public Parkhaus(int parkbeginn, int parkende, decimal gebuehr)
        {
            Gebuehr = gebuehr;

            ParkBeginn = parkbeginn;
            ParkEnde = parkende;

            // Pkw-Objekt erzeugen
            _auto = new Pkw();
        }

        // diese Methode wird durch das Main-Programm aufgerufen
        public decimal ErmittelnBetrag()
        {
            return _auto.BerechneBetrag();
        }

        // Klasse für PKW's
        // nur für "Parken" sichtbar
        internal sealed class Pkw
        {
            private static bool _ausfahrt;
            private static decimal _betrag;
            private static bool _einfahrt;

            // Konstruktor
            public Pkw()
            {
                // Wertzuweisungen für Parkhaus
                //_parkBeginn = SetzeZeitReinfahren(_parkBeginn);
                //_parkEnde = SetzeZeitRausfahren(_parkEnde);

                // Registrieren der Ein- und Ausfahrt
                // die Berechnung des Betrages darf erst dann erfolgen,
                // wenn sowohl der Zeitstempel für den Parkbeginn...
                if (_parkBeginn > -1)
                {
                    _einfahrt = RegistrierenEinfahrt();
                }
                else
                {
                    _einfahrt = false;
                }

                // ... UND der Zeitstempel für das Parkende gesetzt wurden
                if (_parkEnde > -1)
                {
                    _ausfahrt = RegistrierenAusfahrt();
                }
                else
                {
                    _ausfahrt = false;
                }
            }

            private bool PruefeWertebereich()
            {
                // Wertebereich _parkbeginn: {0, 1, ... , 24}
                // Wertebereich _parkende: {0, 1, ... , 24}
                // nur, wenn beide Felder jeweils innerhalb ihres Wertebereichs liegen, ist der Rückgabewert TRUE
                var wb = false;
                var wbBeginn = _parkBeginn >= 0 && _parkBeginn <= 24;
                var wbEnde = _parkEnde >= 0 && _parkEnde <= 24;

                if (wbBeginn && wbEnde)
                {
                    wb = true;
                }

                return wb;
            }

            // wird von Parkhaus.ErmittelnBetrag() aufgerufen
            public decimal BerechneBetrag()
            {
                if (_einfahrt && _ausfahrt)
                {
                    if (_parkBeginn > _parkEnde)
                    {
                        _betrag = 0.0m;
                    }
                    else
                    {
                        _betrag = (_parkEnde - _parkBeginn) * _gebuehr;
                    }
                }
                else
                {
                    Console.WriteLine("Parkbeginn oder Parkende wurden nicht registriert! {0} - {1}", _einfahrt, _ausfahrt);
                    _betrag = 0.0m;
                }

                return _betrag;
            }

            private static bool RegistrierenAusfahrt()
            {
                return true;
            }

            private static bool RegistrierenEinfahrt()
            {
                return true;
            }

            //private static int SetzeZeitRausfahren(int ende)
            //{
            //    // TODO: Zeitstempel setzen (z.B. für Parkende)
            //    // Rückgabe als Integer (nat. nur für Übungszwecke)
            //    var pkwEnde = ende;
            //    return pkwEnde;
            //}

            //private static int SetzeZeitReinfahren(int beginn)
            //{
            //    // TODO: Zeitstempel setzen (z.B. für Parkbeginn)
            //    // Rückgabe als Integer (nat. nur für Übungszwecke)
            //    var pkwBeginn = beginn;
            //    return pkwBeginn;
            //}
        }
    }
}