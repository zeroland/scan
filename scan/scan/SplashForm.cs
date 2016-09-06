using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace scan
{
    public partial class SplashForm : Form
    {
     
        public SplashForm()
        {
            InitializeComponent();
        }

       

      
        private void ProgressForm_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
        }

     

      
    }
}
