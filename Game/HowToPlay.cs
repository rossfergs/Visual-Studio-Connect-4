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
    public partial class HowToPlay : Form
    {
        public HowToPlay()
        {
            InitializeComponent();
            DialogResult d;
            d = MessageBox.Show("Rules: Each player will take turns consecutively. Red will always be first to pick. All tiles will be placed to the lowest empty tile row slot.", "Rules", MessageBoxButtons.OK);
        }
    }
}
