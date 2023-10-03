namespace PmPHF_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            string C = Console.ReadLine();

            for (int i = 0; i < N; i++)
            {
                Console.Write(C);
            }

            Console.WriteLine();
            if (N > 1)
            {
                for (int i = 1; i < N - 1; i++)
                {
                    Console.Write(C);
                    for (int j = 1; j < N - 1; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine(C);

                }
                for (int i = 0; i < N; i++)
                {
                    Console.Write(C);
                }
            }




        }
    }
}