using System.Media;

namespace Game
{
    public partial class Menu : Form
    {
        public Label lblName { get; set; }
        public SoundPlayer soundPlayer;
        public Menu()
        {
            InitializeComponent();
            lbl_name.Hide();
            string filePath = @"music.wav";
            soundPlayer = new SoundPlayer(filePath);
            soundPlayer.Play();
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
            DialogResult d;
            d = MessageBox.Show("Rules: Each player will take turns consecutively. Red will always be first to pick. All tiles will be placed to the lowest empty tile row slot \n \nThe user can pick where to place the tile by simply clicking on the slot they want to insert the tile in", "Rules", MessageBoxButtons.OK, MessageBoxIcon.Information);
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