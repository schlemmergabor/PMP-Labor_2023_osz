using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10_KomplexFeladat
{
    internal class Field
    {
        // játéktér mérete
        int M;

        // construktor
        public Field(int m)
        {
            M = m;
        }

        // Tulajdonságok -> 0,0-tól indulunk
        public int TargetX
        {
            get { return M - 1; }
        }

        public int TargetY
        { 
            get { return M - 1; }
        }

        // Léphet-e a bölény X, Y-ra?
        public bool AllowedPosition(int X, int Y)
        {
            // léphet, ha még a játéktéren belül van
            // 
            return X<=TargetX && Y<=TargetY;
        }

        // játétér kirajzolása
        public void Show()
        {
            // ablak 0,0 pozijába
            Console.SetCursorPosition(0, 0);

            // első sor
            for (int i = 0; i < M; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            // "köztes" sorok
            for (int i = 1; i < M-1; i++)
            {
                Console.Write("|");
                // szóközök -> "letisztítja" a pályát
                for (int j = 1; j < M-1; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
            // utolsó sor
            for (int i = 0; i < M; i++)
            {
                Console.Write("-");
            }
        }

    }
}
