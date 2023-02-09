﻿using System;
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
            placePiece(btn, ((Button)sender), player);
            if (player == Color.Red)
            {
                player = Color.Yellow;
            }
            else
            {
                player = Color.Red;
            }
            checkForWinner();
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
                                        d = MessageBox.Show("Yellow wins!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                        d = MessageBox.Show("Yellow wins!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                        d = MessageBox.Show("Yellow wins!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                        d = MessageBox.Show("Yellow wins!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
