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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            label9.Visible = false;
            label8.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            label8.Visible = false;
            string fName = textBox1.Text;
            string lName = textBox2.Text;
            string pNo = textBox3.Text;
            string userName = textBox4.Text;
            string password = textBox5.Text;
            if(fName.Length<1 || lName.Length<1 || pNo.Length<1 || userName.Length<1|| password.Length<1)
            {
                label9.Text = "Please Fill All The Fields";
                label9.Visible = true;
                return;
            }
            if(!password.Equals(textBox6.Text))
            {
                label8.Visible = true;
                return;
            }
            DataSets.Users userInfo = new DataSets.Users();
            userInfo.fName = fName;
            userInfo.lName = lName;
            userInfo.pNo = pNo;
            userInfo.userName = userName;
            userInfo.password = password;
            DataBaseManager dbm = new DataBaseManager();
            if(!dbm.addUser(userInfo))
            {
                label9.Text = "The User Is Already Exist";
                label9.Visible = true;
                return;
            }
            MessageBox.Show("The New User Has Been Added Successfully.");
            this.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
