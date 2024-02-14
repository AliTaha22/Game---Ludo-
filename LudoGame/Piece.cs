using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace LudoGame
{
    class Piece
    {
        public COLOR PieceColor;
        public Point PiecePosition;
        public bool IsActivePiece;
        public Piece()
        {
            IsActivePiece = false;
            PieceColor = 0;
            PiecePosition.X = -1;
            PiecePosition.Y = -1;
        }
        public Piece(COLOR PC, int x, int y)
        {
            IsActivePiece = false;
            PieceColor = PC;
            PiecePosition.X = x;
            PiecePosition.Y = y;
        }
    }
}
