namespace ZH00_mintaZH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ELMÉLETI KÉRDÉSEK
            // 1. B, D
            // 2. C
            // 3. A függvény megadja, hányszor fordul el˝o az ’a’ érték az ’x’ tömbben.


            #region 1. feladat
            // beolvassuk a fájlt
            string[] genres = File.ReadAllLines(@"..\..\..\genre.txt");
            
            // listába fogjuk eltárolni
            List<string> mufajok = new List<string>();

            // 0. indexhez hozzáadunk egy üreset, mert a genre.txt-ben 1-től vannak
            // az egyes genre értékek
            mufajok.Add("");
            
            // , -vel van elválasztva az egyes genre-k
            string[] darabok = genres[0].Split(',');

            // minden egyes darabra
            foreach(string s in darabok)
            {
                // =-nél feldaraboljuk
                string[] sdarab = s.Split('=');
                // hozzáadjuk a listához
                mufajok.Add(sdarab[0]);
                // a lista indexe meg fog egyezni a = jobb oldalval
            }
            #endregion --------------------------------------------

            #region 2. feladat
            // beolvassuk a fájl minden sorát
            string[] adatok = File.ReadAllLines(@"..\..\..\stadia_dataset.csv");

            // lista a játékok tárolásához
            List<Game> jatekok = new List<Game>();

            // 1. sortól vannak a játékok adatai
            for (int i = 1; i < adatok.Length; i++)
            {
                // feldaraboljuk
                string[] jatekAdat = adatok[i].Split(";");

                // új átmeneti játék
                Game tmp = new Game();

                // Propertyk beállítása
                tmp.Title = jatekAdat[0];
                tmp.Genre = mufajok[int.Parse(jatekAdat[1])];
                tmp.Publisher = jatekAdat[2];
                tmp.ReleaseDate = DateTime.Parse(jatekAdat[3]);
                tmp.OriginalDate = DateTime.Parse(jatekAdat[4]);

                // listához hozzáadás
                jatekok.Add(tmp);
            }
            #endregion --------------------------------------------

            #region 3. feladat
            // választott menüpont
            string be = "";
            // amíg nem a X - kilépést választottuk
            while (be!="X")
            {
                // tájékoztató menü
                Console.Clear();
                Console.WriteLine("4 - Adott kiadóhoz tartozó játékok száma.");
                Console.WriteLine("5 - A megjelenés napjától elérhető játékok.");
                Console.WriteLine("6 - Játékok száma műfajonként.");
                Console.WriteLine("X - kilépés");
                be = Console.ReadLine();


                #region 4. feladat
                if (be=="4")
                {
                    Console.Write("Kérek egy kiadót: ");
                    string kiado = Console.ReadLine();
                    // ennyi játék tartozik a kiadóhoz
                    int db = 0;
                    // végig járjuk a listát
                    foreach (Game item in jatekok)
                    {
                        // db++, ha a kiadó egyezik
                        if (item.Publisher == kiado) db++;
                    }
                    Console.WriteLine($"A játékok száma: {db}");
                    Console.ReadLine();
                }
                #endregion 4. feladat vége ------

                #region 5. feladat
                if (be=="5")
                {
                    Console.WriteLine("Az elérhető játékok: ");
                    foreach (Game item in jatekok)
                    {
                        // Évek egyeznek
                        if (item.OriginalDate.Year==item.ReleaseDate.Year)
                        {
                            Console.WriteLine($"{item.Title} {item.Genre} {item.OriginalDate.Year}");
                        }
                    }

                    Console.ReadLine();
                }
                #endregion 5. feladat vége ------

                #region 6. feladat
                if (be == "6")
                {
                    Console.WriteLine("Műfaj\tDarabszám");
                    // végigjárjuk a mufajokat
                    foreach (string item in mufajok)
                    {
                        int db = 0;
                        Console.Write(item);
                        //  végigjárjuk a játékokat
                        foreach (Game gem in jatekok)
                        {
                            if (gem.Genre == item) db++; 
                        }
                        // mufajok[0] értéke "", ezt leszámítva írjuk ki db-t
                        if (item!="") Console.WriteLine($"\t{db}");
                    }
                    Console.ReadLine();
                }
                #endregion 5. feladat vége ------
            }
            #endregion 3. feladat vége ----------------------------------


        }
    }
}