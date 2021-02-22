using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SænkeSlagskib
{
    class Player
    {
        public Board ownBoard { get; set; }

        public Board enemyBoard { get; set; }


        char[] colums = new char[10] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

        public Player()
        {
            ownBoard = new Board();
            enemyBoard = new Board();

        }

        //-1 = Error, 0 = Water, 1 = Ship, 2 = Shot in ship, 3 = Shot in water

        public void shooting(out int x, out int y)
        {
            x = 0;
            y = 0;

            Console.WriteLine("Where do you want to shot? ");



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
        bool CheckLetter(string input , out int x)
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
        public int GettingShot(int y, int x) 
        {


            switch (ownBoard.board[y,x])
            {
                case 0:
                    ownBoard.board[y, x] = 3;
                    return 3;

                case 1:
                    ownBoard.board[y, x] = 2;

                    ownBoard.makingHoles(y,x);


                    return 2;
                default:
                    ownBoard.board[y, x] = -1;
                    break;
            }

            return -1;

        }

        

    }
}
