﻿using System;
using System.Globalization;

namespace L04_karakterlancok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. feladat
            
            Console.Write("Kérem a szöveget: ");

            // beolvassuk a szöveget és egyből kisbetűssé is alakítjuk
            string beSzoveg = Console.ReadLine().ToLower();

            // segédváltozók, számláláshoz
            int numBetuk = 0;
            int numSzamok = 0;
            int numMgh = 0;

            // karakterenként végigmegyünk a beolvasott szövegen
            foreach (char karakter in beSzoveg)
            {
                // a karakter betű?
                if (char.IsLetter(karakter)) numBetuk++;

                // a karakter szám?
                if (char.IsDigit(karakter)) numSzamok++;

                // karakter Mgh?
                if (karakter == 'a' || karakter == 'á' || karakter == 'e' || karakter == 'é' || karakter == 'i' || karakter == 'í' || karakter == 'o' || karakter == 'ó' || karakter == 'ö' || karakter == 'ő' || karakter == 'u' || karakter == 'ú' || karakter == 'ü' || karakter == 'ű') numMgh++;

            }
            #endregion -----------------------------------------------------------------------------------------

            #region 2. feladat

            string szoveg = "Géza kék az ég.";

            // kisbetűssé alakítás
            string kisbetus = szoveg.ToLower();

            // Eltávolítjuk a szóközt, pontot, vesszőt
            string szokozNelkul = kisbetus.Replace(" ", "");
            szokozNelkul = szokozNelkul.Replace(".", "");
            szokozNelkul = szokozNelkul.Replace(",", "");

            // ellenőrzés, hogy visszafelé is ugyanaz-e?

            // átalakítjuk a szöveget -> char[] tömbbé
            char[] karakterek = szokozNelkul.ToCharArray();

            // megfordítjuk a char[] tömböt
            karakterek.Reverse();

            // char[] -> string
            string ell = new string(karakterek);
            // ez két string megegyezik-e?

            if (ell == szokozNelkul)
            {
                Console.WriteLine("Palindrom a szöveg");
            }
            else
            {
                Console.WriteLine("NEM palindrom a szöveg");
            }

            #endregion -----------------------------------------------------------------------------------------

            #region 3. feladat
            Console.Write("Adja meg a rendszámot: ");
            string be = Console.ReadLine();

            // kitöröljük (lecseréljük) a space a - jeleket
            // és nagybetűssé is alakítjuk egyben
            be = be.Replace(" ", "").Replace("-", "").ToUpper();

            // összeállítjuk a kimeneti stringet
            // .ToString() - nélkül nem betűket kapsz
            string ki = be[0].ToString() + be[1].ToString() + " " + be[2].ToString() + be[3].ToString() + "-" + be[4].ToString() + be[5].ToString() + be[6].ToString();


            Console.WriteLine($"A rendszám sztenderd formátuma: {ki}");

            #endregion -----------------------------------------------------------------------------------------
            #region 4. feladat
            // ennyi rendszámot kell generálni
            int rSzama = 4;

            Random vel = new Random();
            

            for (int i = 0; i < rSzama; i++)
            {
                // éppen generált rendszám
                string rendszam = "";

                // rendszam végéhez hozzáfűzzük a
                // 65-90 közötti ASCII kódtáblából
                // char-ba átcastolt értéket
                rendszam += (char)vel.Next(65, 91);
                rendszam += (char)vel.Next(65, 91);
                
                // elválasztó szóköz
                rendszam += " ";

                // újabb két betű
                rendszam += (char)vel.Next(65, 91);
                rendszam += (char)vel.Next(65, 91);

                // elválasztó -
                rendszam += "-";

                // három szám -> ASCII-ban 
                rendszam += (char)vel.Next(48, 58);
                rendszam += (char)vel.Next(48, 58);
                rendszam += (char)vel.Next(48, 58);

                Console.WriteLine(rendszam);
            }

            #endregion -----------------------------------------------------------------------------------------


            #region 6. feladat

            // Véletlenszám generáló objektum
            Random rnd = new Random();

            // kezdő NK üres
            string neptunKod = "";

            // NK-amit keresünk
            string NK = "C1FIU8";

            // számláló
            int db = 0;

            // addig generálunk, amíg nem a keresett NK-k kapjuk
            while (NK != neptunKod && db < 1) // 
            {
                // első karakter betű, ami az ASCII kódtáblában 65-90 között van
                int rNum = rnd.Next(65, 91);

                // kódot -> char-á alakítok
                char betu = (char)rNum;

                // hozzáfűzöm az NK végéhez (ami most üres, tehát első betű lesz)
                neptunKod += betu;

                // maradék 5 karakterre a következőt csinálom
                for (int i = 1; i < 6; i++)
                {
                    // betű vagy szám legyen?
                    int betuE = rnd.Next(0, 2);

                    // szám lesz
                    if (betuE == 0)
                    {
                        // ASCII kódtábla 0-9 közötti kódjából generálok
                        rNum = rnd.Next(48, 58); // 0-9
                    }
                    else
                    {
                        // ASCII kódtábla betűt tartalmazó részéből generálok
                        rNum = rnd.Next(65, 91);  // A - Z
                    }

                    // int -> char
                    char betu2 = (char)rNum;

                    // NK-hoz hozzáfűzés
                    neptunKod += betu2;

                }

                db++;
            }

            #endregion -----------------------------------------------------------------------------------------

            #region 8. feladat

            // forrás szöveg
            string s = "Vincent;Vega;Vince\nMarsellus;Wallace;Big Man\nWinston;Wolf;The Wolf";

            // \n-ek mentén felvájuk
            string[] sorok = s.Split('\n');

            // hány sorunk lesz?
            int sorSz = sorok.Length;

            // hány oszlopunk lesz
            // első sort vágjuk fel ;-k mentén
            int oszlopSz = sorok[0].Split(";").Length;

            // eredmény kétdimenziós tömb
            string[,] result = new string[sorSz, oszlopSz];

            // eredmény melyik sorába írunk
            int j = 0;

            // soronként megyünk
            foreach (string sor in sorok)
            {
                // sort felosztjuk cellákra ; -n mentén
                string[] cells = sor.Split(";");

                // felosztott cellákon végigmegyünk
                for (int i = 0; i < cells.Length; i++)
                {
                    // eredmény tömbbe beírjuk
                    result[j, i] = cells[i];
                }
                // következő sorra lépés az eredményben
                j++;
            }

            #endregion -----------------------------------------------------------------------------------------
        }
    }
}