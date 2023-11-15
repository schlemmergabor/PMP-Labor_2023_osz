using Microsoft.Win32;
using System.Collections.Specialized;

namespace PmPHF_05
{
    internal class Program
    {
        enum Reg
        {
            A=0,
            B,
            C,
            D
        }
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines(@"..\..\..\input.txt");

            int[] regiszterek = {0,0,0,0 };

            // regiszterek beállítása
            string[] darabok = sorok[0].Split(',');

            for (int j = 0; j < regiszterek.Length; j++)
            {
                regiszterek[j] = int.Parse(darabok[j]);
            }
            ;

            // utasítások feldolgozása

            for (int i = 1; i < sorok.Length; i++)
            {


                // aktuális utasítás "sor"
                string sor = sorok[i];

                string[] sorDb = sor.Split(' ');
                string muvelet = sorDb[0];

                string DEST = sorDb[1];
                // melyik indexbe fogjuk írni
                int iDEST = (int)Enum.Parse(typeof(Reg), DEST);

                int iSRC=0;
                int iSRC2=0;

                if (muvelet!="MOV")
                {
                    

                    // SRC értéke
                    string SRC = sorDb[2];

                    

                    // szám-e? ha igen értéke iSRC-be
                    bool isNumber = int.TryParse(SRC, out iSRC);

                    // regiszterből kiszedjük az értékét
                    if (!isNumber)
                    {
                        int regIndex = (int)Enum.Parse(typeof(Reg), SRC);
                        iSRC = regiszterek[regIndex];
                    }

                    string SRC2 = sorDb[3];
                

                    // szám-e? ha igen értéke iSRC-be
                    bool isNumber2 = int.TryParse(SRC2, out iSRC2);

                    // regiszterből kiszedjük az értékét
                    if (!isNumber2)
                    {
                        int regIndex2 = (int)Enum.Parse(typeof(Reg), SRC2);
                        iSRC2 = regiszterek[regIndex2];
                    }
                }
                





                switch (muvelet) {
                    case "MOV":
                        int icel = (int)Enum.Parse(typeof(Reg), sorDb[2]);
                        regiszterek[iDEST] = regiszterek[icel];
                        break;
                    case "ADD":
                        regiszterek[iDEST] = iSRC + iSRC2;
                        break;
                    case "SUB":
                        regiszterek[iDEST] = iSRC - iSRC2;
                        break;
                    case "JNE":
                        int hova = iDEST; //
                        int mit = regiszterek[(int)Enum.Parse(typeof(Reg), sorDb[2])];
                        int mivel = 0;
                        string SRC2 = sorDb[3];
                        bool isNumber3 = int.TryParse(SRC2, out mivel);

                        // regiszterből kiszedjük az értékét
                        if (!isNumber3)
                        {
                            int regIndex3 = (int)Enum.Parse(typeof(Reg), SRC2);
                            mivel = regiszterek[regIndex3];
                        }
                        ;
                        if (mit != mivel)
                            i = hova;
                        else
                        {
                            i = sorok.Length;
                        }

                        break;
                    default:
                        break;

                }

;
            }
            string kimenet ="";

            for (int i = 0; i < regiszterek.Length; i++)
            {
               kimenet+=regiszterek[i];
                if (i<regiszterek.Length -1) kimenet+=",";
            }

           // Console.WriteLine(kimenet);
            File.WriteAllText("output.txt", kimenet);
        }
    }
}