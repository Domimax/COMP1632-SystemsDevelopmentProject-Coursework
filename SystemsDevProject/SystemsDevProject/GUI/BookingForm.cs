using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemsDevProject
{
    public partial class BookingForm : Form
    {
        public Form UpperForm { get; set; }

        public BookingForm(Form upperForm)
        {
            InitializeComponent();
            UpperForm = upperForm;
            this.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> performances = new List<String>();
            performances.Clear();
            comboBox2.Items.Clear();

            //Check which option has been selected - indexing begins from 0
            if (comboBox1.SelectedIndex == 0)
            {
                DBSingleton.GetDBSingletonInstance.GetPerformance("Musical", performances);
                for (int i = 0; i < performances.Count; i++)
                {
                    comboBox2.Items.Add(performances[i]);
                }
                label2.Text = "Select Musical";
                comboBox2.Visible = true;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DBSingleton.GetDBSingletonInstance.GetPerformance("Play", performances);
                for (int i = 0; i < performances.Count; i++)
                {
                    comboBox2.Items.Add(performances[i]);
                }
                label2.Text = "Select Play";
                comboBox2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            UpperForm.Show();
        }
    }
}