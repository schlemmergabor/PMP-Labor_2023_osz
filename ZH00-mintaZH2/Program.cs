namespace ZH00_mintaZH2
{
   
    internal class Program
    {
      
        static void Main(string[] args)
        {
            // Album objektum létrehozása
            Album a = new Album("Taylor Swift", "Midnights", @"..\..\..\taylor_swift-midnights.txt");
            
            // Albumstatisztika metódus meghívása
            Console.WriteLine(a.AlbumStatisztika());
            ;

        }
    }
}