namespace ZH00_mintaZH2
{
   
    internal class Program
    {
      
        static void Main(string[] args)
        {
            Album a = new Album("Taylor Swift", "Midnights", @"..\..\..\taylor_swift-midnights.txt");
            
            Console.WriteLine(a.AlbumStatisztika());
            ;

        }
    }
}