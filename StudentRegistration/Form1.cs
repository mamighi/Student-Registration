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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            DataBaseManager dbm = new DataBaseManager();
            string userName = textBox1.Text.ToLower();
            string password = textBox2.Text;
            int res = dbm.login(userName, password);
            if (res == -1)
                label4.Visible = true;
            else if(res==0)
            {
                Form2 F2 = new Form2();
                F2.Height = this.Height;
                F2.Width = this.Width;
                F2.ControlBox = false;
                F2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                F2.TopLevel = false;
                panel1.Controls.Add(F2);
                F2.Dock = DockStyle.Fill;
                F2.BringToFront();
                F2.Visible = true;
            }
            else
            {
                Form3 F2 = new Form3();
                F2.Height = this.Height;
                F2.Width = this.Width;
                F2.ControlBox = false;
                F2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                F2.TopLevel = false;
                panel1.Controls.Add(F2);
                F2.Dock = DockStyle.Fill;
                F2.BringToFront();
                F2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
