using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using static Emgu.CV.ML.KNearest;


namespace Rendszamtabla


{
    public partial class Form1 : Form
    {


        Image<Bgr, byte> imgInput;
        //Image<Gray, byte> imgGray;




        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imgInput = new Image<Bgr, byte>(openFileDialog.FileName);
                byte[] bytes = imgInput.ToJpegData();
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(bytes));
                pictureBox1.Image = x;




            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}