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
    public partial class View_Student : Form
    {
        List<DataSets.intake> intakes;
        DataBaseManager dbm = new DataBaseManager();
        List<DataSets.student> student;
        public View_Student()
        {
            InitializeComponent();
            loadIntakes();
        }
        public void loadIntakes()
        {
            intakes = dbm.getIntakes();
            student = dbm.getStudents();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("ALL");
            foreach (DataSets.intake temp in intakes)
                comboBox1.Items.Add(temp.code);
            comboBox1.SelectedIndex = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (comboBox1.SelectedItem.ToString().Equals("ALL"))
            {
                foreach(DataSets.student temp in student)
                {
                    string[] row = { temp.id,temp.fname,temp.lname,temp.intake,temp.pno,temp.address};
                    ListViewItem listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
            }
            else
            {
                foreach (DataSets.student temp in student)
                {
                    if(comboBox1.SelectedItem.ToString().Equals(temp.intake))
                    {
                        string[] row = { temp.id, temp.fname, temp.lname, temp.intake, temp.pno, temp.address };
                        ListViewItem listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
