using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10_KomplexFeladat
{
    internal class Game
    {
        Field f;
        Buffalo[] bfs;

        public Game(int jatekterMerete, int bolenyekSzama)
        {

            f = new Field(jatekterMerete);

            // bölények
            bfs = new Buffalo[bolenyekSzama];
            for (int i = 0; i < bfs.Length; i++)
            {
                bfs[i] = new Buffalo();
            }
        }

        public bool IsOver
        {
            get
            {
                bool vege = false;
                // bölény célbe ért

                // bölények mind megdieoltak

                return vege;
            }
        }

        public void VisualizeElements()
        {
            // játéktér megjelenítése
            f.Show();
            // buffalok megjelenítése
            foreach (Buffalo item in bfs)
            {
                item.Move(f); // mozgatás
                item.Show();
            }
        }

        private void Shoot()
        {
            Console.SetCursorPosition(0, 20);
            Console.Write("X=? ");
            int X = int.Parse(Console.ReadLine());

            Console.Write("Y=? ");
            int Y = int.Parse(Console.ReadLine());

            // x,y deaktiválni

            foreach (Buffalo item in bfs)
            {
                // ha az X,Y-on van az item
                if (item.X == X && item.Y == Y)
                {
                    // deaktiválás -> eltaláltam
                    item.Deactivate();
                }
            }

        }
        public void Run()
        {
            // amíg megy a játék
            while (!IsOver) // ez hiányzik
            {
                // kirajzol
                VisualizeElements();
                // lövés
                Shoot();
            }

        }

    }
}
