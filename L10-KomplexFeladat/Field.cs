using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10_KomplexFeladat
{
    internal class Field
    {
        int M;

        public Field(int m)
        {
            M = m;
        }

        public int TargetX
        {
            get { return M - 1; }
        }

        public int TargetY
        { 
            get { return M - 1; }
        }
        public bool AllowedPosition(int X, int Y)
        {
            return X<=TargetX && Y<=TargetY;
        }
        public void Show()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < M; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            for (int i = 1; i < M-1; i++)
            {
                Console.Write("|");
                for (int j = 1; j < M-1; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
            
            for (int i = 0; i < M; i++)
            {
                Console.Write("-");
            }
        }

    }
}
