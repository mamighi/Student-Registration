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
    public partial class EditClerk : Form
    {
        List<DataSets.Users> userInfo;
        DataBaseManager dbm = new DataBaseManager();
        public EditClerk()
        {
            InitializeComponent();
            loadUsers();
            label8.Visible = false;
            label9.Visible = false;
        }
        public void loadUsers()
        {
            userInfo = dbm.getUsers();
            comboBox1.Items.Clear();
            foreach (DataSets.Users temp in userInfo)
                comboBox1.Items.Add(temp.userName);
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex=0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(DataSets.Users temp in userInfo)
            {
                if(temp.userName.Equals(comboBox1.SelectedItem.ToString()))
                {
                    textBox1.Text = temp.fName;
                    textBox2.Text = temp.lName;
                    textBox3.Text = temp.pNo;
                    textBox5.Text =
                        textBox6.Text = temp.password;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            label9.Visible = false;
            string fName = textBox1.Text;
            string lName = textBox2.Text;
            string pNo = textBox3.Text;
            string userName = comboBox1.SelectedItem.ToString();
            string password = textBox5.Text;
            if (fName.Length < 1 || lName.Length < 1 || pNo.Length < 1 || userName.Length < 1 || password.Length < 1)
            {
                label9.Text = "Please Fill All The Fields";
                label9.Visible = true;
                return;
            }
            if (!password.Equals(textBox6.Text))
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
            dbm.updateUser(userInfo);
            MessageBox.Show("The User Has Been Updated Successfully.");
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = comboBox1.SelectedItem.ToString(); 
            if(userName.Equals("admin"))
            {
                MessageBox.Show("Admin Cannot Be Deleted.");
                return;
            }
            DataSets.Users userInfo = new DataSets.Users();
            userInfo.userName = userName;
            dbm.deleteUser(userInfo);
            MessageBox.Show("The User Has Been Deleted Successfully.");
            this.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
