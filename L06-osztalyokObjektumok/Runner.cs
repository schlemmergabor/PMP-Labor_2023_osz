using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_osztalyokObjektumok
{
    internal class Runner
    {
        // tagváltozók
        string nev;
        int sorSzam;
        int sebesseg; // m/s
        int tav; // m

        // konstruktor -> 3 paraméterrel
        public Runner(string nev, int sorSzam, int sebesseg)
        {
            this.nev = nev;
            this.sorSzam = sorSzam;
            this.sebesseg = sebesseg;
            this.tav = 0; // kezdőérték állítása itt
        }
        // távolság frissítése
        public void RefreshDistance(int mp)
        {
            this.tav += mp * this.sebesseg;
        }
        // kirajzolás
        public void Show()
        {
            Console.SetCursorPosition(this.tav, this.sorSzam);
            Console.Write(this.nev[0]);
             
        }
        // táv lekérése
        public int GetDistance() 
        {
            return this.tav;
        }
    }
}
