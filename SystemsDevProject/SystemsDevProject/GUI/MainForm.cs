using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SystemsDevProject.GUI;
using SystemsDevProject.Model;

namespace SystemsDevProject
{
    public partial class MainForm : Form, ILogin
    {
        public User LoggedInUser { get; set; }

        public MainForm()
        {
            InitializeComponent();
            LoggedInUser = null;
        }
        
        public void UpdateLoggedInUserName()
        {
            this.label2.Text = "Logged in as: " + LoggedInUser.FirstName + " " + LoggedInUser.LastName;
        }

        public void UpdateEnabledProperty(bool enabled) {
            this.Enabled = enabled;
            this.Focus();
        }

        //code for the 'write a review' button
        private void button3_Click(object sender, EventArgs e)
        {
            ReviewForm form = new ReviewForm();
            form.Show();
        }

        //code for the 'make a booking' button
        private void button5_Click(object sender, EventArgs e)
        {
            BookingForm form = new BookingForm(this);
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlaysListForm playsListForm = new PlaysListForm(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(this, this);
            this.Enabled = false;
        }
    }
}
