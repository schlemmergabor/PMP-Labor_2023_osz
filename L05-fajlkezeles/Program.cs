using System.Globalization;

namespace L05_fajlkezeles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. feladat
            // fájl olvasásához létrehozunk egy StreamReader-t
            StreamReader sr = new StreamReader("colorem_ipsum.txt");

            // addig amíg nem érünk a fájl végére...
            while (!sr.EndOfStream)
            {
                // visszaállítjuk a Console színét eredetire
                Console.ForegroundColor = ConsoleColor.White;

                // beolvasunk egy sort
                string sor = sr.ReadLine();

                // feldolgozás
                // feldaraboljuk a sort a # mentén
                string[] data = sor.Split('#');

                // data[0] -> szín
                // data[1] -> text

                // Színbeállításra egy mód:

                // ha a szín piros
                // if (data[0] == "Red") Console.ForegroundColor = ConsoleColor.Red;

                // ha a szín kék
                // if (data[0] == "Blue") Console.ForegroundColor = ConsoleColor.Blue;

                // ha a szín zöld
                // if (data[0] == "Green") Console.ForegroundColor = ConsoleColor.Green;

                // folytatjuk tovább az összes színre, vagy elegánsabban megoldjuk:


                // ConsoleColor Enum -> Parse-oljuk Enummá -> ConsoleColor castolás
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), data[0]);

                // kiírás
                Console.WriteLine(data[1]);

            }
            // lezárod a fájlt
            sr.Close();


            #endregion -----------------------------------------------------------------------------------------


            #region 2. feladat
            // mai dátum egy DateTime típusú változóban
            DateTime datum = DateTime.Now;


            // addig ismétlünk, amíg nem N-t adott meg:
            string valasz = "";
            do
            {
                // kihúzott számok
                int[] nums = new int[5];
                // húzások száma
                int huzasok = 0;

                Random rnd = new Random();

                // amíg nincs meg az 5 kihúzott szám
                while (huzasok < 5)
                {
                    int szam = rnd.Next(1, 91);
                    // ha az új szám még nincs benne
                    if (!nums.Contains(szam))
                    {
                        // hozzáadjuk + huzasok++
                        nums[huzasok] = szam;
                        huzasok++;
                    }
                }

                // kiírandó és fájlba írandó szöveg előállítása
                string kiSzoveg = $"On {datum.ToShortDateString()} numbers were: {nums[0]} {nums[1]} {nums[2]} {nums[3]} {nums[4]}";

                // kiírás
                Console.WriteLine(kiSzoveg);

                // fájlba írás + újsor jel
                File.AppendAllText("huzott.txt", kiSzoveg + '\n');
                // újabb hét generálása
                Console.Write("Another week? [y/n] ");
                valasz = Console.ReadLine();
                // 7-nap hozzáadása az eddigi dátumhoz
                datum = datum.AddDays(7);

                // addig csináljuk amíg Y a válasz
            } while (valasz == "y" || valasz == "Y");
            #endregion -----------------------------------------------------------------------------------------

            #region 4. feladat

            // fájl beolvasása -> összes sor egy tömbbe
            string[] beolvasottSorok = File.ReadAllLines("NHANES_1999-2018.csv");


            // SEQN tömb, hossza - 1, mert a fájl fejlécet tartalmaz
            // az alany egyedi azonosítója (egész)
            int[] SEQN = new int[beolvasottSorok.Length - 1];

            // a felmérés időszaka (szöveg)
            string[] SURVEY = new string[beolvasottSorok.Length - 1];

            //  az alany neme (szám, 1=férfi, 2=nő)
            double[] RIAGENDR = new double[beolvasottSorok.Length - 1];

            // az alany életkora években (szám)
            double[] RIDAGEYR = new double[beolvasottSorok.Length - 1];

            // az alany testtömegindexe (szám)
            double[] BMXBMI = new double[beolvasottSorok.Length - 1];

            // az alany vércukorszintje(szám)
            double[] LBDGLUSI = new double[beolvasottSorok.Length - 1];


            // beolvasottSorok -> többi tömbbe áttöltése
            // 0. index fejrész
            for (int i = 1; i < beolvasottSorok.Length; i++)
            {
                // egy sor feladarabolkása
                string[] eredmeny = beolvasottSorok[i].Split(',');

                // eredmeny[] -> megfelelő tömbbe
                SEQN[i - 1] = int.Parse(eredmeny[0]);
                SURVEY[i - 1] = eredmeny[1];
                // InvariantCulture a . , eltérése miatt kell !
                RIAGENDR[i - 1] = double.Parse(eredmeny[2], CultureInfo.InvariantCulture);
                RIDAGEYR[i - 1] = double.Parse(eredmeny[3], CultureInfo.InvariantCulture);
                BMXBMI[i - 1] = double.Parse(eredmeny[4], CultureInfo.InvariantCulture);
                LBDGLUSI[i - 1] = double.Parse(eredmeny[5], CultureInfo.InvariantCulture);

            }

            // Kérdésekre a válaszok

            // 1. Egy adott felmérésben mennyi volt a nők és a férfiak átlagos testtömegindexe?

            // kiválasztjuk a felmérés "időszakát"
            string felmeres = "1999-2000";

            // a felmérésben a ffiak száma
            int numFFI = 0;

            // a felmérésben a ffiak össz TTI-e
            double sumFFI = 0;

            // a felmérésben a hölgyek száma
            int numNOI = 0;

            // a felmérésben a hölgyek össz TTI-e
            double sumNOI = 0;

            // végig járjuk a BMXBMI tömböt, i-vel indexelve
            for (int i = 0; i < BMXBMI.Length; i++)
            {
                // ha a felmérés megyegyezik és FFI
                if (SURVEY[i] == felmeres && RIAGENDR[i] == 1)
                {
                    numFFI++;
                    sumFFI += BMXBMI[i];

                }

                // ha a felmérés megegyezik és hölgy
                if (SURVEY[i] == felmeres && RIAGENDR[i] == 2)
                {
                    numNOI++;
                    sumNOI += BMXBMI[i];

                }
            }

            // kiírás
            Console.WriteLine($"A {felmeres} időszakban a férfiak átlagos BMI-je: {sumFFI / numFFI}, a hölgyek átlagos BMI-je: {sumNOI / numNOI}.");

            // 2. Egy adott felmérésben az alanyok hány százalékának volt 5.6-nál magasabb a vércukorszintje?

            // a felmérésben az összes résztvevő
            int numOssz = 0;

            // a felmérésben a magasabb vércukorszinttel rendelkezők száma
            int numVC = 0;

            // LBDGLUSI tömböt végigjárjuk i-vel indexelve
            for (int i = 0; i < LBDGLUSI.Length; i++)
            {
                // ha az i. adat a felméréshez tartozik
                if (SURVEY[i] == felmeres)
                {
                    // össz száma megnövelése
                    numOssz++;
                    // és ha nagyobb 5.6-nál, akkor a másik változó megnövelése
                    if (LBDGLUSI[i] > 5.6) numVC++;
                }
            }
            
            // kiírás
            Console.WriteLine($"A {felmeres} időszakban 5.6-nál magasabb vércukorszint százaléka: {(double)numVC/numOssz*100} %.");

            // 3. Egy maximális BMI-vel rendelkező alanynak mennyi a vércukorszintje?

            // a teljes adathalmazra nézzük meg...

            // legnagyobb BMI érték tárolása -> első BMI érték
            double maxBMI = BMXBMI[0];

            // tároljuk is hozzá a VC szintet
            double maxBMIVc = LBDGLUSI[0];

            // keressük meg a legnagyobb BMI értéket
            for (int i = 0; i < BMXBMI.Length; i++)
            {
                // ha nagyobb az i. BMI, mint az eddigi MAX
                if (BMXBMI[i]> maxBMI)
                {
                    // i értéke legyen az új MAX
                    maxBMI = BMXBMI[i];
                    // és a VC szintje is
                    maxBMIVc = LBDGLUSI[i];
                }
            }

            Console.WriteLine($"Egy max BMI-s ({maxBMI}) alany vércukorszintje: {maxBMIVc}.");

            // 4. A teljes adathalmazban mi a túlsúlyos (legalább 30.0-as BMI) személyek átlagos életkora?

            // túlsúlyosok össz életkora
            double tulsulyosOsszKor = 0;

            // túlsúlyosak száma
            int tulsulyosSzama = 0;

            for (int i = 0; i < BMXBMI.Length; i++)
            {
                // ha túlsúlyos, akkor...
                if (BMXBMI[i]>30.0)
                {
                    tulsulyosOsszKor += RIDAGEYR[i];
                    tulsulyosSzama++;
                }
            }

            Console.WriteLine($"A teljes adathalmazban a túlsúlyosak átlagéletkora: {tulsulyosOsszKor/tulsulyosSzama}.");


            #endregion -----------------------------------------------------------------------------------------

        }
    }
}