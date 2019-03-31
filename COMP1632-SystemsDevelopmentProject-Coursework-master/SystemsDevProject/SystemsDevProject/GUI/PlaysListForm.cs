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
    public partial class PlaysListForm : Form, ILogin
    {
        public List<Play> AllPlays { get; set; }
        public Play ChosenPlay { get; set; }
        public MainForm UpperForm { get; set; }


        public PlaysListForm(MainForm upperForm)
        {
            InitializeComponent();
            UpperForm = upperForm;
            AllPlays = DBSingleton.GetDBSingletonInstance.GetPlays();
            foreach (Play play in AllPlays)
            {
                listBox1.Items.Add(play.PlayName);
            }
            listBox1.SelectedIndex = 0;
            if (UpperForm.LoggedInUser != null) {
                this.label3.Text = "Logged in as: " + UpperForm.LoggedInUser.FirstName + " " + UpperForm.LoggedInUser.LastName;
            }
            label2.Text = button1.Text = "View available dates, reviews and additional information about the play.";
            button1.Text = "View for: \"" + listBox1.SelectedItem + "\".";
            this.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Play play in AllPlays)
            {
                if (play.PlayName.Equals(listBox1.SelectedItem))
                {
                    ChosenPlay = play;
                    button1.Text = "View for: \"" + listBox1.SelectedItem + "\".";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlayInfoForm booking = new PlayInfoForm(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpperForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(UpperForm, this);
        }

        public void UpdateLoggedInUserName() {
            UpperForm.UpdateLoggedInUserName();
            this.label3.Text = "Logged in as: " + UpperForm.LoggedInUser.FirstName + " " + UpperForm.LoggedInUser.LastName;
        }

        private void PlaysListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UpperForm.Visible == false) {
                Application.Exit();
            }
        }
    }
}
