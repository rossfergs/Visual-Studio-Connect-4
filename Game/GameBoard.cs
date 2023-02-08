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

            int counter = 1;

            while (board[input, counter].BackColor == Color.DimGray)
            {
                counter += 1;
            }

            board[input, counter].BackColor = player;

        }

        void checkForWinner()
        {
            DialogResult d;
            for (int rows = 7; rows > 0; rows--)
            {
                for (int columns = 6; columns > 0; columns--)
                {
                    if (btn[rows, columns].BackColor == Color.Blue)
                    {
                        if (btn[rows - 1, columns].BackColor == Color.Blue)
                        {
                            if (btn[rows - 2, columns].BackColor == Color.Blue)
                            {
                                if (btn[rows - 3, columns].BackColor == Color.Blue)
                                {
                                    d = MessageBox.Show("Blue wins!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else if (btn[rows, columns - 1].BackColor == Color.Blue)
                        {
                            if (btn[rows, columns - 2].BackColor == Color.Blue)
                            {
                                if (btn[rows, columns - 3].BackColor == Color.Blue)
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
