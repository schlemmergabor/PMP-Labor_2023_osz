using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L09_gyakorlasObjektumok
{
    internal class Reszleg
    {
        // mező, adattagok, belső változók
        string nev;
        Munkavallalo[] alkalmazottak;

        // ctor
        public Reszleg(string nev, Munkavallalo[] alkalmazottak)
        {
            this.nev = nev;
            this.alkalmazottak = alkalmazottak;
        }

        // Metódus -> Összegzés tételre példa
        public int KivehetoSzabik()
        {
            int ertek = alkalmazottak[0].KivehetoSzabi();
            for (int i = 1; i < alkalmazottak.Length; i++)
            {
                ertek = ertek + alkalmazottak[i].KivehetoSzabi();
            }
            return ertek;
        }
        
        // Metódus -> Eldöntés tételre példa
        public bool NincsSzabi()
        {
            int i = 0;
            while (i < alkalmazottak.Length && !(alkalmazottak[i].KivehetoSzabi()==0))
            {
                i++;
            }

            bool van;
            if (i < alkalmazottak.Length) van = true;
            else van = false;

            return van;

        }

    }
}
