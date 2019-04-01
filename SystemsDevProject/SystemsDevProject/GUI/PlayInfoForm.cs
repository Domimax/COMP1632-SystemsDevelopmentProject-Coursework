using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemsDevProject.Model;

namespace SystemsDevProject.GUI
{
    public partial class PlayInfoForm : Form, ILogin
    {
        public PlaysListForm UpperForm { get; set; }
        public Performance ChosenPerformance { get; set; }
        
        public PlayInfoForm(PlaysListForm upperForm)
        {
            InitializeComponent();
            UpperForm = upperForm;
            nameLabel.Text = UpperForm.ChosenPlay.PlayName;
            durationLabel.Text = UpperForm.ChosenPlay.PlayDuration + "";
            castLabel.Text = UpperForm.ChosenPlay.PlayCast;
            pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UpperForm.ChosenPlay.PictureString + ".jpg");
            foreach (Performance performance in UpperForm.ChosenPlay.PlayPerformances)
            {
                listBox1.Items.Add(performance.PerformanceDate);
            }
            if (UpperForm.ChosenPlay.PlayPerformances.Count != 0)
            {
                ChosenPerformance = UpperForm.ChosenPlay.PlayPerformances[0];
                listBox1.SelectedIndex = 0;
            }
            if (UpperForm.UpperForm.LoggedInUser != null)
            {
                this.label5.Text = "Logged in as: " + UpperForm.UpperForm.LoggedInUser.FirstName + " " + UpperForm.UpperForm.LoggedInUser.LastName;
            }
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpperForm.Show();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Performance performance in UpperForm.ChosenPlay.PlayPerformances)
            {
                if (performance.PerformanceDate.Equals(listBox1.SelectedItem))
                {
                    ChosenPerformance = performance;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UpperForm.UpperForm.LoggedInUser == null)
            {
                MessageBox.Show("You have to login first to be able to book a date.");
            }
            else
            {
                SeatPlan seatPlan = new SeatPlan(this);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(UpperForm.UpperForm, this);
        }

        public void UpdateLoggedInUserName()
        {
            UpperForm.UpdateLoggedInUserName();
            this.label5.Text = "Logged in as: " + UpperForm.UpperForm.LoggedInUser.FirstName + " " + UpperForm.UpperForm.LoggedInUser.LastName;
        }

        public void UpdateEnabledProperty(bool enabled)
        {
            this.Enabled = enabled;
            this.Focus();
        }

        private void PlayInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UpperForm.Visible == false)
            {
                Application.Exit();
            }
        }

        //Update the lists everytime the form is load
        private void PlayInfoForm_Load(object sender, EventArgs e)
        {
            
            //A list to store the rating given, and a list to store the actual review
             List<String> reviewList =  new List<String>();
         List<int> reviewRating = new List<int>();
            DBSingleton.GetDBSingletonInstance.readReview(UpperForm.ChosenPlay.PlayID, reviewList, reviewRating);
            //for loop to add each review to the listbox
                for (int i = 0; i < reviewList.Count; i++)
            {
                listBox2.Items.Add(reviewList[i] + "                       Rating (out of 5): " + reviewRating[i]);
            }
        }
    }
}
