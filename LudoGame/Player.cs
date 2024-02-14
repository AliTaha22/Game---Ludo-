using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame
{
    class Player
    {
       public COLOR PlayerColor;
       public Piece[] PPieces;
       public bool IsFinish;
       public int WC;


        public Player()
        {
            WC = 0;
            IsFinish = false;
            PlayerColor = 0;
            PPieces = new Piece[4];
        }
        public Player(COLOR PC, int x, int y)
        {
            WC = 0;
            IsFinish = false;
            PlayerColor = PC;
            PPieces = new Piece[4];
            for(int i = 0; i < 4; i++)
            {
                PPieces[i] = new Piece(PC,x,y);
                y += 40;
            }
        }


    }
}
