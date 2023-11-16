namespace L10_KomplexFeladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("N=? ");
            int N = int.Parse(Console.ReadLine());

            Console.Write("M=? ");
            int M = int.Parse(Console.ReadLine());

            Game g = new Game(M, N);
            g.Run();
          
        }
    }
}