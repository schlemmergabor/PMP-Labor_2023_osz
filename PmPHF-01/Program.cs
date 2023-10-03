namespace PmPHF_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int A = int.Parse(Console.ReadLine());

            int B = int.Parse(Console.ReadLine());

            int C = int.Parse(Console.ReadLine());

            if (A >= B && A >= C)
            {
                Console.WriteLine(A);
            }

            else if (B >= A && B >= C)
            {
                Console.WriteLine(B);
            }

            else if (C >= A && C >= B)
            {
                Console.WriteLine(C);
            }



        }
    }
}