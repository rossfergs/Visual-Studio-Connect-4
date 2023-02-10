using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class GameBoard : Form
    {   
        Button[,] btn = new Button[8, 7];
        Color player = Color.Red;
        Color aiColor = Color.Yellow;

        bool twoPlayer = false;
        Random rnd = new Random();
        int P1Counter = 0;
        int P2Counter = 0;
        String winner = null;
        public int aiColumn;
        public int aiPrevMove;
        public SoundPlayer soundPlayer;

        public GameBoard()
        {
            InitializeComponent();
            aiColumn = rnd.Next(1, 8);
            aiPrevMove = rnd.Next(1, 3);
            lblP1.Hide();
            lblP2.Hide();
            string filePath = @"piece.wav";
            soundPlayer = new SoundPlayer(filePath);
            checkForTwoPlayer();
            if(aiPrevMove == 1)
            {
                aiPrevMove = 1;
            }
            else
            {
                aiPrevMove = -1;
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    btn[i, j] = new Button();
                    btn[i, j].SetBounds(40 + (40 * i), 40 + (40 * j), 35, 35);
                    btn[i, j].BackColor = Color.DimGray;
                    btn[i, j].Text = Convert.ToString(' ');
                    btn[i, j].Click += new EventHandler(this.btnEvent_Handler);
                    Controls.Add(btn[i, j]);
                }
            }
        }

        bool checkForTwoPlayer()
        {
            DialogResult d;
            d = MessageBox.Show("Do you wish to play against AI? Press yes, or press no to play against 2nd player", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                twoPlayer = false;
            }
            else
            {
                twoPlayer = true;

            }
            return twoPlayer;
        }

        void btnEvent_Handler(object sender, EventArgs e)
        {          
            if (twoPlayer == false)
            {
                placePiece(btn, ((Button)sender), player);
                while (btn[aiColumn, 1].BackColor != Color.DimGray)
                {
                    aiColumn = rnd.Next(1, 8);
                }
                if (player == Color.Red)
                {
                    lblP2.Hide();
                    P1Counter++;
                    lblP1.Text = "Red score: " + P1Counter;
                    lblP1.BackColor = Color.Red;
                    lblP1.ForeColor = Color.White;
                    lblP1.Show();
                }
                P2Counter++;
                placePiece(btn, btn[aiColumn, 1], aiColor);
                aiColumn = moveAIColumn(rnd);
                checkForWinner();
            }
            else
            {
                placePiece(btn, ((Button)sender), player);
                if (player == Color.Red)
                {
                    lblP2.Hide();
                    player = Color.Yellow;
                    P1Counter++;
                    lblP1.Text = "Red score: " + P1Counter;
                    lblP1.BackColor = Color.Red;
                    lblP1.ForeColor = Color.White;
                    lblP1.Show();
                }
                else
                {
                    lblP1.Hide();
                    player = Color.Red;
                    P2Counter++;
                    lblP2.Text = "Yellow score " + P2Counter;
                    lblP2.BackColor = Color.Yellow;
                    lblP2.ForeColor = Color.Black;
                    lblP2.Show();
                }
                checkForWinner();
            }
            soundPlayer.Play();
        }

        int moveAIColumn(Random rnd)
        {
            int move = rnd.Next(1, 5);
            int result;

            if(aiColumn != 1 && aiColumn != 7)
            {
                System.Diagnostics.Debug.Write("PASSED 1");
                if(move == 1)
                {
                    result = aiColumn - aiPrevMove;
                    aiPrevMove = -aiPrevMove;
                    return result;
                }
                else if(move == 2)
                {
                    return aiColumn;
                }
                else
                {
                    result = aiColumn + aiPrevMove;
                    return result;
                }
            }
            else
            {
                if(aiColumn == 1) {
                    aiPrevMove = 1;
                    result = aiColumn + aiPrevMove;
                    return result;
                }
                else
                {
                    aiPrevMove = -1;
                    result = aiColumn + aiPrevMove;
                    return result;
                }
            }
        }

        void placePiece(Button[,] btn, Button input, Color player)
        {
            movePieces(btn);
            if (input.BackColor == Color.DimGray)
            {
                input.BackColor = player;
            }
        }

        void movePieces(Button[,] btn)
        {

            int width = btn.GetLength(0);
            int height = btn.GetLength(1);

            for (int i = 1; i < width; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    if (btn[i, j].BackColor != Color.DimGray && btn[i, j + 1].BackColor == Color.DimGray)
                    {
                        btn[i, j + 1].BackColor = btn[i, j].BackColor;
                        btn[i, j].BackColor = Color.DimGray;

                    }
                }
            }

        }


        void checkForWinner()
        {
            DialogResult d;
            DialogResult r;
            for (int rows = 7; rows >= 0; rows--)
            {
                for (int columns = 6; columns >= 0; columns--)
                {
                    if (btn[rows, columns].BackColor == Color.Yellow)
                    {
                        if (rows >= 0 && rows < btn.GetLength(0) && columns >= 0 && columns < btn.GetLength(1))
                        {
                            // Horizontal check for Yellow winner;
                            if (rows > 0 && btn[rows - 1, columns].BackColor == Color.Yellow)
                            {
                                if (rows > 1 && btn[rows - 2, columns].BackColor == Color.Yellow)
                                {
                                    if (rows > 2 && btn[rows - 3, columns].BackColor == Color.Yellow)
                                    {
                                        d = MessageBox.Show("Yellow wins with Score: " + P2Counter, "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        r = MessageBox.Show("Do you wish to play again?", "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (r == DialogResult.Yes)
                                        {
                                            this.Close();
                                            GameBoard t = new GameBoard();
                                            t.Show();
                                        }
                                        if (r == DialogResult.No)
                                        {
                                            Close();
                                        }
                                    }
                                }
                            }
                            // Vertical check for Yellow winner;
                            else if (columns > 2 && btn[rows, columns - 1].BackColor == Color.Yellow)
                            {
                                if (btn[rows, columns - 2].BackColor == Color.Yellow)
                                {
                                    if (btn[rows, columns - 3].BackColor == Color.Yellow)
                                    {
                                        d = MessageBox.Show("Yellow wins with Score: " + P2Counter, "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        r = MessageBox.Show("Do you wish to play again?", "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (r == DialogResult.Yes)
                                        {
                                            this.Close();
                                            GameBoard t = new GameBoard();
                                            t.Show();
                                        }
                                        if (r == DialogResult.No)
                                        {
                                            Close();
                                        }
                                    }
                                }
                            }
                            // Left-to-right diagonal check for Yellow winner;
                            else if (rows > 2 && columns < 4 && btn[rows - 1, columns + 1].BackColor == Color.Yellow)
                            {
                                if (btn[rows - 2, columns + 2].BackColor == Color.Yellow)
                                {
                                    if (btn[rows - 3, columns + 3].BackColor == Color.Yellow)
                                    {
                                        d = MessageBox.Show("Yellow wins with Score: " + P2Counter, "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        r = MessageBox.Show("Do you wish to play again?", "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (r == DialogResult.Yes)
                                        {
                                            this.Close();
                                            GameBoard t = new GameBoard();
                                            t.Show();
                                        }
                                        if (r == DialogResult.No)
                                        {
                                            Close();
                                        }
                                    }
                                }
                            }
                            // Right-to-left diagonal check for Yellow winner;
                            else if (rows > 2 && columns > 2 && btn[rows - 1, columns - 1].BackColor == Color.Yellow)
                            {
                                if (btn[rows - 2, columns - 2].BackColor == Color.Yellow)
                                {
                                    if (btn[rows - 3, columns - 3].BackColor == Color.Yellow)
                                    {
                                        d = MessageBox.Show("Yellow wins with Score: " + P2Counter, "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        r = MessageBox.Show("Do you wish to play again?", "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (r == DialogResult.Yes)
                                        {
                                            this.Close();
                                            GameBoard t = new GameBoard();
                                            t.Show();
                                        }
                                        if (r == DialogResult.No)
                                        {
                                            Close();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //Red checks
                    else if (btn[rows, columns].BackColor == Color.Red)
                    {
                        if (rows >= 0 && rows < btn.GetLength(0) && columns >= 0 && columns < btn.GetLength(1))
                        {
                            // Horizontal check for Yellow winner;
                            if (rows > 0 && btn[rows - 1, columns].BackColor == Color.Red)
                            {
                                if (rows > 1 && btn[rows - 2, columns].BackColor == Color.Red)
                                {
                                    if (rows > 2 && btn[rows - 3, columns].BackColor == Color.Red)
                                    {
                                        d = MessageBox.Show("Red wins with Score: " + P1Counter, "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        r = MessageBox.Show("Do you wish to play again?", "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (r == DialogResult.Yes)
                                        {
                                            this.Close();
                                            GameBoard t = new GameBoard();
                                            t.Show();
                                        }
                                        if (r == DialogResult.No)
                                        {
                                            Close();
                                        }
                                    }
                                }
                            }
                            // Vertical check for Red winner;
                            else if (columns > 2 && btn[rows, columns - 1].BackColor == Color.Red)
                            {
                                if (btn[rows, columns - 2].BackColor == Color.Red)
                                {
                                    if (btn[rows, columns - 3].BackColor == Color.Red)
                                    {
                                        d = MessageBox.Show("Red wins with Score: " + P1Counter, "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        r = MessageBox.Show("Do you wish to play again?", "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (r == DialogResult.Yes)
                                        {
                                            this.Close();
                                            GameBoard t = new GameBoard();
                                            t.Show();
                                        }
                                        if (r == DialogResult.No)
                                        {
                                            Close();
                                        }
                                    }
                                }
                            }
                            // Left-to-right diagonal check for Red winner;
                            else if (rows > 2 && columns < 4 && btn[rows - 1, columns + 1].BackColor == Color.Red)
                            {
                                if (btn[rows - 2, columns + 2].BackColor == Color.Red)
                                {
                                    if (btn[rows - 3, columns + 3].BackColor == Color.Red)
                                    {
                                        d = MessageBox.Show("Red wins with Score: " + P1Counter, "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        r = MessageBox.Show("Do you wish to play again?", "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (r == DialogResult.Yes)
                                        {
                                            this.Close();
                                            GameBoard t = new GameBoard();
                                            t.Show();
                                        }
                                        if (r == DialogResult.No)
                                        {
                                            Close();
                                        }
                                    }
                                }
                            }
                            // Right-to-left diagonal check for Red winner;
                            else if (rows > 2 && columns > 2 && btn[rows - 1, columns - 1].BackColor == Color.Red)
                            {
                                if (btn[rows - 2, columns - 2].BackColor == Color.Red)
                                {
                                    if (btn[rows - 3, columns - 3].BackColor == Color.Red)
                                    {
                                        d = MessageBox.Show("Red wins with Score: " + P1Counter, "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        r = MessageBox.Show("Do you wish to play again?", "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (r == DialogResult.Yes)
                                        {
                                            this.Close();
                                            GameBoard t = new GameBoard();
                                            t.Show();
                                        }
                                        if (r == DialogResult.No)
                                        {
                                            Close();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

}
