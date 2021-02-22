using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SænkeSlagskib
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player();
            Player p2 = new Player();

            PlacementeManager placementeManager = new PlacementeManager(3);

            placementeManager.MakeShip(p1);
            Console.Clear();
            placementeManager.MakeShip(p2);

            Console.WriteLine("STOP!");
            Console.ReadKey();


            bool power = true;
            int currentplayer = 1;
            while (power)
            {
                Console.Clear();

                if (currentplayer == 1) 
                {
                    Console.WriteLine("Player 1");
                    Console.WriteLine("Your board: ");
                    p1.ownBoard.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("Shotting board: ");
                    p1.enemyBoard.DisplayBoard();

                    p1.shooting(out int x, out int y);

                    p1.enemyBoard.board[y,x] = p2.GettingShot(y,x);

                    currentplayer = 2;
                }
                else
                {
                    Console.WriteLine("Player 2");
                    Console.WriteLine("Your board: ");
                    p2.ownBoard.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("Shotting board: ");
                    p2.enemyBoard.DisplayBoard();

                    p2.shooting(out int x, out int y);

                    p2.enemyBoard.board[y, x] = p1.GettingShot(y, x);

                    currentplayer = 1;
                }

                if (p1.ownBoard.checkShips()) 
                {
                    Console.WriteLine("Player 2 is the winner and player 1 is a loser");
                    power = false;

                    Console.WriteLine();
                    Console.WriteLine("Player 2 board: ");
                    p2.ownBoard.DisplayBoard();

                    Console.WriteLine();
                    Console.WriteLine("Player 1 board: ");
                    p1.ownBoard.DisplayBoard();

                } else if (p2.ownBoard.checkShips()) 
                {
                    Console.WriteLine("Player 1 is the winner and player 2 is a loser");
                    power = false;

                    Console.WriteLine();
                    Console.WriteLine("Player 1 board: ");
                    p1.ownBoard.DisplayBoard();

                    Console.WriteLine();
                    Console.WriteLine("Player 2 board: ");
                    p2.ownBoard.DisplayBoard();

                }

            }

            Console.ReadLine();
        }
    }
}
