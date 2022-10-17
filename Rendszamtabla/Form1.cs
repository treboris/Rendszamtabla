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
using Emgu.CV.ImgHash;

namespace Rendszamtabla


{
    public partial class Form1 : Form
    {


        Image<Bgr, byte> imgInput;
        Image<Gray, byte> gray_img;
        private Image<Gray, byte> img_binarize;

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
                //GRAY
                gray_img = imgInput.Convert<Gray, byte>();
                //BITMAP
                byte[] bytes = gray_img.ToJpegData();
                Image gray = (Bitmap)((new ImageConverter()).ConvertFrom(bytes));


                //BINARIZE
                img_binarize = new Image<Gray, byte>(gray.Width, gray.Height, new Gray(0));

                CvInvoke.Threshold(gray_img, img_binarize, 150, 500, ThresholdType.Binary);



                byte[] img_bytes = img_binarize.ToJpegData();
                Image img = (Bitmap)((new ImageConverter()).ConvertFrom(img_bytes));
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                pictureBox1.Image = img;





            }

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
    }
}