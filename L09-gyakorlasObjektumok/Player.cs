using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L09_gyakorlasObjektumok
{
    enum Position
    {
        Kapus,
        Védő,
        Center,
        Támadó
    }
    internal class Player
    {
        string nev;
        Position pos;

        public Player(string nev, Position pos)
        {
            this.nev = nev;
            this.pos = pos;
        }

        internal Position Pos { get => pos; set => pos = value; }

        public override string? ToString()
        {
            return $"{nev} - {pos}";
        }
    }
}
