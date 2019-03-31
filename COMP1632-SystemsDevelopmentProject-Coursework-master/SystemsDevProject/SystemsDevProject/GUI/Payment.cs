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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
            //register form close event
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(PaymentClosing);
        }

        private void SaveChangesbtn_Click(object sender, EventArgs e)
        {

            //check if all fields have data
            if (textBoxCardNumber.Text == "" || textBoxCVV.Text == "" || textBoxExpiryMM.Text == "" || textBoxExpiryYY.Text == "" || comboBoxCardtype.SelectedIndex == -1 || (radioButtonOnline.Checked == false && radioButtonAtBooth.Checked == false))
            {
                MessageBox.Show("All Fields Required.");
            }
            else
            {
                string val = "";
                if (radioButtonAtBooth.Checked == true)
                    val = "Booth";

                if (radioButtonOnline.Checked == true)
                    val = "Online";

                //add card details to object
                CardDetails cd = new CardDetails(val, textBoxCardNumber.Text, comboBoxCardtype.SelectedItem.ToString(), textBoxExpiryMM.Text, textBoxExpiryYY.Text, textBoxCVV.Text);
                //send to db instance class
                DBSingleton.GetDBSingletonInstance.InsertCardDetails(cd);
                MessageBox.Show("Details Saved!");
            }
        }

        //exit form 
        private void PaymentClosing(object sender, FormClosingEventArgs e)
        {



            Application.Exit();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
