using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10_KomplexFeladat
{
    internal class Buffalo
    {
        int x;
        int y;

        bool aktiv;

        public int X { get => x; }
        public int Y { get => y; }

        public Buffalo()
        {
            this.x = 0;
            this.y = 0;
            this.aktiv = true;
        }

        public void Move(Field f)
        {
            bool[] hova = new bool[3];
            hova[0] = f.AllowedPosition(X + 1, Y);
            hova[1] = f.AllowedPosition(X, Y + 1);
            hova[2] = f.AllowedPosition(X + 1, Y + 1);

            Random rnd = new Random();
            int szam;
            do
            {
                szam = rnd.Next(0, 3);
            }
            while (!hova[szam]);

            if (szam == 0) x++;
            if (szam == 1) y++;
            if (szam == 2) { x++; y++; }
        }
        public void Deactivate()
        {
            this.aktiv = false;
        }

        public void Show()
        {
            Console.SetCursorPosition(x, y);
            if (this.aktiv) 
                Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("B");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
