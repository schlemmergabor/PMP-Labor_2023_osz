using System;

namespace L01_valtozok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. feladat
            // Console.WriteLine(); <- kiírás után új sor
            // Console.Write(); <- kiírás után nincs új sor
            Console.WriteLine("Hello World!");
            #endregion

            #region 2. feladat

            // letörli a Console ablakot
            Console.Clear();

            // beállítja a Console ablak magasságát
            Console.WindowHeight = 5;

            // beállítja a Console ablak szélességét
            Console.WindowWidth = 30;

            // beállítja a Console háttérszínét - fehérre
            Console.BackgroundColor = ConsoleColor.White;

            // beállítja a Console írószínét - feketére
            Console.ForegroundColor = ConsoleColor.Black;

            // A kurzort a 2, 3 poz-ba állítja
            Console.SetCursorPosition(2, 3);

            // A kurzor láthatóságát állítja
            // default: true (látható)
            Console.CursorVisible = false;

            #endregion

            // visszaállítjuk a Console színeit, előző beállításai
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = true;
            Console.SetWindowSize(80, 25);


            #region 3. feladat
            Console.Write("Kérem a neved: ");
            string nev = Console.ReadLine();
            Console.WriteLine($"Szia kedves {nev}!");
            #endregion


            #region 4. feladat
            Console.Write("Születési éved: ");
            int szuletesiEv = int.Parse(Console.ReadLine());
            int kor = 2023 - szuletesiEv;
            Console.WriteLine("A felhasználó kora: {0}",kor);
            Console.WriteLine("A következő évben "+ (kor + 1) + " éves leszel.");
            #endregion

            #region 5. feladat
            Console.Write("Testmagasság [m]: ");
            double magassag = double.Parse(Console.ReadLine());

            Console.Write("Testtömeg [kg]: ");
            double tomeg = double.Parse(Console.ReadLine());

            double BMI = tomeg / (magassag * magassag);

            Console.WriteLine($"A BMI értéke: {BMI}");


            #endregion

            #region 6. feladat
            Console.Write("Az időtartam másodpercben: ");
            int mp = int.Parse(Console.ReadLine());
            int kiP = mp / 60;
            int kiMp = mp % 60;
            if (kiMp < 10)
            {
                Console.WriteLine($"Az időtartam formázva: {kiP}:0{kiMp}");
            }
            else
            {
                Console.WriteLine($"Az időtartam formázva: {kiP}:{kiMp}");
            }
            #endregion
            
            #region 7. feladat
            
            Console.WriteLine("*** Az első cím");
            Console.Write("  címe: ");
            string cim1 = Console.ReadLine();
            Console.Write("  távolsága [km]: ");
            double tav1 = double.Parse(Console.ReadLine());
            Console.Write("  sebessége [km/h]: ");
            double seb1 = double.Parse(Console.ReadLine());

            double ido1 = tav1 / seb1;
            
            Console.WriteLine("*** A második cím");
            Console.Write("  címe: ");
            string cim12 = Console.ReadLine();
            Console.Write("  távolsága [km]: ");
            double tav2 = double.Parse(Console.ReadLine());
            Console.Write("  sebessége [km/h]: ");
            double seb2 = double.Parse(Console.ReadLine());

            double ido2 = tav2 / seb2;

            Console.WriteLine("*** A harmadik cím");
            Console.Write("  címe: ");
            string cim3 = Console.ReadLine();
            Console.Write("  távolsága [km]: ");
            double tav3 = double.Parse(Console.ReadLine());
            Console.Write("  sebessége [km/h]: ");
            double seb3 = double.Parse(Console.ReadLine());

            double ido3 = tav3 / seb3;

            Console.WriteLine();
            Console.WriteLine($"Az első címre {ido1} óra odaérni,\n" +
                $"Ezután a második címre {ido2} óra múlva ér oda,\n" +
                $"majd a harmadik címre {ido3} óra múlva ér oda.");

            double atlagido = (ido1 + ido2 + ido3) / 3;
            double atlagseb = (tav1 + tav2 + tav3) / (ido1 + ido2 + ido3);

            Console.WriteLine($"Egy csomag kiszállítási átlagideje: {atlagido}\n" +
                $"A teljes nap átlagsebessége: {atlagseb}.");

            #endregion
            
            #region 8. feladat 
            string pw = "NeumannKar2023";
            
            

            Console.Write("Kérem a jelszót: ");
            string bePw = Console.ReadLine();
            if (bePw == pw)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Belépés sikeres");
            }
            else
            {
                // "csúnyán" opcionális 3x próbálkozással
                Console.Write("Kérem a jelszót: ");
                bePw = Console.ReadLine();
                if (bePw == pw)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Belépés sikeres");
                }
                else
                {
                    Console.Write("Kérem a jelszót: ");
                    bePw = Console.ReadLine();
                    if (bePw == pw)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine("Belépés sikeres");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Belépés megtagadva");
                    }
                }
            }
            #endregion
            
            #region 9. feladat
            Console.Write("Add meg az első számot: ");
            int szamA = int.Parse(Console.ReadLine());
            Console.Write("Add meg a második számot: ");
            int szamB = int.Parse(Console.ReadLine());
            Console.Write("Add meg a műveletet: ");
            string muv = Console.ReadLine();

            int eredmeny = 0;

            if (muv == "+") eredmeny = szamA + szamB;
            if (muv == "-") eredmeny = szamA - szamB;
            if (muv == "/") eredmeny = szamA / szamB;
            if (muv == "*") eredmeny = szamA * szamB;

            Console.WriteLine($"{szamA} {muv} {szamB} = {eredmeny}");

            #endregion

            

            Console.ReadLine();
        }
    }
}