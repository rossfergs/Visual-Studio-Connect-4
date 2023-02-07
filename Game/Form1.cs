using System;

namespace Connect4
{
    public partial class Form1 : Form
    {

        Button[,] btn = new Button[8,7];
        Color player = Color.Red;

        public Form1()
        {
            InitializeComponent();

            char text = ' ';

            for (int i = 1; i < 8; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    btn[i, j] = new Button();
                    btn[i, j].SetBounds(40 + (40 * i), 40 + (40 * j), 35, 35);
                    btn[i, j].BackColor = Color.DimGray;
                    btn[i, j].Text = Convert.ToString(text);
                    btn[i, j].Click += new EventHandler(btnEvent_Handler);
                    Controls.Add(btn[i, j]);
                }
            }
        }

        void btnEvent_Handler(object sender, EventArgs e)
        {
            placePiece(btn, ((Button)sender), player);
        }

        void placePiece(Button[,] btn, Button input, Color player)
        {
            if(input.BackColor == Color.DimGray)
            {
                input.BackColor = player;
            }

            movePieces(btn);

            if(player == Color.Red)
            {
                player = Color.Yellow;
            }
            else
            {
                player = Color.Red;
            }

        }

        void movePieces(Button[,] btn)
        {

            int width = btn.GetLength(0);
            int height = btn.GetLength(1);


            for (int i = 1; i < width; i++)
            {
                for (int j = 1; j < height; j++)
                {
                    if (btn[i, j].BackColor != Color.DimGray && btn[i+1, j+1].BackColor == Color.DimGray)
                    {
                        btn[i + 1, j + 1].BackColor = btn[i, j].BackColor;
                        btn[i, j].BackColor = Color.DimGray;
                        
                    }
                }
            }

        }
    }
}