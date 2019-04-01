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
    public partial class ReviewForm : Form
    {
        public ReviewForm()
        {
            InitializeComponent();
        }

        //coding submit button
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex.ToString() != null && dateTimePicker1.Value != null && richTextBox1.Text != null && richTextBox1.Text != "")
            {
                string name = comboBox1.SelectedIndex.ToString();
                string review = richTextBox1.Text;
                DateTime date = dateTimePicker1.Value;
                try
                {
                    
                    MessageBox.Show("Thank you. Your review has been saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to connect to database. Error: " + ex);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please ensure all fields have been filled out correctly");
            }
        }
    }
}
