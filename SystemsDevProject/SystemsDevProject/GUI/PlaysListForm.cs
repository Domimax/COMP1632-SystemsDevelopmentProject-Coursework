using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemsDevProject.GUI
{
    public partial class PlaysListForm : Form
    {
        public List<Play> AllPlays { get; set; }
        public Play ChosenPlay { get; set; }
        public MainForm UpperForm { get; set; }


        public PlaysListForm(MainForm upperForm)
        {
            InitializeComponent();
            UpperForm = upperForm;
            AllPlays = DBSingleton.GetDBSingletonInstance.GetPlays();
            foreach (Play play in AllPlays)
            {
                listBox1.Items.Add(play.PlayName);
            }
            listBox1.SelectedIndex = 0;
            label2.Text = button1.Text = "View available dates, reviews and additional information about the play.";
            button1.Text = "View for: \"" + listBox1.SelectedItem + "\".";
            this.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Play play in AllPlays)
            {
                if (play.PlayName.Equals(listBox1.SelectedItem))
                {
                    ChosenPlay = play;
                    button1.Text = "View for: \"" + listBox1.SelectedItem + "\".";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlayInfoForm booking = new PlayInfoForm(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            UpperForm.Show();
        }
    }
}
