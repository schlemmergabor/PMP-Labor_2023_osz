using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH00_mintaZH2
{
    // saját enum készítése
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
        // listában tárolom a zeneszámokat
        List<Zeneszam> zeneSzamok;

        // .Count() adja vissza a lista elemszámát
        public int ZenekSzama { get { return zeneSzamok.Count(); }  }

        private Zeneszam ZeneszamFeldolgozas(string s)
        {
            // feldarabolom ;-nál
            string[] darab = s.Split(';');

            string cim = darab[0];
            string eloadok = darab[1];
            int hossz = int.Parse(darab[2]);

            // új példányt, objektumot létrehozok és egyből vissza is adom
            return new Zeneszam(cim, eloadok, hossz);
        }

        private void FelveteltHozzaad(Zeneszam z)
        {
            // csak ennyi, hogy elrejtsem, hogy tömbbel vagy listával oldottam meg
            // a zeneszámok tárolását
            zeneSzamok.Add(z);

            // itt tömb esetében hosszabb a kód
            // temp tömb -> tömb+1 mérettel
            // átmásol tömb-ből temp-be
            // temp utolsó indexére új zeneszam
            // tömb = temp
        }

        public Album(string előadó, string cim, string file)
        {
            this.előadó = előadó;
            this.cim = cim;
            
            // lista létrehozása
            zeneSzamok = new List<Zeneszam>();
            
            
            // Milyen legyen az adathordozó típusa?
            // Kérdezzük meg a felhasználót (lásd 3. feladat Main...)
            Console.Write("Milyen legyen az adathordozó típusa? Kazetta/CD/Bakelit/Stream ");

            // szöveg beolvasása
            string be = Console.ReadLine();

            // saját Enum-ba Parseolás
            adathordozoTipusa = (Adathordozo)Enum.Parse(typeof(Adathordozo), be);

            // file beolvasása egy tömbbe
            string[] fileSorok = File.ReadAllLines(file);
            // végig megyek a beolvasott tömbön
            foreach (string item in fileSorok)
            {
                // hozzáadom a feldolgozott felvételt
                FelveteltHozzaad(ZeneszamFeldolgozas(item));
            }
            
        }



        private string LegrovidebbFelvetel()
        {
            // minimum kiválasztásos tétel
            // kezdeti minimum indexe az első
            int minIndex = 0;
            
            // másodiktól végignézem
            for (int i = 1; i < zeneSzamok.Count; i++)
            {
                // ha az i-edik rövidebb, akkor index elmentése
                if (zeneSzamok[i].Hossz < zeneSzamok[minIndex].Hossz) minIndex = i;
            }
            // legkisebb címének returnja
            return zeneSzamok[minIndex].Cim;
        }

        public int AdottHosszFelett(int mp)
        {
            // megszámlálás tétele

            // kezdetben 0 db
            int db = 0;
            // végig az egészen
            for (int i = 0; i < zeneSzamok.Count; i++)
            {
                // ha hossz nagyobb, akkor db=db+1
                if (zeneSzamok[i].Hossz > mp) db++;
            }

            return db;
        }

        public string[] SzerzoKivalogat(string s)
        {
            // megszámlálás tétele
            int db = 0;
            for (int i = 0; i < zeneSzamok.Count; i++)
            {
                // Szerzo (string)-ben ha van s, akkor db=db+1;
                if (zeneSzamok[i].Szerzo.Contains(s)) db++;
            }

            // db-nyi számot számoltam meg
            string[] temp = new string[db];
            // j-edik szám címét mentettem el
            int j = 0;
            // végig megyek az összes zeneszámon
            for (int i = 0; i < zeneSzamok.Count; i++)
            {
                // ha a s-t tartalmazza a szerző string, akkor
                // temp-be hozzáadom
                // és j-t megnövelem
                if (zeneSzamok[i].Szerzo.Contains(s)) temp[j++] = zeneSzamok[i].Cim;
            }
            return temp;
        }

        public string AlbumStatisztika()
        {
            // temp string-et állítok elő
            // $"" -ben a $ jel azért kell, hogy a változókat, metódusokat
            // megtudjam hívni { } jelek között

            string temp =$"{előadó} - {cim} ({adathordozoTipusa})\n\n";

            temp += $"Dalok száma: {this.ZenekSzama}\n";

            temp += $"A legrövidebb dal címe: {LegrovidebbFelvetel()}\n";

            // átlag számítása
            int összHossz = 0;
            foreach (Zeneszam item in zeneSzamok)
            {
                összHossz += item.Hossz;
            }
            int atlagMp = összHossz / zeneSzamok.Count();
            TimeSpan ts = new TimeSpan(0,0,atlagMp);

            temp += $"A dalok átlagos hossza: {ts.ToString("mm':'ss")}\n\n";

            // dalok listájának kiírása sorrendben
            for (int i = 0; i < zeneSzamok.Count; i++)
            {
                string[] db = zeneSzamok[i].Szerzo.Split(',');
                
                // i+1 azért, mert 1. sorszám van
                temp += $"{i + 1}. {zeneSzamok[i].Cim} ({db.Length} szerző)\n";
            }
            return temp;
        }
    }
}
