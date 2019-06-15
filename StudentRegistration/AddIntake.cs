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
    public partial class AddIntake : Form
    {
        public AddIntake()
        {
            InitializeComponent();
            label9.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            string code = textBox1.Text;
            DateTime date = dateTimePicker1.Value;
            if(code.Length<2)
            {
                label9.Text = "Please Fill All The Field.";
                label9.Visible = true;
                return;
            }
            DataSets.intake intakeInfo = new DataSets.intake();
            intakeInfo.code = code;
            intakeInfo.date = date;

            DataBaseManager dbm = new DataBaseManager();
            if (dbm.addIntake(intakeInfo))
            {
                MessageBox.Show("The New Intake Has Been Added Successfuly.");
                this.Dispose();
            }
            else
            {
                label9.Text = "The Intake Is Already Exist";
                label9.Visible = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
