using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SystemsDevProject
{
    class Receipt : Booking
    {
        public DateTime dateOfAttendance { get; set; }
        public string performanceName { get; set; }
        public double price { get; set; }
        public int numberOfTickets { get; set; }
        public int receiptNumber = 1;

        public Receipt()
        {

        }

        public Receipt(DateTime date, int i, double a, string performance)
        {
            date = dateOfAttendance;
            performanceName = performance;
            i = numberOfTickets;
            a = price;
        }

        public void printReceipt(string s)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + s;
            File.Create(path);
            StreamWriter writer = new StreamWriter(path);
            writer.Write("This is confirmation of your booking. Keep this document in a safe place" + "\r\n" + "Performance name: " + performanceName
                + "\r\n" + "Date of Performance: " + dateOfAttendance + "\r\n" + "Number of tickets: " + numberOfTickets + 
                "\r\n" + "Total price: " + price + "\r\n" + "Receipt number: " + receiptNumber);
            receiptNumber++;

        }
    }
}
