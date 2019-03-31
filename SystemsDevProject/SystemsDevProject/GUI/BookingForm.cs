using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace SystemsDevProject
{
    public partial class BookingForm : Form
    {
        public MainForm UpperForm { get; set; }

        public BookingForm(MainForm upperForm)
        {
            InitializeComponent();
            UpperForm = upperForm;
            List<Play> plays = UpperForm.AllPlays;
            label5.Text = String.Format("{0, 15} {1, 30} {2, 15} {3, 15} {4, 15}", "Name of Play", "Date of Performance", "Seat", "Price", "Discounted");
            foreach (Play play in plays)
            {
                foreach (Performance performance in play.PlayPerformances)
                {
                    foreach (Band band in performance.PerformanceBands)
                    {
                        foreach (Seat seat in band.BandSeats)
                        {
                            foreach (Ticket ticket in UpperForm.CurrentBooking.BookingTickets)
                            {
                                if (ticket.TicketSeat.SeatID == seat.SeatID)
                                {
                                    listBox1.Items.Add(String.Format("{0, 15} {1, 30} {2, 15} {3, 15} {4, 15}", play.PlayName, performance.PerformanceDate, band.BandNumber + seat.SeatNumber,
                                        ticket.TicketPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")), ticket.TicketType == "Discounted" ? "Yes" : "No"));
                                }
                            }
                        }
                    }
                }
            }
            label4.Text = UpperForm.CurrentBooking.TotalCost.ToString("C", CultureInfo.CreateSpecificCulture("en-GB"));
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpperForm.Show();
            this.Close();
        }

        private void BookingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UpperForm.Visible != true) {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ticket removal
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //discount application
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //confirmation of booking
        }
    }
}