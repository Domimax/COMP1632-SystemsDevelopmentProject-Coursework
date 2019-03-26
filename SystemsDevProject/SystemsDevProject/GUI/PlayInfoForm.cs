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
    public partial class PlayInfoForm : Form
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
            ChosenPerformance = UpperForm.ChosenPlay.PlayPerformances[0];
            listBox1.SelectedIndex = 0;
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            UpperForm.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Performance performance in UpperForm.ChosenPlay.PlayPerformances)
            {
                if (performance.PerformanceDate.Equals(listBox1.SelectedItem)) {
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(UpperForm.UpperForm);
        }
    }
}
