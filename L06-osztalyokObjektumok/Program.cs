namespace L06_osztalyokObjektumok
{

    internal class Program
    {
        static void Main(string[] args)
        {

            #region 1. feladat
            // Book osztályból k1 néven példány, objektum létrehozása
            Book k1 = new Book("szerző1", "cím1", 1999, 200);

            // k1 objektum AllData() kiírása
            Console.WriteLine(k1.AllData());
            #endregion -----------------------------------------------------------------------------------------
            /*
            #region 3. feladat
            // két runner osztálybeli példány
            Runner r1 = new Runner("Alma", 2, 4);
            Runner r2 = new Runner("Körte", 5, 3);

            // cél pozi
            int cel = 30;

            // amíg mindkettő a cél előtt van...
            while (r2.GetDistance() <= cel && r1.GetDistance() <= cel)
            {
                // Console törlés
                Console.Clear();
                // távolság frissítés
                r1.RefreshDistance(1);
                r2.RefreshDistance(1);
                // kirajzolás
                r1.Show();
                r2.Show();
                // 1 mp várás
                System.Threading.Thread.Sleep(1000);

            }
            #endregion -----------------------------------------------------------------------------------------
            */

            #region 4. feladat
            Titkositas t = new Titkositas(3);
            string titkos = t.Encode("hello world!");

            Console.WriteLine(titkos);

            string megfejtett = t.Decode(titkos);
            Console.WriteLine(megfejtett);

            #endregion -----------------------------------------------------------------------------------------


        }
    }
}