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
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
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
            if (UpperForm.Visible != true)
            {
                Application.Exit();
            }
        }

        //Ticket removal
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Play play in UpperForm.AllPlays)
            {
                foreach (Performance performance in play.PlayPerformances)
                {
                    foreach (Band band in performance.PerformanceBands)
                    {
                        foreach (Seat seat in band.BandSeats)
                        {
                            if (seat.SeatID == UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketSeat.SeatID)
                            {
                                seat.Occupied = false;
                            }
                        }
                    }
                }
            }
            UpperForm.CurrentBooking.TotalCost -= UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketPrice;
            label4.Text = UpperForm.CurrentBooking.TotalCost.ToString("C", CultureInfo.CreateSpecificCulture("en-GB"));
            UpperForm.CurrentBooking.BookingTickets.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("You are being returned to the main screen as your basket is empty.");
                UpperForm.Show();
                this.Close();
            }
        }

        //Apply discount
        private void button4_Click(object sender, EventArgs e)
        {
            if (UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketType == "Discounted")
            {
                MessageBox.Show("The ticket is already discounted.");
            }
            else
            {
                UpperForm.CurrentBooking.TotalCost -= UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketPrice;
                UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketPrice *= 0.75;
                UpperForm.CurrentBooking.TotalCost += UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketPrice;
                label4.Text = UpperForm.CurrentBooking.TotalCost.ToString("C", CultureInfo.CreateSpecificCulture("en-GB"));
                UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketType = "Discounted";
                List<Play> plays = UpperForm.AllPlays;
                foreach (Play play in plays)
                {
                    foreach (Performance performance in play.PlayPerformances)
                    {
                        foreach (Band band in performance.PerformanceBands)
                        {
                            foreach (Seat seat in band.BandSeats)
                            {
                                if (UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketSeat.SeatID == seat.SeatID)
                                {
                                    listBox1.Items[listBox1.SelectedIndex] = String.Format("{0, 15} {1, 30} {2, 15} {3, 15} {4, 15}",
                                        play.PlayName, performance.PerformanceDate, band.BandNumber + seat.SeatNumber,
                                        UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")),
                                        UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketType == "Discounted" ? "Yes" : "No");
                                }
                            }
                        }
                    }
                }
            }
        }

        //confirmation of booking
        private void button3_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm(this);
            this.Hide();
        }

        //discount removal
        private void button5_Click(object sender, EventArgs e)
        {
            if (UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketType != "Discounted")
            {
                MessageBox.Show("The ticket is currently not discounted.");
            }
            else
            {
                List<Play> plays = UpperForm.AllPlays;
                foreach (Play play in plays)
                {
                    foreach (Performance performance in play.PlayPerformances)
                    {
                        foreach (Band band in performance.PerformanceBands)
                        {
                            foreach (Seat seat in band.BandSeats)
                            {
                                if (UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketSeat.SeatID == seat.SeatID)
                                {
                                    UpperForm.CurrentBooking.TotalCost -= UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketPrice;
                                    UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketPrice = band.BandPrice;
                                    UpperForm.CurrentBooking.TotalCost += UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketPrice;
                                    label4.Text = UpperForm.CurrentBooking.TotalCost.ToString("C", CultureInfo.CreateSpecificCulture("en-GB"));
                                    UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketType = "Regular";
                                    listBox1.Items[listBox1.SelectedIndex] = String.Format("{0, 15} {1, 30} {2, 15} {3, 15} {4, 15}", play.PlayName, performance.PerformanceDate, band.BandNumber + seat.SeatNumber,
                                        UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")), UpperForm.CurrentBooking.BookingTickets[listBox1.SelectedIndex].TicketType == "Discounted" ? "Yes" : "No");
                                }

                            }
                        }
                    }
                }
            }
        }
    }
}