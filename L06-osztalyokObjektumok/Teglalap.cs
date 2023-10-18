using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_osztalyokObjektumok
{
    internal class Teglalap
    {
        int szelesseg;
        int magassag;

        ConsoleColor szin;

        public Teglalap(int szelesseg, int magassag, ConsoleColor szin)
        {
            this.szelesseg = szelesseg;
            this.magassag = magassag;
            this.szin = szin;
        }

        private int Area()
        {
            return szelesseg * magassag;
        }

        public bool IsValid()
        {
            // ternary operatorral
            return Area() > 0 ? true : false;
        }

        public void Draw(int x, int y)
        {
            Console.ForegroundColor = this.szin;

            // magassag x ismeteljuk
            for (int j = x  ; j < (x+magassag); j++)
            {
                // jo pozira allunk
                // x -> left
                // j -> top értéke
                Console.SetCursorPosition(x, j);

                // szélességnyi x
                for (int i = 0; i < szelesseg; i++)
                {
                    Console.Write("x");
                }
            }
          

        }
    }
}
