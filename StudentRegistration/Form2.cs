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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 F2 = new Form4();
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

        private void button2_Click(object sender, EventArgs e)
        {
            EditClerk F2 = new EditClerk();
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

        private void button3_Click(object sender, EventArgs e)
        {
            AddIntake F2 = new AddIntake();
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

        private void button4_Click(object sender, EventArgs e)
        {
            EditIntake F2 = new EditIntake();
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

        private void button5_Click(object sender, EventArgs e)
        {
            AddStudent F2 = new AddStudent();
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

        private void button6_Click(object sender, EventArgs e)
        {
            EditStudent F2 = new EditStudent();
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

        private void button7_Click(object sender, EventArgs e)
        {
            View_Student F2 = new View_Student();
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

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
