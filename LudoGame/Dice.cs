using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LudoGame
{
    class Dice
    {
        private Random r;
        public Dice()
        {
             r = new Random();
        }
       public int RollDice()
        {
            return r.Next(1, 7);
        }
    }
}
