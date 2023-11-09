namespace L09_gyakorlasObjektumok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region saját feladat
            // Munkavallalokhoz tömb
            Munkavallalo[] emberek = new Munkavallalo[3];
            
            // Konkrét munkavállalók létrehozása
            emberek[0] = new Munkavallalo("első", 1, 10);
            emberek[1] = new Munkavallalo("második", 2, 15);
            emberek[2] = new Munkavallalo("harmadik", 3, 0);

            // Részleg létrehozása
            Reszleg IT = new Reszleg("IT", emberek);

            // Tesztelés
            Console.WriteLine($"Az össz szabadságok száma: {IT.KivehetoSzabik()}");
            if (IT.NincsSzabi()) Console.WriteLine("Van olyan munkavállaló akinek nincs szabadsága.");
            else Console.WriteLine("Minden munkavállalónak van szabadsága.");

            #endregion -----------------------------------
            #region Kispályás focicsapat

            Player p1 = new Player("A", Position.Center);
            Player p2 = new Player("B", Position.Kapus);

            Team magyar = new Team();
            magyar.Include(p1);
            //magyar.Include(p2);
            Console.WriteLine(magyar.IsAvailable(p1));
            Console.WriteLine(magyar.NumberOfPlayers);
            ;

            #endregion -----------------------------------

        }
    }
}