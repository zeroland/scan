using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace scan
{
    public partial class NavForm : Form
    {
        public NavForm()
        {
            InitializeComponent();
        }

        private void userPictureBox_Click(object sender, EventArgs e)
        {
            UserManager userManager = new UserManager();
            if (userManager.ShowDialog() == DialogResult.OK)
            {
                userManager.Show();

            }
            else
            {
                userManager.Close();
                GC.Collect();
            }

        }

        private void configPictureBox_Click(object sender, EventArgs e)
        {
            ConfigManager configManager = new ConfigManager();
            if (configManager.ShowDialog() == DialogResult.OK)
            {
                configManager.Show();

            }
            else
            {
                configManager.Close();
                GC.Collect();
            }
        }
    }
}
