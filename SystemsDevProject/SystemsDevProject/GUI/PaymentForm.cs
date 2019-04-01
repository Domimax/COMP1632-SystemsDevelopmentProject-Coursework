using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemsDevProject
{
    public partial class PaymentForm : Form
    {
        public BookingForm UpperForm { get; set; }
        CardDetails cardDetails;

        public PaymentForm(BookingForm upperForm)
        {
            InitializeComponent();
            UpperForm = upperForm;
            cardDetails = null;
            this.Show();
        }

        private void SaveChangesbtn_Click(object sender, EventArgs e)
        {
            //check if all fields have data
            if (textBoxCardNumber.Text == "" || textBoxCVV.Text == "" || label8.Text == "" || dateTimePicker1.Value.Subtract(DateTime.Now).TotalDays < 30.0 || comboBoxCardtype.SelectedIndex == -1)
            {
                MessageBox.Show("All Fields need to be inputted correctly. Your card must not be expiring within 30 days.");
            }
            else
            {
                //add card details to object
                cardDetails = new CardDetails(textBox1.Text, textBoxCardNumber.Text, comboBoxCardtype.SelectedItem.ToString(), dateTimePicker1.Value, textBoxCVV.Text);
                //send to db instance class
                if (CheckCardVisaCheck(cardDetails))
                {
                    int bookingID;
                    UpperForm.UpperForm.CurrentBooking.BookingDate = DateTime.Now;
                    if (radioButtonOnline.Checked)
                    {
                        UpperForm.UpperForm.CurrentBooking.CollectionType = "Online";
                    }
                    else {
                        UpperForm.UpperForm.CurrentBooking.CollectionType = "Booth";
                    }
                    bookingID = DBSingleton.GetDBSingletonInstance.InsertBooking(UpperForm.UpperForm.CurrentBooking,
                        UpperForm.UpperForm.LoggedInUser.UserID);
                    DBSingleton.GetDBSingletonInstance.InsertCardDetails(cardDetails, bookingID);
                    foreach (Ticket ticket in UpperForm.UpperForm.CurrentBooking.BookingTickets) {
                        DBSingleton.GetDBSingletonInstance.InsertTicket(ticket, bookingID);
                    }
                    UpperForm.UpperForm.CurrentBooking = new Booking();
                    UpperForm.UpperForm.CurrentBooking.BookingTickets = new List<Ticket>();
                    UpperForm.UpperForm.AllPlays = DBSingleton.GetDBSingletonInstance.GetPlays();
                    MessageBox.Show("Details Saved, Booking confirmed!");
                    MainForm form = UpperForm.UpperForm;
                    UpperForm.Close();
                    form.Show();
                    this.Close();
                }
                else {
                    MessageBox.Show("The visa check system did not find a match with the provided card details.");
                }
            }
        }

        //This method can be used to check the card using the VISACHECK system. Now it
        // just checks if the CardDetals object is not null, but if the interface for the VISACHECK system would,
        //exist, it would be possible to check all the details with this method.
        public bool CheckCardVisaCheck(CardDetails cardDetails) {
            if (cardDetails != null)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
