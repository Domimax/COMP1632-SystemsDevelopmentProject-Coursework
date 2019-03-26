using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemsDevProject.GUI
{
    public partial class LoginForm : Form
    {
        public MainForm UpperForm { get; set; }

        public LoginForm(MainForm upperForm)
        {
            InitializeComponent();
            UpperForm = upperForm;
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked) {
                MessageBox.Show("You can\'t login as both employee and agency");
            }
            else if (checkBox1.Checked) {
                if (DBSingleton.GetDBSingletonInstance.GetUser(textBox1.Text, textBox2.Text, "Employee") == null)
                {
                    MessageBox.Show("Something went wrong. Please make sure you input all details correctly.");
                }
                else {
                    UpperForm.LoggedInUser = DBSingleton.GetDBSingletonInstance.GetUser(textBox1.Text, textBox2.Text, "Employee");
                    MessageBox.Show("You have logged in as: " + UpperForm.LoggedInUser.FirstName);
                    this.Close();
                }
            } else if (checkBox2.Checked) {
                if (DBSingleton.GetDBSingletonInstance.GetUser(textBox1.Text, textBox2.Text, "Agency") == null)
                {
                    MessageBox.Show("Something went wrong. Please make sure you input all details correctly.");
                }
                else
                {
                    UpperForm.LoggedInUser = DBSingleton.GetDBSingletonInstance.GetUser(textBox1.Text, textBox2.Text, "Agency");
                    MessageBox.Show("You have logged in as: " + UpperForm.LoggedInUser.FirstName);
                    this.Close();
                }
            } else {
                if (DBSingleton.GetDBSingletonInstance.GetUser(textBox1.Text, textBox2.Text, "Customer") == null)
                {
                    MessageBox.Show("Something went wrong. Please make sure you input all details correctly.");
                }
                else
                {
                    UpperForm.LoggedInUser = DBSingleton.GetDBSingletonInstance.GetUser(textBox1.Text, textBox2.Text, "Customer");
                    MessageBox.Show("You have logged in as: " + UpperForm.LoggedInUser.FirstName);
                    this.Close();
                }
            }
        }
    }
}
