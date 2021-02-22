using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SænkeSlagskib
{
    class Board
    {
        char[] colums = new char[10] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

        public int[,] board { get; set; }

        public List<Ship> ships { get; set; }

        public bool lostAllShips { get; set; }

        public Board() 
        {
            ships = new List<Ship>();

            board = new int[10, 10];
        }

        public bool checkShips() 
        {
            int countDeath = 0;
            for (int i = 0; i < ships.Count; i++)
            {
                if (ships[i].isDead) 
                {
                    countDeath++;
                }
            }

            if (countDeath == ships.Count) 
            {
                return true;
            }
            return false;
        }


        public void DisplayBoard()
        {


            bool hasDisplayed = false; //uses to the first row with letters
            bool firstTime = false; //Uses to the first space on the first row
            bool lastTime = false; //Uses to the last letter and making a new line
            for (int i = 0; i < colums.Length; i++)
            {
                for (int j = 0; j < colums.Length; j++)
                {
                    //Making the first space 
                    if (!firstTime)
                    {
                        firstTime = true;
                        Console.Write(" ");
                    }

                    //Displays letters
                    if (!hasDisplayed)
                    {
                        Console.Write($" {colums[j]} ");
                    }

                    //Checks if all letters are displayed
                    if (j == colums.Length - 1)
                    {
                        if (!lastTime)
                        {
                            lastTime = true;
                            Console.WriteLine();
                        }
                        hasDisplayed = true;

                    }

                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(i);
                DrawWater(i);
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        void DrawWater(int y)
        {
            for (int x = 0; x < board.GetLength(1); x++)
            {
                //Check what to draw: x = Water | O = ship
                switch (board[y, x])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" X ");
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" O ");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" O ");
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" X ");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(" E ");
                        break;

                }


            }
        }
        public void PlaceShips()
        {

            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {

                    board[y, x] = CheckForShips(y, x);

                }
            }

        }

        public int CheckForShips(int y, int x)
        {
            //Loops all player ships tough and if there a ship on x and y then it returns false back 
            for (int shipLoop = 0; shipLoop < ships.Count; shipLoop++)
            {

                for (int y2 = 0; y2 < ships[shipLoop].coords.GetLength(0); y2++)
                {

                    if (ships[shipLoop].coords[y2, 0] == y && ships[shipLoop].coords[y2, 1] == x)
                    {
                        return 1;
                    }

                }

            }
            return 0;
        }

        public void makingHoles(int y, int x)
        {
            for (int i = 0; i < ships.Count; i++)
            {
                for (int y2 = 0; y2 < ships[i].coords.GetLength(0); y2++)
                {
                    if (ships[i].coords[y2, 0] == y && ships[i].coords[y2, 1] == x)
                    {
                        ships[i].countHoles++;
                    }

                }

                ships[i].isDead = ships[i].checkdeath();
            }
        }
    }
}
