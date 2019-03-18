using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace SystemsDevProject
{
    public partial class SeatPlan : Form
    {
        //BookingData
        private List<BookingData> bookinglist = new List<BookingData>();
        public SeatPlan()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(SeatPlanClosing);//form closing event register
            int count = 1;

            List<BookingData> blist = new List<BookingData>();//temporary list for adding and removing seats until booking is confirmed
            blist = DBSingleton.GetDBSingletonInstance.getBookingData();//get already stored data from the database related to booking
            foreach (Control p in panel1.Controls)//get all flowlaylout panels in panel1 
            {
                if (p.GetType() == typeof(FlowLayoutPanel))//check if flow layout panel

                    foreach (Control b in p.Controls)//for each button a single flowlayoutpanel
                    {
                        //following code is written to get name of the button and separating the seat alphabet from seat number 
                        string str = b.Name;
                        string category = str[0].ToString();
                        int num;
                        if (str.Length > 2)
                            num = Convert.ToInt32(str[1].ToString() + str[2].ToString());
                        else
                            num = Convert.ToInt32(str[1].ToString());


                        string availability = "";
                        //create an object of the data for a button/seat
                        BookingData bd = new BookingData(num, category, availability);

                        //uncomment below code if you need to refresh all the seats and before that delete all the access database
                        /* b.BackColor = Color.Green;
                         DBSingleton.GetDBSingletonInstance.refreshSeating(count,bd);
                         count++;  
                          */

                        if (getMatch(blist, bd) != null)//check if the seat data exists
                        {
                            BookingData bkd = getMatch(blist, bd);//get seat data
                            if (bkd.getavail().Equals("booked"))//if booked
                            {

                                //color should be red and button disabled
                                b.BackColor = Color.Red;
                                b.Enabled = false;

                            }
                            else
                            {
                                //if not booked then show green
                                b.BackColor = Color.Green;

                                b.Click += MyButtonClick;
                            }
                        }



                    }
            }


        }


        BookingData getMatch(List<BookingData> blist, BookingData BD)
        {

            //get matching seat data from list
            foreach (BookingData item in blist)
            {
                if (item.SeatNumber().Equals(BD.SeatNumber()))
                {
                    return item;
                }
            }
            return null;
        }

        void MyButtonClick(object sender, EventArgs e)

        {
            //get the button name, split it into seat alphabet and number
            Button button = sender as Button;
            BookingData bd = null;
            String str = button.Name;
            string category = str[0].ToString();
            int num;
            if (str.Length > 2)
                num = Convert.ToInt32(str[1].ToString() + str[2].ToString());
            else
                num = Convert.ToInt32(str[1].ToString());

            //if selected seat is booked change back to green and remove from the list else add in the booking list
            if (button.BackColor == Color.Green)
            {
                button.BackColor = Color.Red;
                string availability = "booked";
                bd = new BookingData(num, category, availability);
                bookinglist.Add(bd);

            }

            else
            {
                string availability = "booked";

                bd = new BookingData(num, category, availability);

                button.BackColor = Color.Green;
                Remove(bd);
            }
            //here you can check which button was clicked by the sender
        }


        //remove booking data from the list
        void Remove(BookingData BD)
        {
            int count = 0;
            int index = 0;
            foreach (BookingData item in bookinglist)
            {
                if (item.SeatNumber().Equals(BD.SeatNumber()))
                {

                    index = count;
                }
                count++;
            }
            bookinglist.RemoveAt(index);
        }
        private void SeatPlan_Load(object sender, EventArgs e)
        {

        }

        private void C20_Click(object sender, EventArgs e)
        {

        }
        //if closed exit application
        private void SeatPlanClosing(object sender, FormClosingEventArgs e)
        {



            Application.Exit();

        }
        //call the dbsingletoninstance method insert list and send booking list to it
        private void Booking_Click(object sender, EventArgs e)
        {

            DBSingleton.GetDBSingletonInstance.InsertList(bookinglist);
            Payment p = new Payment();
            Hide();
            p.Show();
        }
    }
}
