using System.Security;

namespace PmPHF_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // négyzet mérete
            int meret = int.Parse(Console.ReadLine());
            // létrehozzuk üresen a négyzetet
            int[,] negyzet = new int[meret, meret];

            // sorok összegét ebben a tömbben tároljuk meg
            int[] sorokÖsszege = new int[meret];
            // oszlopok összegét ebben tároljuk majd
            int[] oszlopokÖsszege = new int[meret];

            // két átló összege
            int átlóÖsszeg1 = 0;
            int átlóÖsszeg2 = 0;

            // négyzet beolvasása és feltöltése
            for (int i = 0; i < meret; i++)
            {
                // sorok összegének számításához változó
                int sum = 0;
                for (int j = 0; j < meret; j++)
                {
                    int akt = int.Parse(Console.ReadLine());
                    negyzet[i, j] = akt;
                    // sor összeg-hez hozzáadjuk az aktuális elemet
                    sum += akt;
                }
                // tömbbe elmentjük az összeget
                sorokÖsszege[i] = sum;

            }

            // oszlopok összegének számításához ciklus
            for (int i = 0; i < oszlopokÖsszege.Length; i++)
            {
                // oszlopösszeg segédváltozó
                int sum = 0;
                for (int j = 0; j < negyzet.GetLength(1); j++)
                {
                    sum += negyzet[j, i];
                }
                oszlopokÖsszege[i] = sum;
            }

            // egyik átló összegének számítása            
            for (int i = 0; i < negyzet.GetLength(0); i++)
            {
                // mindkét index 1-el nő az iterációkban
                átlóÖsszeg1 += negyzet[i, i];
            }
            

            // másik átló összegének számítása

                       
            // i indexet 1-el növeljük
            // j indexet 1-el csökkentjük
            // az egyes iterációk során
            int jAtlo = meret - 1;
            for (int i = 0; i < negyzet.GetLength(0); i++)
            {
                átlóÖsszeg2 += negyzet[i, jAtlo];
                jAtlo--;   
            }

            // kiíratás és ellenőrzés, hogy bűvös négyzet-e?

            // első összeg elmentése
            int összeg = sorokÖsszege[0];
            // feltételezzük, hogy bűvös a négyzet
            bool bűvösE = true;

            // sorok összegének kiírása
            for (int i = 0; i < sorokÖsszege.Length; i++)
            {
                Console.Write(sorokÖsszege[i]+",");
                // ha nem egyezik meg az összeg, akkor biztos, hogy nem bűvös
                if (összeg != sorokÖsszege[i]) bűvösE = false;
                
            }

            // oszlopok öszsegének kiírása
            for (int i = 0; i < oszlopokÖsszege.Length; i++)
            {
                Console.Write(oszlopokÖsszege[i]+",");
                // ha nem egyezik meg az összeg, akkor biztos, hogy nem bűvös
                if (összeg != oszlopokÖsszege[i]) bűvösE = false;
            }

            // átlók összegének kiírása + ellenőrzés
            Console.Write(átlóÖsszeg1+",");
            if (összeg != átlóÖsszeg1) bűvösE = false;
            Console.Write(átlóÖsszeg2+",");
            if (összeg != átlóÖsszeg2) bűvösE = false;


            // Y / N kiírása
            if (bűvösE) Console.WriteLine("Y");
            else Console.WriteLine("N");


        }
    }
}