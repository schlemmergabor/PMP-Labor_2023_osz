namespace L03_tomb_lista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            #region 1. feladat
            string[] szinek = { "Kör", "Káró", "Treff", "Pik"};

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

                    kartyak[lapszam++] = szinek[i]+" "+magasságok[j];
                   
                }
            }

            // Ellenőrzés

            foreach (string item in kartyak)
            {
                Console.Write(item+"\t");
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
                Console.Write($"Kérem az {i+1}. szót: ");
                szavak[i] = Console.ReadLine();
            }

            Console.Write("Kérek egy szót: ");
            string be = Console.ReadLine();

           
          




            // hanyadik indexen van
            int holVan = -1;
            
            // lépekni tömb elemein
            int ind = 0;

            while (holVan == -1 && ind < szavak.Length)
            {
                if (szavak[ind] == be) holVan = ind;
                ind++;
            }
            
            Console.WriteLine(ind);


            #endregion

            */
            #region 4. feladat
            List<string> szoLista = new List<string>();

            string beSzo = "";
            do
            {
                Console.Write("Kérek egy szót: ");
                
                beSzo = Console.ReadLine();
                szoLista.Add(beSzo);
            } while (beSzo != "STOP");
            Console.Write("Szó: ");
            string bekertSzo = Console.ReadLine();

            int szoIndex = szoLista.IndexOf(bekertSzo);
            if (szoIndex > -1) Console.WriteLine($"A szó benne van a listában az {szoIndex} indexen.");
            else Console.WriteLine("A szó nincs benne a listában.");
            #endregion

            



        }
    }
}