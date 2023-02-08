using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class GameBoard : Form
    {
        Button[,] btn = new Button[8, 7];
        Color player = Color.Red;
        bool hasWonYet = false;
        public GameBoard()
        {
            InitializeComponent();
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

        void btnEvent_Handler(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Blue;
            checkForWinner();
        }

        void placePiece(int input, Button[,] board, Color player)
        {
            for (int rows = 7; rows >= 0; rows--)
            {
                if (input > rows) continue;
                int counter = 0;
                while (counter < 7 && btn[counter, input].BackColor != Color.Blue)
                {
                    counter += 1;
                }

                if (counter < 7 && btn[7, input].BackColor == Color.Blue)
                {
                    btn[counter, input].BackColor = player;
                    break;
                }
            }
        }

        void checkForWinner()
        {
            DialogResult d;
            for (int rows = 7; rows >= 0; rows--)
            {
                for (int columns = 6; columns >= 0; columns--)
                {
                    if (btn[rows, columns].BackColor == Color.Blue)
                    {
                        if (rows >= 0 && rows < btn.GetLength(0) && columns >= 0 && columns < btn.GetLength(1))
                        {
                            // Horizontal check for blue winner;
                            if (rows > 0 && btn[rows - 1, columns].BackColor == Color.Blue)
                            {
                                if (rows > 1 && btn[rows - 2, columns].BackColor == Color.Blue)
                                {
                                    if (rows > 2 && btn[rows - 3, columns].BackColor == Color.Blue)
                                    {
                                        d = MessageBox.Show("Blue wins!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            // Vertical check for blue winner;
                            else if (columns > 2 && btn[rows, columns - 1].BackColor == Color.Blue)
                            {
                                if (btn[rows, columns - 2].BackColor == Color.Blue)
                                {
                                    if (btn[rows, columns - 3].BackColor == Color.Blue)
                                    {
                                        d = MessageBox.Show("Blue wins!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            // Left-to-right diagonal check for blue winner;
                            else if (rows > 2 && columns < 4 && btn[rows - 1, columns + 1].BackColor == Color.Blue)
                            {
                                if (btn[rows - 2, columns + 2].BackColor == Color.Blue)
                                {
                                    if (btn[rows - 3, columns + 3].BackColor == Color.Blue)
                                    {
                                        d = MessageBox.Show("Blue wins!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            // Right-to-left diagonal check for blue winner;
                            else if (rows > 2 && columns > 2 && btn[rows - 1, columns - 1].BackColor == Color.Blue)
                            {
                                if (btn[rows - 2, columns - 2].BackColor == Color.Blue)
                                {
                                    if (btn[rows - 3, columns - 3].BackColor == Color.Blue)
                                    {
                                        d = MessageBox.Show("Blue wins!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
