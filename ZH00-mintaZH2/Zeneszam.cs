using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH00_mintaZH2
{
    internal class Zeneszam
    {
        // mezők
        string cim;
        string szerzo; // ,-el elválasztva több szerző
        int hossz;

        // Property-k
        public string Cim { get => cim;  }
        public string Szerzo { get => szerzo;  }
        public int Hossz { get => hossz; set { if (value >= 0) hossz = value; } }

        // konstruktor
        public Zeneszam(string cim, string szerzo, int hossz)
        {
            this.cim = cim;
            this.szerzo = szerzo;
            this.hossz = hossz;
        }

        // publikus metódus
        public TimeSpan IdoTimeSpan()
        {
            return new TimeSpan(0, 0, hossz);
        }
    }
}
