using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KennellProject2
{
    public partial class Introduction : Form
    {
        public Introduction()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens the main shopping form
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Opens the help form
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Help help = new Help();
            help.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
