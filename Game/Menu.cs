namespace Game
{
    public partial class Menu : Form
    {
        public Label lblName { get; set; }
        public Menu()
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
            lblName = lbl_name;
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

        private void lbl_name_Click(object sender, EventArgs e)
        {

        }
    }
}