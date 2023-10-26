namespace L07_Property
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("N=? ");
            int N = int.Parse(Console.ReadLine());

            // tömb létrehozása, ekkor még az indexek üresek
            ExamResult[] eredmények = new ExamResult[N];

            // tömb feltöltése -> indexek példányosítása
            for (int i = 0; i < eredmények.Length; i++)
            {
                eredmények[i] = new ExamResult();
            }

            // ponthatár teszteléshez
            int[] ph = { 0, 50, 62, 74, 86 };

            Console.WriteLine($"{eredmények[0].PontSzam} pont - {eredmények[0].Grade(ph)}");

            Console.WriteLine();
            // sum psz
            int sum = 0;

            // max psz
            int maxPsz = 0;
            // max psz neptunkodja
            string maxNK = "";

            // sikeres dolgozatok
            foreach (ExamResult item in eredmények)
            {
                if (item.Passed) Console.WriteLine($"{item.NeptunKod} - {item.PontSzam}");
                sum += item.PontSzam;
                if (item.PontSzam > maxPsz)
                {
                    maxPsz = item.PontSzam;
                    maxNK = item.NeptunKod;
                }
            }
            Console.WriteLine($"\nÁtlagos pontszám: {(double)sum/eredmények.Length}");
            Console.WriteLine($"Max pontszámos neptunkód: {maxNK}");

        }
    }
}