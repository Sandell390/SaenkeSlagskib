using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SænkeSlagskib
{
    class PlacementeManager
    {
        public Board tempBoard { get; set; }

        char[] colums = new char[10] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

        int antalskibbe = 0;

        List<int> gameSkibbe = new List<int>();

        Random random = new Random();

        public PlacementeManager(int _antalskibbe) 
        {
            antalskibbe = _antalskibbe;


            for (int i = 0; i < antalskibbe; i++)
            {
                gameSkibbe.Add(random.Next(2,5));
            }


        }

        public void MakeShip(Player player) 
        {
            tempBoard = new Board();

            List<Ship> playerShips = new List<Ship>();

            for (int i = 0; i < gameSkibbe.Count; i++)
            {
                Console.WriteLine("");

                Console.WriteLine($"Ship Length: {gameSkibbe[i]}");
                tempBoard.DisplayBoard();

                string userinput;
                do
                {
                    Console.WriteLine("Do you want to place the ship horital or vertical? ( H / V )");
                    userinput = Console.ReadLine();
                } while (userinput.ToLower() != "h" && userinput.ToLower() != "v");

                
                

                int[,] coords = new int[gameSkibbe[i], 2];

                GetPlace(out int x, out int y);

                if (userinput.ToLower() == "v")
                {
                    bool ship = false;

                    for (int _x = 0; _x < coords.GetLength(0); _x++)
                    {
                        if (tempBoard.board[y, x + _x] == 1)
                        {
                            ship = true;
                        }
                    }

                    if (x + coords.GetLength(0) > 0 && !ship)
                    {

                            for (int j = 0; j < coords.GetLength(0); j++)
                            {
                                coords[j, 0] = y;

                                coords[j, 1] = x + j;
                            }

                            Ship _ship = new Ship(gameSkibbe[i], coords);

                            tempBoard.ships.Add(_ship);

                            tempBoard.PlaceShips();


                    }
                    else
                    {
                        errorMessage();

                        i--;
                    }
                }
                else
                {
                    bool ship = false;

                    for (int _y = 0; _y < coords.GetLength(0); _y++)
                    {
                        if (tempBoard.board[y +  _y, x] == 1)
                        {
                            ship = true;
                        }
                    }



                    if (y + coords.GetLength(0) > 0 && !ship)
                    {
                        for (int j = 0; j < coords.GetLength(0); j++)
                        {
                            coords[j, 0] = y + j;

                            coords[j, 1] = x;
                        }

                        tempBoard.ships.Add(new Ship(gameSkibbe[i], coords));

                        tempBoard.PlaceShips();
                    }
                    else
                    {
                        errorMessage();

                        i--;
                    }
                }


                Console.Clear();
            }

            player.ownBoard = tempBoard;

        }


        void errorMessage() 
        {
            //Give error message
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You can't place the ship there!!!");
            Console.ForegroundColor = ConsoleColor.White;

            Thread.Sleep(1000);


        }

        void GetPlace(out int x, out int y)
        {
            x = 0;
            y = 0;

            Console.WriteLine("Where do you want to place your ship? ");



            bool lenght = false;
            bool letter = false;
            bool number = false;
            do
            {
                string userinput = Console.ReadLine();
                try
                {
                    lenght = Checklength(userinput);
                    letter = CheckLetter(userinput, out x);
                    number = CheckNumber(userinput, out y);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error code 4. There are something wrong with the string");
                }


            } while (!lenght || !letter || !number);



        }


        bool Checklength(string input)
        {
            while (input.Length > 2 || input.Length < 2)
            {
                Console.WriteLine("Error code: 1. You wrote something wrong, please try again");
                return false;
            }
            return true;
        }
        bool CheckLetter(string input, out int x)
        {
            x = 0;
            for (int i = 0; i < colums.Length; i++)
            {
                if (input.Substring(0, 1).ToUpper() == colums[i].ToString())
                {
                    x = i;
                    break;
                }
                else if (i == colums.Length - 1)
                {
                    Console.WriteLine("Error code: 2. You wrote something wrong, please try again");
                    return false;

                }

            }
            return true;
        }
        bool CheckNumber(string input, out int y)
        {
            while (!int.TryParse(input.Substring(1, 1), out y) || (y > 9 || y < 0))
            {
                Console.WriteLine("Error code: 3. You wrote something wrong, please try again");
                return false;
            }
            return true;
        }

    }
}
