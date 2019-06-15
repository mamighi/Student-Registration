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
    public partial class AddStudent : Form
    {
        DataBaseManager dbm= new DataBaseManager();
        public AddStudent()
        {
            InitializeComponent();
            loadIntakes();
            label9.Visible=false;
            
        }
        public void loadIntakes()
        {
            comboBox1.Items.Clear();
            List<DataSets.intake> intakes=dbm.getIntakes();
            foreach(DataSets.intake temp in intakes)
                comboBox1.Items.Add(temp.code);
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label9.Visible=false;
            string studentId= textBox1.Text;
            string intake=comboBox1.SelectedItem.ToString();
            string fName=textBox2.Text;
            string lName=textBox3.Text;
            string pNo= textBox4.Text;
            DateTime bd=dateTimePicker1.Value;
            string address= textBox6.Text;
            if(studentId.Length<2 || intake.Length<2 || fName.Length<2 || lName.Length<2
                ||pNo.Length<2|| address.Length<2)
            {
                label9.Text="Please Fill All The Fields";
                label9.Visible=true;
                return;
            }
            DataSets.student studentInfo= new DataSets.student();
            studentInfo.id=studentId;
            studentInfo.intake=intake;
            studentInfo.fname=fName;
            studentInfo.lname=lName;
            studentInfo.pno=pNo;
            studentInfo.bd=bd;
            studentInfo.address=address;
            if(dbm.addStudent(studentInfo))
            {
                MessageBox.Show("The New Student Has Been Added Successfully.");
                this.Dispose();
            }
            label9.Text="The Student Is Already Exist";
            label9.Visible=true;
        }
        public void notDelete()
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        
        }
    }
}
