namespace L08_ertekReferencia
{
    internal class Program
    {
        // érték szerinti paraméter átadás
        // int, bool, double, stb.
        static void Dupla(int a)
        {
            // a paraméter értéke lemásolódik
            // itt a másolattal dolgozol

            a = a * 2;
        }

        // referencia szerinti paraméter átadás
        // ref vagy out kulcsszó
        static void Dupla(ref int a)
        {
            // a paraméterre mutató referenciával (mutató) dolgozol
            // átadott eredeti érték is változik
            a = a * 2;
        }


        // tömbök, string, objektumok esetében
        // kulcsszó nélkül is ref. szerinti paraméter átadás van

        // nincs ref
        static void TömbNulláz(int[] a)
        {
            // de mégis kinullázzuk a 0. indexű elemet
            a[0] = 0;
        }
        static void Main(string[] args)
        {
            int b = 10;
            // érték szerinti paraméter meghívás
            Dupla(b);
            // kimenet 10 lesz
            Console.WriteLine(b);

            // referencia szerinti paraméter meghívás
            Dupla(ref b);

            // kimenet 20 lesz
            Console.WriteLine(b);


            // kezdeti tömb
            int[] tömb = { 1, 2, 3 };
            // metódus meghívása
            TömbNulláz(tömb);

            // kimenet 0 lesz
            Console.WriteLine(tömb[0]);

        }
    }
}