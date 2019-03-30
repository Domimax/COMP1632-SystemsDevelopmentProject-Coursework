using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemsDevProject.Model;

namespace SystemsDevProject.GUI
{
    public partial class LoginForm : Form
    {
        public MainForm UpperMainForm { get; set; }
        public ILogin UpperForm { get; set; }


        public LoginForm(MainForm upperMainForm, ILogin upperForm)
        {
            InitializeComponent();
            UpperMainForm = upperMainForm;
            UpperForm = upperForm;
            UpperForm.UpdateEnabledProperty(false);
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = DBSingleton.GetDBSingletonInstance.GetUser(textBox1.Text, textBox2.Text);
            if (user == null)
            {
                MessageBox.Show("Something went wrong. Please make sure you input all details correctly.");
            }
            else
            {
                UpperMainForm.LoggedInUser = user;
                UpperForm.UpdateLoggedInUserName();
                MessageBox.Show("You have logged in as: " + UpperMainForm.LoggedInUser.FirstName);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm(this);
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpperForm.UpdateEnabledProperty(true);
        }
    }
}
