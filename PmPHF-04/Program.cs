namespace PmPHF_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // bemeneti, kódolt szöveg
            string E = Console.ReadLine();

            // kimeneti string
            string ki = "";

            // ha a hossza > 1 -- második karakterek válogatása
            if (E.Length > 1)
            {
                string seged = "";
                // masodik karakterek kiválogatása
                for (int i = 0; i < E.Length; i++)
                {
                    // masodik karakterek egy segéd változóba
                    if (i % 2 != 0) seged += E[i];

                }

                // segéd üzenet indexeléséhez
                int j = E.Length / 2 - 1;

                // új üzenet összeállítása
                for (int i = 0; i < E.Length; i++)
                {
                    // eredeti üzenetből
                    if (i % 2 == 0) ki += E[i];
                    // fordított sorrendben
                    else ki += seged[j--];
                }
            }
            else
                ki = E;

            // ha a hossza > 2 -- harmadik karakterek feldolgozása
            if (ki.Length > 2)
            {
                // harmadik karakterek kiválogatása
                string seged = "";
                for (int i = 0; i < ki.Length; i++)
                {
                    if ((i + 1) % 3 == 0) seged += ki[i];
                }
                // balra eltolás -> 
                string seged2 = seged.Substring(1);
                // első karakter a végére
                seged2 += seged[0];

                // seged2-höz index
                int j = 0;

                string ki2 = "";
                // eredmény összeállítása
                for (int i = 0; i < ki.Length; i++)
                {
                    // harmadik karakter az új változat
                    if ((i + 1) % 3 == 0) ki2 += seged2[j++];
                    // minden más eredeti
                    else ki2 += ki[i];
                }

                ki = ki2;
            }

            // negyedik karakterek válogatása - feldolgozása
            if (ki.Length > 3)
            {
                string seged = "";
                for (int i = 0; i < ki.Length; i++)
                {
                    if ((i + 1) % 4 == 0) seged += ki[i];
                }

                // jobbra léptetéshez segédváltozó
                string seged2 = "";
                // utolsó karakter előre
                seged2 += seged[seged.Length - 1];
                // többi karakter hozzámásolása
                seged2 += seged.Substring(0, seged.Length - 1);

                // seged2-höz index
                int j = 0;

                string ki2 = "";
                // eredmény összeállítása
                for (int i = 0; i < ki.Length; i++)
                {
                    if ((i + 1) % 4 == 0) ki2 += seged2[j++];
                    else ki2 += ki[i];
                }

                ki = ki2;

            }

            // szavak száma
            string[] szavak = ki.Split(' ');

            // szóközök eltávolítása
            ki = ki.Replace(" ", "");

            // segédváltozó -> ide szúrtuk a legutolsó szóközt
            int hova = 0;

            // szavak tömb fordított bejárása
            for (int i = szavak.Length - 1; i > 0; i--)
            {
                // szóközt beszúrjuk
                ki = ki.Insert(szavak[i].Length + hova, " ");
                // hova szúrtuk frissítése, +1 a " " miatt
                hova = szavak[i].Length + 1;
            }

            // kimenet kiírása
            Console.WriteLine(ki);
        }
    }
}