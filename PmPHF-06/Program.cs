namespace PmPHF_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // beolvasuk a sort a Consoleról
            string sor = Console.ReadLine();

            // felbaraboljuk -> eredmény egy tömb
            string[] darab = sor.Split(',');

            // számokként fogom tárolni, úgyhogy csinálok egy
            // int tömböt, hossza a darabolt tömb hossza
            int[] dbi = new int[darab.Length];

            // átmásolom a string tömbből int tömbbe
            for (int j = 0; j < darab.Length; j++)
            {
                dbi[j] = int.Parse(darab[j]);
            }

            int cserekSzama = 0;
            
            // elölről fogom nézni az indexeket
            // a tömb első indexe a 0
            int i = 0;

            // amíg nem értem a tömb végére az indexel
            while (i<dbi.Length-1)
            {
                // ha a indexen 0 van -> ok -> jöhet a következő index
                if (dbi[i] == 0) i++;

                // ha 1-es van, akkor kell "dolgozni"
                if (dbi[i]==1)
                {
                    // az aktuális (i) index után van-e 0 ?
                    bool van = false;
                    // hátrébb indexeket megnézem
                    for (int j = i+1; j < dbi.Length; j++)
                    {
                        if (dbi[j] == 0) van=true;
                    }
                    // ha van még hátrébb nulla, akkor csere van!

                    if (van)
                    {
                        // hátulról az utolsó 0 indexének megkeresése
                        int x = dbi.Length - 1;
                        while (dbi[x] != 0) x--;


                        // csere
                        int temp = dbi[x];
                        dbi[x] = dbi[i];
                        dbi[i] = temp;
                        cserekSzama++;
                    }
                    // ha hátrébb már mind 1-es van, akkor index léptetése
                    else i++;
                    
                }
                
            }

            // eredmény kiírása
            Console.WriteLine(cserekSzama);
            
        }
    }
}