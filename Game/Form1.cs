<<<<<<< HEAD
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
=======
namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbl_name.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_username_TextChanged(object sender, EventArgs e)
        {
            lbl_name.Text = "You are signed in as: " + txt_username.Text;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Form game = new GameBoard();
            game.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lbl_name.Show();
            txt_username.Hide();
            btn_Apply.Hide();
        }

        private void btn_Tut_Click(object sender, EventArgs e)
        {
            Form T = new HowToPlay();
            T.Show();
            Hide();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
>>>>>>> parent of bd7087b (Added WIP Game files)
}