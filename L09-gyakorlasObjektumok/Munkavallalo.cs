using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L09_gyakorlasObjektumok
{
    internal class Munkavallalo
    {
        // field, belső változók, adattagok
        string nev;
        int fizKat;
        int evesSzabi;
        int eddigKivettSzabi;

        // konstuktorok
        public Munkavallalo(string nev, int fizKat)
        {
            this.nev = nev;
            this.fizKat = fizKat;
            this.evesSzabi = 0;
            this.eddigKivettSzabi = 0;
        }

        // : this (...) hívódik meg először, utána a metódus magja
        public Munkavallalo(string nev, int fizKat, int evesSzabi) : this(nev, fizKat)
        {
            this.evesSzabi = evesSzabi;
        }

        // Property-k
        public int EddigKivettSzabi { get => eddigKivettSzabi;  }
        public int FizKat { get { return fizKat; } set { fizKat = value; }  }

        public string Nev { get { return nev; } set { nev = value; } }

        // saját metódus
        public int KivehetoSzabi()
        {
            return evesSzabi - eddigKivettSzabi;
        }

    }
}
