using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07_Property
{
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
            // csak ha 6 hosszú a neptunkód
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
            NeptunKod = neptunKod;
            PontSzam = pontSzam;
        }

        // egy paraméteresnél, random értékek létrehozása
        public ExamResult()
        {
            Random rnd = new Random();

            string temp = "";
            temp += (char)rnd.Next((int)'A', (int)'Z' + 1);

            for (int i = 0; i < 5; i++)
            {
                if (rnd.Next(0, 2) == 0)
                { // szám legyen a következő karakter
                    temp += (char)rnd.Next(1, 10);
                }
                else
                { // betű legyen a következő karakter
                    temp += (char)rnd.Next((int)'A', (int)'Z' + 1);

                }
            }

            NeptunKod = temp; // véletlenstring 

            PontSzam = rnd.Next(0, 101); // 0-100 között vsz
        }
    }
}
