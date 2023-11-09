using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L09_gyakorlasObjektumok
{
    internal class Team
    {
        // mezők, adattagok, belső változók
        Player[] players;
        int numberOfPlayers;

        // const -> kezdőértékek
        public Team()
        {
            numberOfPlayers = 0;
            // tömb kezdeti méretét megcsináljuk -> 0
            players = new Player[numberOfPlayers];
        }

        // property VS-ből generálva
        public int NumberOfPlayers { get => numberOfPlayers; set => numberOfPlayers = value; }

        // metódusok
        public bool IsFull()
        {
            // ha a numofP értéke 6
            if (numberOfPlayers == 6) return true;
            return false;
        }

        // benne van-e már a játékos
        public bool IsIncluded(Player player)
        {
            // eldöntés tételével szépen megoldva
            // lásd: https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf
            // 2.2. algoritmus -> 25. oldal

            int i = 0; // tömb első indexe

            // amíg nem értünk a tömb végére
            // P -> player megegyezik az i. elemmel
            // numberOfPlayers - 1, mert 0-tól indexeljük a tömböt
            while (i <= numberOfPlayers - 1 && !(players[i] == player))
            {
                i++;
            }

            // egyből eldönti a feltételt, azaz azt, hogy
            // i <= numberOfPlayers - 1; -> true / false
            // és elmenti a változóba
            bool benneVanE = i <= numberOfPlayers - 1;

            return benneVanE;


        }

        // van-e szabad pozició a player.Pos-án?
        public bool IsAvailable(Player player)
        {
            // csapatban a szabad poziciók kezdőszáma
            //  1 kapus, 1 védő, 2 center és 2 támadó
            // Enumban is ilyen sorrendben vannak
            int[] nums = new int[] { 1, 1, 2, 2 };

            // végig nézzük az összes játákos
            foreach (Player item in players)
            {
                // az adott játékos Pozicját számmá alakítjuk
                // kapus=0, védő=1, center=2, támadó=3
                int pos = (int)item.Pos;
                // ezzek indexeljük a tömböt
                // maradék szabad helyekből 1-t levonunk
                nums[pos]--;
            }

            // itt a nums tömbben az van benne, hogy menni
            // szabad hely van az egyes pozikon

            // ha a player paraméret Pos -án még van hely...
            if (nums[(int)player.Pos] > 0) return true;
            else return false;

        }

        // játékos hozzáadása
        public void Include(Player player)
        {
            // ha nincs még benne és elérhető a Pos-a, akkor
            if ((!IsIncluded(player)) && IsAvailable(player))
            {
                // átmeneti új tömb 1-el nagyobb
                Player[] ujtomb = new Player[this.players.Length + 1];

                // átmásoljuk az értékeket
                for (int i = 0; i < this.players.Length; i++)
                {
                    ujtomb[i] = this.players[i];
                }

                // az utolsó helyre betesszük az új játékos
                // 0-tól indexelési miatt ez jó lesz
                ujtomb[numberOfPlayers] = player;

                // játékosok számát megnöveljük
                numberOfPlayers++;
                
                // belső tároló tömböt felülírju
                this.players = ujtomb;
            }


        }
    }
}
