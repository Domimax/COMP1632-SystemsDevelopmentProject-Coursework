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
using SystemsDevProject.GUI;
using SystemsDevProject.Model;

namespace SystemsDevProject
{
    public partial class MainForm : Form
    {
        public List<Play> CurrentPlays { get; set; }
        public User LoggedInUser { get; set; }

        public MainForm()
        {
            InitializeComponent();
            LoadPlays();
        }

        private void LoadPlays()
        {
            CurrentPlays = DBSingleton.GetDBSingletonInstance.GetPlays();
            LoggedInUser = null;
            pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CurrentPlays[0].PictureString + ".jpg");
            pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CurrentPlays[1].PictureString + ".jpg");
            pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CurrentPlays[2].PictureString + ".jpg");
        }

        //code for the 'write a review' button
        private void button3_Click(object sender, EventArgs e)
        {
            ReviewForm form = new ReviewForm();
            form.Show();
        }

        //code for the 'discount' button
        private void button4_Click(object sender, EventArgs e)
        {

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
    }
}
