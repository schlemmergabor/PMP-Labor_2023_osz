namespace L09_gyakorlasObjektumok
{
    internal class Program
    {
        static Player[] RandomPlayers(int a)
        {
            // tömb méretének lefoglalása
            Player[] players = new Player[a];

            Random rnd = new Random();
            
            // tömb feltöltése
            for (int i = 0; i <players.Length; i++)
            {
                // véletlenszerű játékosnév
                string nev = "P-"+(char)rnd.Next((int)'A', (int)'Z') + (char)rnd.Next((int)'A', (int)'Z'); ;
                
                // Pozi enum-ba
                Position pos = (Position)Enum.Parse(typeof(Position), rnd.Next(0,4).ToString());
                
                // tömb elemre létrehozás
                players[i] = new Player(nev, pos);
            }
            
            // elkészült tömb visszaadása
            return players;
        }
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

            // random playerek
            Player[] velJatekosok = RandomPlayers(100);

            // új csapat
            Team magyar = new Team();


            // a random playerekből beletesszük a csapatba
            int i = 0;
            while (!magyar.IsFull())
            {
                magyar.Include(velJatekosok[i++]);
            }

           
            

            #endregion -----------------------------------

        }
    }
}