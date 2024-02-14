using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LudoGame
{
    public partial class Ludo : Form
    {
        Player[] Ps = new Player[4]; // 4 players by default
        COLOR Turn;
        Dice D = new Dice();    //dice object to move pieces positions
        Point[] BoardPath = new Point[3*4*6+4];   //ludo path
        int b1 = 1, b2 = 1, b3 = 1, b4 = 1;
        int y1 = 58, y2 = 58, y3 = 58, y4 = 58;
        int g1 = 39, g2 = 39, g3 = 39, g4 = 39;
        int r1 = 20, r2 = 20, r3 = 20, r4 = 20;

        int RNum = 0;

        public Ludo()
        {
            InitializeComponent();
        }
        void ResetVisibility()
        {
            BluePiece1.Visible = true;
            BluePiece2.Visible = true;
            BluePiece3.Visible = true;
            BluePiece4.Visible = true;

            YellowPiece1.Visible = true;
            YellowPiece2.Visible = true;
            YellowPiece3.Visible = true;
            YellowPiece4.Visible = true;

            GreenPiece1.Visible = true;
            GreenPiece2.Visible = true;
            GreenPiece3.Visible = true;
            GreenPiece4.Visible = true;

            RedPiece1.Visible = true;
            RedPiece2.Visible = true;
            RedPiece3.Visible = true;
            RedPiece4.Visible = true;
        }
        void DiceGenerateRandomNumber()
        {
            RNum = D.RollDice();
            if (RNum == 1)
                DiceDisplayPic1.Image = Number1.Image;
            else if (RNum == 2)
                DiceDisplayPic1.Image = Number2.Image;
            else if (RNum == 3)
                DiceDisplayPic1.Image = Number3.Image;
            else if (RNum == 4)
                DiceDisplayPic1.Image = Number4.Image;
            else if (RNum == 5)
                DiceDisplayPic1.Image = Number5.Image;
            else if (RNum == 6)
                DiceDisplayPic2.Image = Number6.Image;
        }
        private void RollDiceButton_Click(object sender, EventArgs e)
        {
            DiceGenerateRandomNumber();
        }
        private void GStartButton_Click(object sender, EventArgs e)
        {
            Init();
        }
        void Init()
        {
            Turn = COLOR.BLUE;    // Blue's turn is 1st by default
            InitPlayers();
            InitPieces();
            CreatePiecesPath();
            DisplayPlayerTurn();
            ResetDice();
            ResetVisibility();
        }
        void ResetDice()
        {
            DiceDisplayPic1.Image = Reset.Image;
            DiceDisplayPic2.Image = Reset.Image;

        }
        void DisplayPlayerTurn()
        {
            if (COLOR.BLUE == Turn)
                PlayerColorBox.Image = BlueBox.Image;
            else if (COLOR.GREEN == Turn)
                PlayerColorBox.Image = GreenBox.Image;
            else if (COLOR.RED == Turn)
                PlayerColorBox.Image = RedBox.Image;
            else if (COLOR.YELLOW == Turn)
                PlayerColorBox.Image = YellowBox.Image;
        }

        private void Ludo_Load(object sender, EventArgs e)
        {

        }

        void InitPieces()   //pieces move to their default locations
        {
            BluePiece1.Location = Ps[0].PPieces[0].PiecePosition;
            BluePiece2.Location = Ps[0].PPieces[1].PiecePosition;
            BluePiece3.Location = Ps[0].PPieces[2].PiecePosition;
            BluePiece4.Location = Ps[0].PPieces[3].PiecePosition;

            YellowPiece1.Location = Ps[1].PPieces[0].PiecePosition;
            YellowPiece2.Location = Ps[1].PPieces[1].PiecePosition;
            YellowPiece3.Location = Ps[1].PPieces[2].PiecePosition;
            YellowPiece4.Location = Ps[1].PPieces[3].PiecePosition;

            GreenPiece1.Location = Ps[2].PPieces[0].PiecePosition;
            GreenPiece2.Location = Ps[2].PPieces[1].PiecePosition;
            GreenPiece3.Location = Ps[2].PPieces[2].PiecePosition;
            GreenPiece4.Location = Ps[2].PPieces[3].PiecePosition;

            RedPiece1.Location = Ps[3].PPieces[0].PiecePosition;
            RedPiece2.Location = Ps[3].PPieces[1].PiecePosition;
            RedPiece3.Location = Ps[3].PPieces[2].PiecePosition;
            RedPiece4.Location = Ps[3].PPieces[3].PiecePosition;
        }
        void InitPlayers()
        {
            COLOR temp = 0;
            int PX = 390, PY = 436; //players x and y axis location
            for (int i = 0; i < 4; i++)
            {
                if (i == 1)
                {
                    PX = 800; PY = 436;
                }
                else if (i == 2)
                {
                    PX = 800; PY = 22;
                }
                else if (i == 3)
                {
                    PX = 390; PY = 22;
                }
                Ps[i] = new Player(temp, PX,PY);
                temp++;
            }
        }
        void CreatePiecesPath()
        {
            int x = 660,y=660;
            int i = 0;
            for(;i<6;i++)
            {
                BoardPath[i].X = x;
                BoardPath[i].Y = y;

                y -= 46;
            }
            x = 614; y = 384;
            for (; i < 12; i++)
            {
                BoardPath[i].X = x;
                BoardPath[i].Y = y;

                x -= 46;
            }
            x = 384; y = 338;
            for (; i < 19; i++)
            {
                BoardPath[i].X = x;
                BoardPath[i].Y = y;

                x += 46;
            }
            x = 384; y = 292;
            for (; i < 25; i++)
            {
                BoardPath[i].X = x;
                BoardPath[i].Y = y;

                x += 46;
            }
            x = 660; y = 246;
            for (; i < 31; i++)
            {
                BoardPath[i].X = x;
                BoardPath[i].Y = y;

                y -= 46;
            }
            x = 706; y = 16;
            for (; i < 38; i++)
            {
                BoardPath[i].X = x;
                BoardPath[i].Y = y;

                y += 46;
            }
            x = 752; y = 16;
            for (; i < 44; i++)
            {
                BoardPath[i].X = x;
                BoardPath[i].Y = y;

                y += 46;
            }
            x = 798; y = 292;
            for (; i < 50; i++)
            {
                BoardPath[i].X = x;
                BoardPath[i].Y = y;

                x += 46;
            }
            x = 1028; y = 338;
            for (; i < 57; i++)
            {
                BoardPath[i].X = x;
                BoardPath[i].Y = y;

                x -= 46;
            }
            x = 1028; y = 384;
            for (; i < 63; i++)
            {
                BoardPath[i].X = x;
                BoardPath[i].Y = y;

                x -= 46;
            }
            x = 752; y = 430;
            for (; i < 69; i++)
            {
                BoardPath[i].X = x;
                BoardPath[i].Y = y;

                y += 46;
            }
            x = 706; y = 660;
            for (; i < 76; i++)
            {
                BoardPath[i].X = x;
                BoardPath[i].Y = y;

                y -= 46;
            }
        }


        void ChangeTurn()
        {
            //if (Turn == COLOR.BLUE)  //last player
            //    Turn = COLOR.YELLOW;
            //else if (Turn == COLOR.YELLOW)  //last player
            //    Turn = COLOR.GREEN;
            //else if (Turn == COLOR.GREEN)  //last player
            //    Turn = COLOR.RED;
            //else if (Turn == COLOR.RED)  //last player
            //    Turn = COLOR.BLUE;


            if (Turn == COLOR.BLUE)
                Turn = COLOR.RED;
            else if (Turn == COLOR.RED)
                Turn = COLOR.BLUE;
        }
        bool IsWin()
        {
            for(int i = 0; i < 4; i++)
            {
                if(Ps[i].WC == 4)
                {
                    Ps[i].IsFinish = true;
                    return true;
                }
            }
            return false;
        }
        void MoveToNextPlayer()
        {
            RNum = 0;
            ChangeTurn();
            DisplayPlayerTurn();
            ResetDice();
        }
        void KillEnemy(int pn, int ppn) // pn = player number, ppn = player piece number
        {
            if(Turn != Ps[0].PlayerColor)
            {
                if (Ps[pn].PPieces[ppn].PiecePosition == BluePiece1.Location)
                {
                    Point P = new Point(390, 436);
                    Ps[0].PPieces[0].PiecePosition = P;
                    BluePiece1.Location = Ps[0].PPieces[0].PiecePosition;
                    Ps[0].PPieces[0].IsActivePiece = false;
                    b1 = 1;
                }
                else if (Ps[pn].PPieces[ppn].PiecePosition == BluePiece2.Location)
                {
                    Point P = new Point(390, 482);
                    Ps[0].PPieces[1].PiecePosition = P;
                    BluePiece2.Location = Ps[0].PPieces[1].PiecePosition;
                    Ps[0].PPieces[1].IsActivePiece = false;
                    b2 = 1;
                }
                else if (Ps[pn].PPieces[ppn].PiecePosition == BluePiece3.Location)
                {
                    Point P = new Point(390, 528);
                    Ps[0].PPieces[2].PiecePosition = P;
                    BluePiece3.Location = Ps[0].PPieces[2].PiecePosition;
                    Ps[0].PPieces[2].IsActivePiece = false;
                    b3 = 1;
                }
                else if (Ps[pn].PPieces[ppn].PiecePosition == BluePiece4.Location)
                {
                    Point P = new Point(390, 574);
                    Ps[0].PPieces[3].PiecePosition = P;
                    BluePiece4.Location = Ps[0].PPieces[3].PiecePosition;
                    Ps[0].PPieces[3].IsActivePiece = false;
                    b4 = 1;
                }
            }
            //
            if (Turn != Ps[1].PlayerColor)
            {
                if (Ps[pn].PPieces[ppn].PiecePosition == YellowPiece1.Location)
                {
                    Point P = new Point(800, 436);
                    Ps[1].PPieces[0].PiecePosition = P;
                    YellowPiece1.Location = Ps[1].PPieces[0].PiecePosition;
                    Ps[1].PPieces[0].IsActivePiece = false;
                    y1 = 58;
                }
                else if (Ps[pn].PPieces[ppn].PiecePosition == YellowPiece2.Location)
                {
                    Point P = new Point(800, 482);
                    Ps[1].PPieces[1].PiecePosition = P;
                    YellowPiece2.Location = Ps[1].PPieces[1].PiecePosition;
                    Ps[1].PPieces[1].IsActivePiece = false;
                    y2 = 58;
                }
                else if (Ps[pn].PPieces[ppn].PiecePosition == YellowPiece3.Location)
                {
                    Point P = new Point(800, 528);
                    Ps[1].PPieces[2].PiecePosition = P;
                    YellowPiece3.Location = Ps[1].PPieces[2].PiecePosition;
                    Ps[1].PPieces[2].IsActivePiece = false;
                    y3 = 58;
                }
                else if (Ps[pn].PPieces[ppn].PiecePosition == YellowPiece4.Location)
                {
                    Point P = new Point(800, 574);
                    Ps[1].PPieces[3].PiecePosition = P;
                    YellowPiece4.Location = Ps[1].PPieces[3].PiecePosition;
                    Ps[1].PPieces[3].IsActivePiece = false;
                    y4 = 58;
                }
            }
            //
            if (Turn != Ps[2].PlayerColor)
            {
                if (Ps[pn].PPieces[ppn].PiecePosition == GreenPiece1.Location)
                {
                    Point P = new Point(800, 22);
                    Ps[2].PPieces[0].PiecePosition = P;
                    GreenPiece1.Location = Ps[1].PPieces[0].PiecePosition;
                    Ps[2].PPieces[0].IsActivePiece = false;
                    g1 = 39;
                }
                else if (Ps[pn].PPieces[ppn].PiecePosition == GreenPiece2.Location)
                {
                    Point P = new Point(800, 68);
                    Ps[2].PPieces[1].PiecePosition = P;
                    GreenPiece2.Location = Ps[1].PPieces[1].PiecePosition;
                    Ps[2].PPieces[1].IsActivePiece = false;
                    g2 = 39;
                }
                else if (Ps[pn].PPieces[ppn].PiecePosition == GreenPiece3.Location)
                {
                    Point P = new Point(800, 114);
                    Ps[2].PPieces[2].PiecePosition = P;
                    GreenPiece3.Location = Ps[1].PPieces[2].PiecePosition;
                    Ps[2].PPieces[2].IsActivePiece = false;
                    g3 = 39;
                }
                else if (Ps[pn].PPieces[ppn].PiecePosition == GreenPiece4.Location)
                {
                    Point P = new Point(800, 160);
                    Ps[2].PPieces[3].PiecePosition = P;
                    GreenPiece4.Location = Ps[1].PPieces[3].PiecePosition;
                    Ps[2].PPieces[3].IsActivePiece = false;
                    g4 = 39;
                }
            }
            //
            if (Turn != Ps[3].PlayerColor)
            {
                if (Ps[0].PPieces[ppn].PiecePosition == RedPiece1.Location)
                {
                    Point P = new Point(390, 22);
                    Ps[3].PPieces[0].PiecePosition = P;
                    RedPiece1.Location = Ps[3].PPieces[0].PiecePosition;
                    Ps[3].PPieces[0].IsActivePiece = false;
                    r1 = 20;
                }
                else if (Ps[0].PPieces[ppn].PiecePosition == RedPiece2.Location)
                {
                    Point P = new Point(390, 68);
                    Ps[3].PPieces[1].PiecePosition = P;
                    RedPiece2.Location = Ps[3].PPieces[1].PiecePosition;
                    Ps[3].PPieces[1].IsActivePiece = false;
                    r2 = 20;
                }
                else if (Ps[0].PPieces[ppn].PiecePosition == RedPiece3.Location)
                {
                    Point P = new Point(390, 114);
                    Ps[3].PPieces[2].PiecePosition = P;
                    RedPiece3.Location = Ps[3].PPieces[2].PiecePosition;
                    Ps[3].PPieces[2].IsActivePiece = false;
                    r3 = 20;
                }
                else if (Ps[0].PPieces[ppn].PiecePosition == RedPiece4.Location)
                {
                    Point P = new Point(390, 160);
                    Ps[3].PPieces[3].PiecePosition = P;
                    RedPiece4.Location = Ps[3].PPieces[3].PiecePosition;
                    Ps[3].PPieces[3].IsActivePiece = false;
                    r4 = 20;
                }
            }
                
        }
        private void BluePiece1_Click(object sender, EventArgs e)
        {
            //this if will work when the turn color and player color match
            if ( Ps[0].PlayerColor == Turn && b1+RNum <=75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[0].PPieces[0].IsActivePiece)
                {
                    b1 += RNum;
                    if ((b1 >= 13 && b1 <= 18) || (b1 >= 32 && b1 <= 37) || (b1 >= 51 && b1 <= 57))   // these are places where  blue cannot go
                        b1 += 6;

                    Ps[0].PPieces[0].PiecePosition = BoardPath[b1];
                    BluePiece1.Location = Ps[0].PPieces[0].PiecePosition;

                    if ((b1 != 1) && (b1 != 9) && (b1 != 20) && (b1 != 28) && (b1 != 27) && (b1 != 39) && (b1 != 47)
                        && (b1 != 58) && (b1 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(0,0);

                    if (Ps[0].PPieces[0].PiecePosition == BoardPath[75])
                    {
                        BluePiece1.Visible = false;
                        Ps[0].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[0].PPieces[0].IsActivePiece = true;
                    BluePiece1.Location = BoardPath[b1];
                }
                if (Ps[0].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }
        private void BluePiece2_Click(object sender, EventArgs e)
        {
            if (Ps[0].PlayerColor == Turn && b2 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[0].PPieces[1].IsActivePiece)
                {
                    b2 += RNum;
                    if ((b2 >= 13 && b2 <= 18) || (b2 >= 32 && b2 <= 37) || (b2 >= 51 && b2 <= 57))   // these are places where  blue cannot go
                        b2 += 6;

                    Ps[0].PPieces[1].PiecePosition = BoardPath[b2];
                    BluePiece2.Location = Ps[0].PPieces[1].PiecePosition;

                    if ((b2 != 1) && (b2 != 9) && (b2 != 20) && (b2 != 28) && (b2 != 27) && (b2 != 39) && (b2 != 47)
                        && (b2 != 58) && (b2 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(0, 1);

                    if (Ps[0].PPieces[1].PiecePosition == BoardPath[75])
                    {
                        BluePiece2.Visible = false;
                        Ps[0].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[0].PPieces[1].IsActivePiece = true;
                    BluePiece2.Location = BoardPath[b2];
                }
                if (Ps[0].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }
        private void BluePiece3_Click(object sender, EventArgs e)
        {
            if (Ps[0].PlayerColor == Turn && b3 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[0].PPieces[2].IsActivePiece)
                {
                    b3 += RNum;
                    if ((b3 >= 13 && b3 <= 18) || (b3 >= 32 && b3 <= 37) || (b3 >= 51 && b3 <= 57))   // these are places where  blue cannot go
                        b3 += 6;

                    Ps[0].PPieces[2].PiecePosition = BoardPath[b3];
                    BluePiece3.Location = Ps[0].PPieces[2].PiecePosition;

                    if ((b3 != 1) && (b3 != 9) && (b3 != 20) && (b3 != 28) && (b3 != 27) && (b3 != 39) && (b3 != 47)
                        && (b3 != 58) && (b3 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(0, 2);

                    if (Ps[0].PPieces[2].PiecePosition == BoardPath[75])
                    {
                        BluePiece3.Visible = false;
                        Ps[0].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[0].PPieces[2].IsActivePiece = true;
                    BluePiece3.Location = BoardPath[b3];
                }
                if (Ps[0].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }
        private void BluePiece4_Click(object sender, EventArgs e)
        {
            if (Ps[0].PlayerColor == Turn && b4 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[0].PPieces[3].IsActivePiece)
                {
                    b4 += RNum;
                    if ((b4 >= 13 && b4 <= 18) || (b4 >= 32 && b4 <= 37) || (b4 >= 51 && b4 <= 57))   // these are places where  blue cannot go
                        b4 += 6;

                    Ps[0].PPieces[3].PiecePosition = BoardPath[b4];
                    BluePiece4.Location = Ps[0].PPieces[3].PiecePosition;

                    if ((b4 != 1) && (b4 != 9) && (b4 != 20) && (b4 != 28) && (b4 != 27) && (b4 != 39) && (b4 != 47)
                        && (b4 != 58) && (b4 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(0, 3);

                    if (Ps[0].PPieces[3].PiecePosition == BoardPath[75])
                    {
                        BluePiece4.Visible = false;
                        Ps[0].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[0].PPieces[3].IsActivePiece = true;
                    BluePiece4.Location = BoardPath[b4];
                }
                if (Ps[0].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }

        private void YellowPiece1_Click(object sender, EventArgs e)
        {
            if (Ps[1].PlayerColor == Turn && y1 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[1].PPieces[0].IsActivePiece)
                {
                    y1 += RNum;
                    if ((y1 >= 70 && y1 <= 75) || (y1 >= 32 && y1 <= 37) || (y1 >= 13 && y1 <= 18))
                        y1 += 6;

                    Ps[1].PPieces[0].PiecePosition = BoardPath[y1];
                    YellowPiece1.Location = Ps[1].PPieces[0].PiecePosition;

                    if ((y1 != 1) && (y1 != 9) && (y1 != 20) && (y1 != 28) && (y1 != 27) && (y1 != 39) && (y1 != 47)
                        && (y1 != 58) && (y1 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(1, 0);

                    if (Ps[1].PPieces[0].PiecePosition == BoardPath[56])
                    {
                        YellowPiece1.Visible = false;
                        Ps[1].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[1].PPieces[0].IsActivePiece = true;
                    YellowPiece1.Location = BoardPath[y1];
                }
                if (Ps[1].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }
        private void YellowPiece2_Click(object sender, EventArgs e)
        {
            if (Ps[1].PlayerColor == Turn && y2 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[1].PPieces[1].IsActivePiece)
                {
                    y2 += RNum;
                    if ((y2 >= 70 && y2 <= 75) || (y2 >= 32 && y2 <= 37) || (y2 >= 13 && y2 <= 18))
                        y2 += 6;

                    Ps[1].PPieces[1].PiecePosition = BoardPath[y2];
                    YellowPiece2.Location = Ps[1].PPieces[1].PiecePosition;

                    if ((y2 != 1) && (y2 != 9) && (y2 != 20) && (y2 != 28) && (y2 != 27) && (y2 != 39) && (y2 != 47)
                        && (y2 != 58) && (y2 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(1, 1);

                    if (Ps[1].PPieces[1].PiecePosition == BoardPath[56])
                    {
                        YellowPiece2.Visible = false;
                        Ps[1].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[1].PPieces[1].IsActivePiece = true;
                    YellowPiece2.Location = BoardPath[y2];
                }
                if (Ps[1].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }
        private void YellowPiece3_Click(object sender, EventArgs e)
        {
            if (Ps[1].PlayerColor == Turn && y3 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[1].PPieces[2].IsActivePiece)
                {
                    y3 += RNum;
                    if ((y3 >= 70 && y3 <= 75) || (y3 >= 32 && y3 <= 37) || (y3 >= 13 && y3 <= 18))
                        y3 += 6;

                    Ps[1].PPieces[2].PiecePosition = BoardPath[y3];
                    YellowPiece3.Location = Ps[1].PPieces[2].PiecePosition;

                    if ((y3 != 1) && (y3 != 9) && (y3 != 20) && (y3 != 28) && (y3 != 27) && (y3 != 39) && (y3 != 47)
                        && (y3 != 58) && (y3 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(1, 2);

                    if (Ps[1].PPieces[2].PiecePosition == BoardPath[56])
                    {
                        YellowPiece3.Visible = false;
                        Ps[1].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[1].PPieces[2].IsActivePiece = true;
                    YellowPiece3.Location = BoardPath[y3];
                }
                if (Ps[1].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }
        private void YellowPiece4_Click(object sender, EventArgs e)
        {
            if (Ps[1].PlayerColor == Turn && y4 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[1].PPieces[3].IsActivePiece)
                {
                    y4 += RNum;
                    if ((y4 >= 70 && y4 <= 75) || (y4 >= 32 && y4 <= 37) || (y4 >= 13 && y4 <= 18))
                        y4 += 6;

                    Ps[1].PPieces[3].PiecePosition = BoardPath[y4];
                    YellowPiece4.Location = Ps[1].PPieces[3].PiecePosition;

                    if ((y4 != 1) && (y4 != 9) && (y4 != 20) && (y4 != 28) && (y4 != 27) && (y4 != 39) && (y4 != 47)
                        && (y4 != 58) && (y4 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(1, 3);

                    if (Ps[1].PPieces[3].PiecePosition == BoardPath[56])
                    {
                        YellowPiece4.Visible = false;
                        Ps[1].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[1].PPieces[3].IsActivePiece = true;
                    YellowPiece4.Location = BoardPath[y4];
                }
                if (Ps[1].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }

        private void GreenPiece1_Click(object sender, EventArgs e)
        {
            if (Ps[2].PlayerColor == Turn && g1 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[2].PPieces[0].IsActivePiece)
                {
                    g1 += RNum;
                    if ((g1 >= 70 && g1 <= 75) || (g1 >= 32 && g1 <= 37) || (g1 >= 51 && g1 <= 57))
                        g1 += 6;

                    Ps[2].PPieces[0].PiecePosition = BoardPath[g1];
                    GreenPiece1.Location = Ps[2].PPieces[0].PiecePosition;

                    if ((g1 != 1) && (g1 != 9) && (g1 != 20) && (g1 != 28) && (g1 != 27) && (g1 != 39) && (g1 != 47)
                        && (g1 != 58) && (g1 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(2, 0);

                    if (Ps[2].PPieces[0].PiecePosition == BoardPath[37])
                    {
                        GreenPiece1.Visible = false;
                        Ps[2].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[2].PPieces[0].IsActivePiece = true;
                    GreenPiece1.Location = BoardPath[g1];
                }
                if (Ps[2].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }
        private void GreenPiece2_Click(object sender, EventArgs e)
        {
            if (Ps[2].PlayerColor == Turn && g2 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[2].PPieces[1].IsActivePiece)
                {
                    g2 += RNum;
                    if ((g2 >= 70 && g2 <= 75) || (g2 >= 32 && g2 <= 37) || (g2 >= 51 && g2 <= 57))
                        g2 += 6;

                    Ps[2].PPieces[1].PiecePosition = BoardPath[g2];
                    GreenPiece2.Location = Ps[2].PPieces[1].PiecePosition;

                    if ((g2 != 1) && (g2 != 9) && (g2 != 20) && (g2 != 28) && (g2 != 27) && (g2 != 39) && (g2 != 47)
                        && (g2 != 58) && (g2 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(2, 1);

                    if (Ps[2].PPieces[1].PiecePosition == BoardPath[37])
                    {
                        GreenPiece2.Visible = false;
                        Ps[2].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[2].PPieces[1].IsActivePiece = true;
                    GreenPiece2.Location = BoardPath[g2];
                }
                if (Ps[2].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }
        private void GreenPiece3_Click(object sender, EventArgs e)
        {
            if (Ps[2].PlayerColor == Turn && g3 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[2].PPieces[2].IsActivePiece)
                {
                    g3 += RNum;
                    if ((g3 >= 70 && g3 <= 75) || (g3 >= 32 && g3 <= 37) || (g3 >= 51 && g3 <= 57))
                        g3 += 6;

                    Ps[2].PPieces[2].PiecePosition = BoardPath[g3];
                    GreenPiece3.Location = Ps[2].PPieces[2].PiecePosition;

                    if ((g3 != 1) && (g3 != 9) && (g3 != 20) && (g3 != 28) && (g3 != 27) && (g3 != 39) && (g3 != 47)
                        && (g3 != 58) && (g3 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(2, 2);

                    if (Ps[2].PPieces[2].PiecePosition == BoardPath[37])
                    {
                        GreenPiece3.Visible = false;
                        Ps[2].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[2].PPieces[2].IsActivePiece = true;
                    GreenPiece3.Location = BoardPath[g3];
                }
                if (Ps[2].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }
        private void GreenPiece4_Click(object sender, EventArgs e)
        {
            if (Ps[2].PlayerColor == Turn && g4 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[2].PPieces[3].IsActivePiece)
                {
                    g4 += RNum;
                    if ((g4 >= 70 && g4 <= 75) || (g4 >= 32 && g4 <= 37) || (g4 >= 51 && g4 <= 57))
                        g4 += 6;

                    Ps[2].PPieces[3].PiecePosition = BoardPath[g4];
                    GreenPiece4.Location = Ps[2].PPieces[3].PiecePosition;

                    if ((g4 != 1) && (g4 != 9) && (g4 != 20) && (g4 != 28) && (g4 != 27) && (g4 != 39) && (g4 != 47)
                        && (g4 != 58) && (g4 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(2, 3);

                    if (Ps[2].PPieces[3].PiecePosition == BoardPath[37])
                    {
                        GreenPiece4.Visible = false;
                        Ps[2].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[2].PPieces[3].IsActivePiece = true;
                    GreenPiece4.Location = BoardPath[g4];
                }
                if (Ps[2].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }

        private void RedPiece1_Click(object sender, EventArgs e)
        {
            if (Ps[3].PlayerColor == Turn && r1 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[3].PPieces[0].IsActivePiece)
                {
                    r1 += RNum;
                    if ((r1 >= 70 && r1 <= 75) || (r1 >= 32 && r1 <= 37) || (r1 >= 51 && r1 <= 57))
                        r1 += 6;

                    Ps[3].PPieces[0].PiecePosition = BoardPath[r1];
                    RedPiece1.Location = Ps[3].PPieces[0].PiecePosition;

                    if ((r1 != 1) && (r1 != 9) && (r1 != 20) && (r1 != 28) && (r1 != 27) && (r1 != 39) && (r1 != 47)
                        && (r1 != 58) && (r1 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(3, 0);

                    if (Ps[3].PPieces[0].PiecePosition == BoardPath[18])
                    {
                        RedPiece1.Visible = false;
                        Ps[3].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[3].PPieces[0].IsActivePiece = true;
                    RedPiece1.Location = BoardPath[r1];
                }
                if (Ps[3].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }
        private void RedPiece2_Click(object sender, EventArgs e)
        {
            if (Ps[3].PlayerColor == Turn && r2 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[3].PPieces[1].IsActivePiece)
                {
                    r2 += RNum;
                    if ((r2 >= 70 && r2 <= 75) || (r2 >= 32 && r2 <= 37) || (r2 >= 51 && r2 <= 57))
                        r2 += 6;

                    Ps[3].PPieces[1].PiecePosition = BoardPath[r2];
                    RedPiece2.Location = Ps[3].PPieces[1].PiecePosition;

                    if ((r2 != 1) && (r2 != 9) && (r2 != 20) && (r2 != 28) && (r2 != 27) && (r2 != 39) && (r2 != 47)
                        && (r2 != 58) && (r2 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(3, 1);

                    if (Ps[3].PPieces[1].PiecePosition == BoardPath[18])
                    {
                        RedPiece2.Visible = false;
                        Ps[3].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[3].PPieces[1].IsActivePiece = true;
                    RedPiece2.Location = BoardPath[r2];
                }
                if (Ps[3].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }
        private void RedPiece3_Click(object sender, EventArgs e)
        {
            if (Ps[3].PlayerColor == Turn && r2 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[3].PPieces[2].IsActivePiece)
                {
                    r3 += RNum;
                    if ((r3 >= 70 && r3 <= 75) || (r3 >= 32 && r3 <= 37) || (r3 >= 51 && r3 <= 57))
                        r3 += 6;

                    Ps[3].PPieces[2].PiecePosition = BoardPath[r3];
                    RedPiece3.Location = Ps[3].PPieces[2].PiecePosition;

                    if ((r3 != 1) && (r3 != 9) && (r3 != 20) && (r3 != 28) && (r3 != 27) && (r3 != 39) && (r3 != 47)
                        && (r3 != 58) && (r3 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(3, 2);

                    if (Ps[3].PPieces[2].PiecePosition == BoardPath[18])
                    {
                        RedPiece3.Visible = false;
                        Ps[3].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[3].PPieces[2].IsActivePiece = true;
                    RedPiece3.Location = BoardPath[r3];
                }
                if (Ps[3].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }
        private void RedPiece4_Click(object sender, EventArgs e)
        {
            if (Ps[3].PlayerColor == Turn && r4 + RNum <= 75)
            {
                //if will work when the player is active. player gets activated on 6
                if (Ps[3].PPieces[3].IsActivePiece)
                {
                    r4 += RNum;
                    if ((r4 >= 70 && r4 <= 75) || (r4 >= 32 && r4 <= 37) || (r4 >= 51 && r4 <= 57))
                        r4 += 6;

                    Ps[3].PPieces[3].PiecePosition = BoardPath[r4];
                    RedPiece4.Location = Ps[3].PPieces[3].PiecePosition;

                    if ((r4 != 1) && (r4 != 9) && (r4 != 20) && (r4 != 28) && (r4 != 27) && (r4 != 39) && (r4 != 47)
                        && (r4 != 58) && (r4 != 66))  //these locations are stops where players cannot be killed
                        KillEnemy(3, 3);

                    if (Ps[3].PPieces[3].PiecePosition == BoardPath[18])
                    {
                        RedPiece4.Visible = false;
                        Ps[3].WC++;
                    }
                    IsWin();
                }
                else if (RNum == 6)
                {

                    Ps[3].PPieces[3].IsActivePiece = true;
                    RedPiece4.Location = BoardPath[r4];
                }
                if (Ps[3].IsFinish)
                    MessageBox.Show(Turn.ToString() + " Wins!");

                MoveToNextPlayer();
            }
        }
    }
}