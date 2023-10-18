using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_osztalyokObjektumok
{
    internal class Titkositas
    {
        // belső változó, kulcs értéke
        int kulcs;

        // konstruktor
        public Titkositas(int kulcs)
        {
            this.kulcs = kulcs;
        }
        // üzenet átalakítása
        private string TransformMessage(string uzenet, int kulcs)
        {
            // uj szöveg üres
            string uj = "";
            // végig megyünk az eredeti üzenet karakterein
            for (int i = 0; i < uzenet.Length; i++)
            {
                // vesszük a betűt
                char betu = uzenet[i];
                // számmá alakítjuk
                int szam = (int)betu;
                // hozzáadjuk a kulcsot
                int ujszam = szam + kulcs;
                // visszalakítjuk betűvé
                char ujbetu = (char)ujszam;

                // hozzáfűzzük az új stringhez
                uj += ujbetu;
            }
            // vissza returnoljük az uj stringet
            return uj;
        }
        public string Encode(string uzenet)
        {
            // kódolás +kulcs miatt 
            return TransformMessage(uzenet, kulcs);

        }

        public string Decode(string uzenet)
        {
            // dekódolás -kulcs miatt
            return TransformMessage(uzenet, -kulcs);
        }
    }
}
