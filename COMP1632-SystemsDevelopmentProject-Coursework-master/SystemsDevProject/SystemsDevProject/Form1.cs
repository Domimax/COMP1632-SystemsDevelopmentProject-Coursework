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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            BookingForm form = new BookingForm();
            form.Show();
        }
    }
}
