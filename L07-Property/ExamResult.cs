using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07_Property
{
    enum Érdemjegy
    {
        Elégtelen, // =0
        Elégséges, // =1
        Közepes, // =2
        Jó, // =3
        Jeles // =4
    }
    internal class ExamResult
    {
        // adattagok, mezők, belső változók
        string neptunKod;
        int pontSzam;

        // auto-propertyvel létrehozva, prop (TAB)
        public bool Passed
        {
            get
            {
                if (pontSzam >= 50) return true;
                else return false;
            }
            // set;-et töröltük, hogy ne lehessen beállítani
        }


        public string NeptunKod
        {
            get => neptunKod;
            // csak ha 6 hosszú a neptunkód beállítását engedjük meg
            set { if (value.Length == 6) neptunKod = value; }
        }

        public int PontSzam
        {
            get => pontSzam;
            // 0-pontnál nagyobb pontszám
            set { if (value > -1) pontSzam = value; }
        }

        // két paraméteres konstruktor
        public ExamResult(string neptunKod, int pontSzam)
        {
            // Propertyn keresztül állítjuk be, így 
            // az "ellenőrzések" is "lefutnak"
            NeptunKod = neptunKod;
            PontSzam = pontSzam;
        }

        // paraméter nélküli konstruktor, random értékek létrehozása
        public ExamResult()
        {
            Random rnd = new Random();

            string temp = "";
            temp += (char)rnd.Next((int)'A', (int)'Z' + 1);

            for (int i = 0; i < 5; i++)
            {
                if (rnd.Next(0, 2) == 0)
                { // szám legyen a következő karakter
                    temp += rnd.Next(1, 10);
                }
                else
                { // betű legyen a következő karakter
                    temp += (char)rnd.Next((int)'A', (int)'Z' + 1);

                }
            }
            
            NeptunKod = temp; // véletlenstring 

            PontSzam = rnd.Next(0, 101); // 0-100 között vsz
        }

        // Grade metódu
        public Érdemjegy Grade(int[] pontHatárok)
        {
            // kezdetben a 0. indexű szintre tesszük a pontunkat
            int szint = 0;

            // végig nézzük az összes indexel a szinteket
            for (int i = 0; i < pontHatárok.Length; i++)
            {
                // ha a pontszámunk legalább akkora, mint
                // a ponthatár alsó értéke, akkor
                // az új szint az i. lesz
                if (PontSzam >= pontHatárok[i]) szint = i;
            }

            // itt a szint változó indexeli a pontHatárok tömböt
            // azaz, hogy melyik indexű "szinten" van pontunk

            // Érdemjegy típussa castolunk az (Érdemjegy)-el
            // a számból ÉJ lesz, enum-nál találod, hogy melyik számból
            // melyik enumot fogja visszaadni
            return (Érdemjegy)szint;

        }
    }
}
