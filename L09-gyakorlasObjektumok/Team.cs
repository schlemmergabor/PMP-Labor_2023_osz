using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L09_gyakorlasObjektumok
{
    internal class Team
    {
        Player[] players;
        int numberOfPlayers;

        public Team()
        {
            numberOfPlayers = 0;
            players = new Player[numberOfPlayers];
        }

        public int NumberOfPlayers { get => numberOfPlayers; set => numberOfPlayers = value; }

        public bool IsFull()
        {
            if (numberOfPlayers == 6) return true;
            return false;
        }

        public bool IsIncluded(Player player)
        {
            return false;
        }

        public bool IsAvailable(Player player)
        {
            return false;
        }

        public void Include(Player player)
        {
            Player[] ujtomb = new Player[players.Length + 1];

            for (int i = 0; i < players.Length; i++)
            {
                ujtomb[i] = players[i];
            }
            ujtomb[numberOfPlayers] = player;
            numberOfPlayers++;
            players = ujtomb;

        }
    }
}
