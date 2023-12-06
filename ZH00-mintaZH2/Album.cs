using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH00_mintaZH2
{
    enum Adathordozo
    {
        Kazetta, 
        CD,
        Bakelit, 
        Stream
    }
    internal class Album
    {
        string előadó;
        string cim;
        Adathordozo adathordozoTipusa;
        List<Zeneszam> zeneSzamok;

        public int ZenekSzama { get { return zeneSzamok.Count(); }  }


        private Zeneszam ZeneszamFeldolgozas(string s)
        {
            string[] darab = s.Split(';');
            string cim = darab[0];
            string eloadok = darab[1];
            int hossz = int.Parse(darab[2]);

            return new Zeneszam(cim, eloadok, hossz);
        }

        private void FelveteltHozzaad(Zeneszam z)
        {
            zeneSzamok.Add(z);
        }

        public Album(string előadó, string cim, string file)
        {
            this.előadó = előadó;
            this.cim = cim;
            zeneSzamok = new List<Zeneszam>();
            // milyen legyen az adathordozó típusa?

            Console.Write("Milyen legyen az adathordozó típusa? Kazetta/CD/Bakelit/Stream ");

            string be = Console.ReadLine();

            adathordozoTipusa = (Adathordozo)Enum.Parse(typeof(Adathordozo), be);

            string[] fileSorok = File.ReadAllLines(file);
            foreach (string item in fileSorok)
            {
                zeneSzamok.Add(ZeneszamFeldolgozas(item));
            }
            
        }



        private string LegrovidebbFelvetel()
        {
            int minIndex = 0;
            for (int i = 1; i < zeneSzamok.Count; i++)
            {
                if (zeneSzamok[i].Hossz < zeneSzamok[minIndex].Hossz) minIndex = i;
            }
            return zeneSzamok[minIndex].Cim;
        }

        public int AdottHosszFelett(int mp)
        {
            int db = 0;
            for (int i = 0; i < zeneSzamok.Count; i++)
            {
                if (zeneSzamok[i].Hossz > mp) db++;
            }
            return db;
        }

        public string[] SzerzoKivalogat(string s)
        {
            int db = 0;
            for (int i = 0; i < zeneSzamok.Count; i++)
            {
                if (zeneSzamok[i].Szerzo.Contains(s)) db++;
            }

            string[] temp = new string[db];
            int j = 0;
            for (int i = 0; i < zeneSzamok.Count; i++)
            {
                if (zeneSzamok[i].Szerzo.Contains(s)) temp[j++] = zeneSzamok[i].Cim;
            }
            return temp;
        }

        public string AlbumStatisztika()
        {
            string temp =$"{előadó} - {cim} ({adathordozoTipusa})\n\n";

            temp += $"Dalok száma: {this.ZenekSzama}\n";

            temp += $"A legrövidebb dal címe: {LegrovidebbFelvetel()}\n";

            int összHossz = 0;
            foreach (Zeneszam item in zeneSzamok)
            {
                összHossz += item.Hossz;
            }
            int atlagMp = összHossz / zeneSzamok.Count();
            TimeSpan ts = new TimeSpan(0,0,atlagMp);

            temp += $"A dalok átlagos hossza: {ts.ToString("mm':'ss")}\n\n";

            for (int i = 0; i < zeneSzamok.Count; i++)
            {
                string[] db = zeneSzamok[i].Szerzo.Split(',');

                temp += $"{i + 1}. {zeneSzamok[i].Cim} ({db.Length} szerző)\n";


            }
            return temp;
        }
    }
}
