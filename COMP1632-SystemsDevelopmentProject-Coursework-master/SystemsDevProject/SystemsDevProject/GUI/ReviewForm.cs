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
    public partial class ReviewForm : Form
    {
        List<Play> plays;
        Play currentPlay;
        string playName;
        DateTime playDate;
        string review;
        int rating;

        public ReviewForm()
        {
            plays = DBSingleton.GetDBSingletonInstance.GetPlays();
            InitializeComponent();
            populateComboBox();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //coding submit button
        private void button1_Click(object sender, EventArgs e)
        {
            /*if (comboBox1.SelectedIndex.ToString() != null && dateTimePicker1.Value != null && richTextBox1.Text != null && richTextBox1.Text != "")
            {
                string name = comboBox1.SelectedIndex.ToString();
                string review = richTextBox1.Text;
                DateTime date = dateTimePicker1.Value;
                try
                {
                    DBSingleton.GetDBSingletonInstance.WriteReview(name, review, date);
                    MessageBox.Show("Thank you. Your review has been saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to connect to database. Error: " + ex);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please ensure all fields have been filled out correctly");
            }*/
            try
            {
                playDate = (DateTime)comboBox2.SelectedItem;
                playName = comboBox1.SelectedItem.ToString();
                rating = trackBar1.Value;
                review = richTextBox1.Text;
            }
            catch (NullReferenceException i )
            {
                MessageBox.Show("Unable to save your review at this time. Error : " + i);
            }
            if (comboBox1.SelectedIndex.ToString() != null && comboBox2.SelectedIndex.ToString() != null && richTextBox1.Text != "")
            {
                MessageBox.Show(playDate.ToString() + "\n\r" + playName + "\n\r" + rating.ToString() + "\n\r" + review);
                //DBSingleton.GetDBSingletonInstance.InsertReview(playName, playDate, review, rating);
            }
        }
        //fills the combobox with plays from the database
        private void populateComboBox()
        {
                for (int i = 0; i < plays.Count; i++)
                {
                    comboBox1.Items.Add(plays[i].PlayName);
                }
        }
        //fills the second combobox with date and times of the plays
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            comboBox2.Visible = true;
            

            //for (int i =0; i< plays.Count; i++)
            //{
            //    foreach (Play play in plays)
            //    {
            //        currentPlay = plays[i];
            //    }
            //    comboBox2.Items.Add(currentPlay.PlayPerformances[i].PerformanceDate);
            //}
            currentPlay = plays[comboBox1.SelectedIndex];
            for (int i = 0; i < currentPlay.PlayPerformances.Count; i++)
            {
                comboBox2.Items.Add(currentPlay.PlayPerformances[i].PerformanceDate);
            }
            
            //MessageBox.Show(comboBox2.SelectedValue.ToString());
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
            if (trackBar1.Value == 1)
            {
                label10.Text = "You've given this performance: 1/5";
            }
            if (trackBar1.Value == 2)
            {
                label10.Text = "You've given this performance: 2/5";
            }
            if (trackBar1.Value == 3)
            {
                label10.Text = "You've given this performance: 3/5";
            }
            if (trackBar1.Value == 4)
            {
                label10.Text = "You've given this performance: 4/5";
            }
            if (trackBar1.Value == 5)
            {
                label10.Text = "You've given this performance: 5/5";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Visible = true;
            label10.Visible = true;
            trackBar1.Visible = true;
        }
    }
}
