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
            List<Play> plays = DBSingleton.GetDBSingletonInstance.GetPlays();
            label5.Text = String.Format("{0, 15} {1, 30} {2, 15} {3, 15}", "Name of Play", "Date of Performance", "Seat", "Price");
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
                                    listBox1.Items.Add(String.Format("{0, 15} {1, 30} {2, 15} {3, 15}", play.PlayName, performance.PerformanceDate, band.BandNumber + seat.SeatNumber,
                                        ticket.TicketPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-GB"))));
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
            this.Close();
            UpperForm.Show();
        }

        private void BookingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}