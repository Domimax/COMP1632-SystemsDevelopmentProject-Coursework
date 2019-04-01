using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using SystemsDevProject.GUI;

namespace SystemsDevProject
{
    public partial class SeatPlan : Form
    {
        public PlayInfoForm UpperForm { get; set; }
        public double Subtotal { get; set; }
        public List<Seat> SelectedSeats { get; set; }

        public SeatPlan(PlayInfoForm upperForm)
        {
            InitializeComponent();
            UpperForm = upperForm;
            Subtotal = 0.0;
            label10.Text = Subtotal.ToString("C", CultureInfo.CreateSpecificCulture("en-GB"));
            SelectedSeats = new List<Seat>();
            foreach (Control p in panel1.Controls)//get all flowlaylout panels in panel1 
            {
                //check if flow layout panel
                if (p.GetType() == typeof(FlowLayoutPanel))
                {
                    foreach (Control b in p.Controls)//for each button a single flowlayoutpanel
                    {
                        foreach (Band band in UpperForm.ChosenPerformance.PerformanceBands)
                        {
                            Band currentBand = band;
                            double price = currentBand.BandPrice;
                            string letter = currentBand.BandNumber;
                            foreach (Seat seat in band.BandSeats)
                            {
                                string number = seat.SeatNumber.ToString();
                                bool occupied = seat.Occupied;
                                if (b.Name == letter + number)
                                {
                                    if (occupied == true)
                                    {
                                        b.BackColor = Color.Red;
                                        b.Text = letter + number;
                                        b.Enabled = false;
                                    }
                                    else
                                    {
                                        b.BackColor = Color.Gray;
                                        b.Text = price.ToString("C", CultureInfo.CreateSpecificCulture("en-GB"))
                                            + "\n" + letter + number;
                                        b.Click += MyButtonClick;
                                        b.Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            this.Show();
        }

        void MyButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            foreach (Band band in UpperForm.ChosenPerformance.PerformanceBands)
            {
                foreach (Seat seat in band.BandSeats)
                {
                    if (button.Name == band.BandNumber + seat.SeatNumber)
                    {
                        if (seat.Occupied == false)
                        {
                            button.BackColor = Color.Green;
                            SelectedSeats.Add(seat);
                            RecalculateSubtotal(band.BandPrice);
                        }
                        else
                        {
                            button.BackColor = Color.Gray;
                            SelectedSeats.Remove(seat);
                            RecalculateSubtotal(-band.BandPrice);
                        }
                    }
                }
            }
        }

        private void RecalculateSubtotal(double amount)
        {
            Subtotal += amount;
            label10.Text = Subtotal.ToString("C", CultureInfo.CreateSpecificCulture("en-GB"));
        }

        //call the dbsingletoninstance method insert list and send booking list to it
        private void Booking_Click(object sender, EventArgs e)
        {
            if (SelectedSeats.Count != 0)
            {
                foreach (Seat selectedSeat in SelectedSeats)
                {
                    Ticket ticket = new Ticket();
                    ticket.TicketSeat = selectedSeat;
                    foreach (Band band in UpperForm.ChosenPerformance.PerformanceBands)
                    {
                        foreach (Seat seat in band.BandSeats)
                        {
                            if (seat.SeatID == selectedSeat.SeatID)
                            {
                                seat.Occupied = true;
                                ticket.TicketPrice = band.BandPrice;
                                ticket.TicketType = "Regular";
                                UpperForm.UpperForm.UpperForm.CurrentBooking.BookingTickets.Add(ticket);
                            }
                        }
                    }
                }
                UpperForm.UpperForm.UpperForm.CurrentBooking.TotalCost += Subtotal;
                MessageBox.Show("You have added the seats to your shopping basket.");
                this.Hide();
                this.Close();
            }
            else {
                MessageBox.Show("You have not selected any seats.");
            }
        }
    }
}
