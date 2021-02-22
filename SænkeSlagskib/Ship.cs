using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SænkeSlagskib
{
    class Ship
    {
        int length { get; set; }

        public int[,] coords { get; set; }

        public int countHoles { get; set; }

        public bool isDead { get; set; }

        public Ship(int _length, int[,] _shipcoords) 
        {
            length = _length;
            coords = _shipcoords;
            isDead = false;
            isDead = checkdeath();
            countHoles = 0;
        }

        public bool checkdeath() 
        {
            if (countHoles == length) 
            {
                return true;
            }
            return false;
        }

    }
}
