using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistration
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            Form1 F1 = new Form1();
            F1.Width = this.Width-5;
            F1.Height = this.Height-5;
            F1.ControlBox = false;
            F1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            F1.MdiParent = this;
            F1.Show();
        }
    }
}
