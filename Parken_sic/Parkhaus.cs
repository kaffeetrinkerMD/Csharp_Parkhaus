using System;

// Hier wird alles implementiert, was ein Parkhaus betreffen kann

namespace Parken
{
    public class Parkhaus
    {
        // Deklarierung von Eigenschaften (Properties)

        public string bezeichnung;
        public decimal betrag;
        private decimal gebuehr = 0.6m;
        private bool einfahrt;
        private bool ausfahrt;

        // (Standard-) Konstruktor - wird bei Initialsierung des Objektes aufgerufen,
        // wenn kein anderer Konstruktor bei Initialisierung des Objektes verwendet wird
        public Parkhaus()
        {
            // TODO
            // Setzen aller Eigenschaftswerte des Parkhauses (z.B. Öffnungszeiten, Bezeichnung...)
            bezeichnung = "Parkhaus für alle Fahrzeuge";
            betrag = 0.0m;
            einfahrt = false;
            ausfahrt = false;
        }

        // überladener Konstruktor - wird bei Initialsierung des Objektes aufgerufen
        public Parkhaus(string name)
        {
            bezeichnung = name;
        }

        // 
        public int RegistrierenEinfahrt(){

        }

        public int RegistrierenAusfahrt(){}
    }
}

