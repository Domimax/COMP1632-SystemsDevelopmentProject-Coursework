﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SystemsDevProject.GUI;
using SystemsDevProject.Model;

namespace SystemsDevProject
{
    public partial class MainForm : Form, ILogin
    {
        public List<Play> AllPlays { get; set; }
        public User LoggedInUser { get; set; }
        public Booking CurrentBooking { get; set; }

        public MainForm()
        {
            InitializeComponent();
            AllPlays = DBSingleton.GetDBSingletonInstance.GetPlays();
            LoggedInUser = null;
            CurrentBooking = new Booking();
            CurrentBooking.BookingTickets = new List<Ticket>();
            CurrentBooking.TotalCost = 0.0;
            pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LionKing" + ".jpg");
            pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Faust" + ".jpg");
            pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dracula" + ".jpg");
            pictureBox4.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Basket" + ".jpg");
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
            if (this.LoggedInUser == null)
            {
                MessageBox.Show("You must be logged in to leave a review. Please log in and try again.");
            }
            else
            {
                ReviewForm form = new ReviewForm(this);
                form.Show();
            }
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            BookingForm bookingForm = new BookingForm(this);
            this.Hide();
        }
    }
}
