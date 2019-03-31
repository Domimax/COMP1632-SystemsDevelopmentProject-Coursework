using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemsDevProject.Model;

namespace SystemsDevProject.GUI
{
    public partial class RegisterForm : Form
    {
        public LoginForm UpperForm { get; set; }

        public RegisterForm(LoginForm upperForm)
        {
            InitializeComponent();
            UpperForm = upperForm;
            UpdateLayout();
            this.Show();
        }

        public void UpdateLayout()
        {
            label9.Hide();
            dateTimePicker1.Hide();
            dateTimePicker1.Value = DateTime.Now;
            label12.Hide();
            label13.Hide();
            textBox8.Hide();
            textBox8.Text = "";
            textBox9.Hide();
            textBox9.Text = "";
            if (radioButton2.Checked)
            {
                label12.Text = "Role:";
                label13.Text = "Salary:";
                label12.Show();
                label13.Show();
                textBox8.Show();
                textBox9.Show();
            }
            else if (radioButton3.Checked)
            {
                label12.Text = "Agency name:";
                label12.Show();
                textBox8.Show();
            }
            else
            {
                label9.Show();
                dateTimePicker1.Show();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLayout();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLayout();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpperForm.Close();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (UpperForm.UpperMainForm.LoggedInUser != null)
                {
                    if (!UpperForm.UpperMainForm.LoggedInUser.GetType().Equals(typeof(Employee)))
                    {
                        MessageBox.Show("You must be logged in as an employee to be able to register another employee.");
                    }
                    else
                    {
                        if (CheckAllInputs("Employee"))
                        {
                            Employee employee = new Employee();
                            //DBSingleton.GetDBSingletonInstance.RegisterEmployee(employee);
                        }
                    }
                }
                else {
                    MessageBox.Show("You must be logged in as an employee to be able to register another employee.");
                }
            }
            else if (radioButton3.Checked)
            {
                if (UpperForm.UpperMainForm.LoggedInUser != null)
                {
                    if (!UpperForm.UpperMainForm.LoggedInUser.GetType().Equals(typeof(Employee)))
                    {
                        MessageBox.Show("You must be logged in as an employee to be able to register an agency.");
                    }
                    else
                    {
                        if (CheckAllInputs("Agency"))
                        {
                            Agency agency = new Agency();
                            // DBSingleton.GetDBSingletonInstance.RegisterAgency(agency);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You must be logged in as an employee to be able to register an agency.");
                }
            }
            else
            {
                if (CheckAllInputs("Customer"))
                {
                    Customer customer = new Customer();
                    //  DBSingleton.GetDBSingletonInstance.RegisterCustomer(customer);
                }
            }

        }

        private bool CheckAllInputs(string inputType)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" &&
                textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                if (inputType == "Employee")
                {
                    if (textBox8.Text != "" && textBox9.Text != "")
                    {
                        if (int.TryParse(textBox9.Text, out int i))
                        {
                            return true;
                        }
                    }
                }
                else if (inputType == "Agency")
                {
                    if (textBox8.Text != "")
                    {
                        return true;
                    }
                }
                else
                {
                    if ((DateTime.Now.Subtract(dateTimePicker1.Value)).TotalDays/365 < 16.0)
                    {
                        MessageBox.Show("You must be at least 16 years of age to register.");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            MessageBox.Show("Something went wrong. Make sure you filled in all the text boxes correctly.");
            return false;
        }
    }
}
