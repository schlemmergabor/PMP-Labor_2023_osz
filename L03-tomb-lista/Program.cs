using Microsoft.VisualBasic.FileIO;

namespace L03_tomb_lista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            #region 1. feladat
            string[] szinek = { "Kör", "Káró", "Treff", "Pik" };

            string[] magasságok = { "2", "3", "4", "5",
                "6", "7", "8", "9", "10",
                "Jumbó", "Dáma", "Király", "Ász"};

            string[] kartyak = new string[52];

            // éppen melyik lapot generáljuk
            int lapszam = 0;

            for (int i = 0; i < szinek.Length; i++)
            {
                for (int j = 0; j < magasságok.Length; j++)
                {
                    // beáll megfelelő lapot
                    kartyak[lapszam++] = szinek[i] + " " + magasságok[j];
                }
            }

            // Ellenőrzés

            foreach (string item in kartyak)
            {
                Console.Write(item + "\t");
            }
            #endregion

            Console.ReadLine();

            #region 2. feladat
            // Kártyák keverése Fisher-Yates keveréssel
            for (int i = 0; i < kartyak.Length; i++)
            {
                Random rnd = new Random();
                int j = rnd.Next(i, kartyak.Length);

                string tmp = kartyak[j];
                kartyak[j] = kartyak[i];
                kartyak[i] = tmp;
            }

            // Ellenőrzés
            Console.Clear();
            foreach (string item in kartyak)
            {
                Console.Write(item + "\t");
            }
            #endregion


            #region 3. feladat
            Console.Clear();
            Console.Write("Kérek egy számot: ");
            int N = int.Parse(Console.ReadLine());

            string[] szavak = new string[N];

            for (int i = 0; i < szavak.Length; i++)
            {
                Console.Write($"Kérem az {i + 1}. szót: ");
                szavak[i] = Console.ReadLine();
            }

            Console.Write("Kérek egy szót: ");
            string be = Console.ReadLine();


            // hanyadik indexen van
            int holVan = -1;

            // lépek a tömb elemein
            int ind = 0;

            while (holVan == -1 && ind < szavak.Length)
            {
                if (szavak[ind] == be) holVan = ind;
                ind++;
            }

            Console.WriteLine(ind);
            #endregion


            #region 4. feladat
            List<string> szoLista = new List<string>();

            string beSzo = "";

            do
            {
                Console.Write("Kérek egy szót: ");

                beSzo = Console.ReadLine();

                szoLista.Add(beSzo);

                ;

            } while (beSzo != "STOP");


            Console.Write("Szó: ");
            string bekertSzo = Console.ReadLine();

            int szoIndex = szoLista.IndexOf(bekertSzo);

            if (szoIndex > -1)
                Console.WriteLine($"A szó benne van a listában az {szoIndex} indexen.");
            else
                Console.WriteLine("A szó nincs benne a listában.");
            #endregion

            
            #region 5. feladat
            List<string> nevek = new List<string>();
            List<int> eletkorok = new List<int>();
            List<bool> tapasztalat = new List<bool>();


            string beNev;

            do
            {
                Console.Write("Kérek egy nevet: ");
                beNev = Console.ReadLine();
                if (beNev!="")
                {
                    nevek.Add(beNev);
                    Console.Write("Kérek egy kort: ");
                    int beKor = int.Parse(Console.ReadLine());
                    eletkorok.Add(beKor);
                    Console.Write("Van tapasztalata (T/F): ");
                    string beTapasztalat = Console.ReadLine();

                    if (beTapasztalat == "T" || beTapasztalat == "t") tapasztalat.Add(true);
                    else tapasztalat.Add(false);
                }
            } while (beNev != "");

            int osszEletkor = 0;
            
            foreach (int item in eletkorok)
            {
                osszEletkor += item;
                
            }
            int atlagEletkor = 0;

            if (eletkorok.Count()>0) atlagEletkor = osszEletkor / eletkorok.Count();

            Console.WriteLine($"Az átlagéletkor: {atlagEletkor}");

            int osszEletkorProgNelkul = 0;
            int dbProgNelkul = 0;

            for (int i = 0; i < nevek.Count; i++)
            {
                if (!tapasztalat[i])
                {
                    osszEletkorProgNelkul += eletkorok[i];
                    dbProgNelkul++;
                }
            }

            int atlagEletKorProgNelkul = 0;
            if (dbProgNelkul>0) atlagEletKorProgNelkul = osszEletkorProgNelkul / dbProgNelkul;

            Console.WriteLine($"A Prog Tapasztalat nélküli átlagéletkor: {atlagEletKorProgNelkul}");

            if (eletkorok.Count() > 0)
            {
                int legidosebbIndex = 0;

                for (int i = 0; i < nevek.Count; i++)
                {
                    if (tapasztalat[i])
                    {
                        if (eletkorok[i] > eletkorok[legidosebbIndex]) legidosebbIndex = i;
                    }
                }

                Console.WriteLine($"A legidősebb {nevek[legidosebbIndex]}, kora: {eletkorok[legidosebbIndex]}.");
            }

            ;



            #endregion


            #region 8. feladat
            Console.Write("N=? ");
            int szamN = int.Parse(Console.ReadLine());

            List<int> szamok = new List<int>();

            szamok.Add(szamN);

            int K = szamok.Last();

            do
            {
                //ha páros -> felét hozzáadjuk
                if (K % 2 == 0) szamok.Add(K / 2);

                //ptlannál ezt adjuk hozzá
                else szamok.Add(3 * K + 1);

                // utolsó elem
                K = szamok.Last();
               
            } while (K != 1);
            #endregion

            

            #region 7. feladat
            // horgászok
            int[,] F = new int[5, 3];
            Random rand = new Random();

            int sum = 0;
            int max = -1;
            int maxId = -1;

            bool nulla = false;

            for (int i = 0; i < F.GetLength(0); i++)
            {
                for (int j = 0; j < F.GetLength(1); j++)
                {
                    F[i, j] = rand.Next(0, 10);
                    Console.Write(F[i, j] + "\t");
                    sum += F[i, j]; 
                }

                Console.WriteLine("ö: "+sum);
                if (sum >max)
                {
                    max = sum;
                    maxId = i;
                }
                if (sum == 0) nulla = true;
                sum = 0;
            }


            Console.WriteLine($"max: {maxId} ");

            if (nulla) Console.WriteLine("Volt olyan aki nem fogott semmit");
            else Console.WriteLine("Mindenki fogott egy halat.");


            #endregion









        }
    }
}
