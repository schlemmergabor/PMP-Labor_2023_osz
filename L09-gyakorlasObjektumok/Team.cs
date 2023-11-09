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
            bool benneVanE = false;
            foreach (Player item in players)
            {
                if (item == player)
                    benneVanE = true;

            }
            return benneVanE;
        }

        public bool IsAvailable(Player player)
        {
            Position p = player.Pos;
            // csapat poziciók számolása
            int[] nums = new int[] { 1, 1, 2, 2 };
            foreach (Player item in players)
            {
                int pos = (int)item.Pos;
                nums[pos]--;
            }

            if (nums[(int)p] > 0) return true;
            else return false;

        }

        public void Include(Player player)
        {
            if ((!IsIncluded(player)) && IsAvailable(player))
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
}
