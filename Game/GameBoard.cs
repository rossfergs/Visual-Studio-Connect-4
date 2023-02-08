using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            for (int i = 1; i < 8; i++)
            {
                for (int j = 1; j < 7; j++)
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
    }
}
