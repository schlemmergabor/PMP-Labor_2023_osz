using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_osztalyokObjektumok
{
    internal class Book
    {
        // tagváltozók, adattagok, mind private láthatóságú
        string szerző;
        string cím;
        int kiadásÉve;
        int oldalSzám;

        // konstruktor 4 paraméterrel
        public Book(string szerző, string cím, int kiadásÉve, int oldalSzám)
        {
            // this. jelentése: adott példány, objektum...
            this.szerző = szerző;
            this.cím = cím;
            this.kiadásÉve = kiadásÉve;
            this.oldalSzám = oldalSzám;
        }

        // metódus
        // public láthatóság
        // string visszatérési érték
        // AllData néven
        // () paraméterekkel
        public string AllData()
        {
            // visszatérési érték beállítása
            return szerző + ": " + cím + ", " + kiadásÉve + " (" + oldalSzám + ")";
        }

    }
}
