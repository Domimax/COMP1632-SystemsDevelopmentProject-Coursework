using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemsDevProject
{
    public partial class Form1 : Form
    {
        public List<Play> CurrentPlays { get; set; }

        public Form1()
        {
            InitializeComponent();
            LoadPlays();
        }

        private void LoadPlays()
        {
            CurrentPlays = DBSingleton.GetDBSingletonInstance.GetPlays();
            pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CurrentPlays[0].PictureString + ".jpg");
            pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CurrentPlays[1].PictureString + ".jpg");
            pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CurrentPlays[2].PictureString + ".jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
