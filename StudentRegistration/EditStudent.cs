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
    public partial class EditStudent : Form
    {
        List<DataSets.student> student;
        DataBaseManager dbm = new DataBaseManager();
        List<DataSets.intake> intakes;
        public EditStudent()
        {
            InitializeComponent();
            label9.Visible = false;
            loadStudent();
        }
        public void loadStudent()
        {
            student = dbm.getStudents();
            intakes = dbm.getIntakes();
            comboBox2.Items.Clear();
            foreach (DataSets.student temp in student)
                comboBox2.Items.Add(temp.id);
            comboBox1.Items.Clear();
            foreach (DataSets.intake temp in intakes)
                comboBox1.Items.Add(temp.code);
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
        }
        public void notDelete()
        {
            button1.Enabled = false;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(DataSets.student temp in student)
            {
                if(comboBox2.SelectedItem.ToString().Equals(temp.id))
                {
                    comboBox1.SelectedItem = temp.intake;
                    textBox2.Text = temp.fname;
                    textBox3.Text = temp.lname;
                    textBox4.Text = temp.pno;
                    textBox6.Text = temp.address;
                    dateTimePicker1.Value = temp.bd;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            string studentId = comboBox2.SelectedItem.ToString();
            string intake = comboBox1.SelectedItem.ToString();
            string fName = textBox2.Text;
            string lName = textBox3.Text;
            string pNo = textBox4.Text;
            DateTime bd = dateTimePicker1.Value;
            string address = textBox6.Text;
            if (studentId.Length < 2 || intake.Length < 2 || fName.Length < 2 || lName.Length < 2
                || pNo.Length < 2 || address.Length < 2)
            {
                label9.Text = "Please Fill All The Fields";
                label9.Visible = true;
                return;
            }
            DataSets.student studentInfo = new DataSets.student();
            studentInfo.id = studentId;
            studentInfo.intake = intake;
            studentInfo.fname = fName;
            studentInfo.lname = lName;
            studentInfo.pno = pNo;
            studentInfo.bd = bd;
            studentInfo.address = address;
            dbm.updateStudent(studentInfo);   
            MessageBox.Show("The New Student Has Been Updated Successfully.");
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentId = comboBox2.SelectedItem.ToString();

            dbm.deleteStudent(studentId);
            MessageBox.Show("The New Student Has Been Deleted Successfully.");
            this.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
