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
    public partial class EditIntake : Form
    {
        List<DataSets.intake> intakes;
        DataBaseManager dbm = new DataBaseManager();
        public EditIntake()
        {
            InitializeComponent();
            loadIntake();
            label9.Visible = false;
        }
        public void notDelete()
        {
            button1.Enabled = false;
        }
        public void loadIntake()
        {
            intakes = dbm.getIntakes();
            comboBox1.Items.Clear();
            foreach (DataSets.intake temp in intakes)
                comboBox1.Items.Add(temp.code);
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(DataSets.intake temp in intakes)
            {
                if(temp.code.Equals(comboBox1.SelectedItem.ToString()))
                {
                    dateTimePicker1.Value = temp.date;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataSets.intake intakeInfo = new DataSets.intake();
            intakeInfo.code = comboBox1.SelectedItem.ToString();
            intakeInfo.date = dateTimePicker1.Value;
            dbm.updateIntake(intakeInfo);
            MessageBox.Show("The Intake Has Been Updated Successfully.");
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSets.intake intakeInfo = new DataSets.intake();
            intakeInfo.code = comboBox1.SelectedItem.ToString();
            intakeInfo.date = dateTimePicker1.Value;
            dbm.DeleteIntake(intakeInfo);
            MessageBox.Show("The Intake Has Been Deleted Successfully.");
            this.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
