using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var imgarray = new Image[9];
            var img = Image.FromFile(@"media\rose.jpg");
            int widthThird = 0;
            int heightThird = 0;
            widthThird = (int)((double)img.Width / 3.0 + 0.5);
            heightThird = (int)((double)img.Height / 3.0 + 0.5);
            Bitmap[,] bmps = new Bitmap[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    bmps[i, j] = new Bitmap(widthThird, heightThird);
                    Graphics g = Graphics.FromImage(bmps[i, j]);
                    g.DrawImage(img, new Rectangle(0, 0, widthThird, heightThird), new Rectangle(j * widthThird, i * heightThird, widthThird, heightThird), GraphicsUnit.Pixel);
                    g.Dispose();
                }

            }
            
            pictureBox1.Image = bmps[0, 0];
            pictureBox2.Image = bmps[0, 1];
            pictureBox3.Image = bmps[0, 2];
            pictureBox4.Image = bmps[1, 0];
            pictureBox5.Image = bmps[1, 1];
            pictureBox6.Image = bmps[1, 2];
            pictureBox7.Image = bmps[2, 0];
            pictureBox8.Image = bmps[2, 1];
            pictureBox9.Image = bmps[2, 2];

            
            int wid = pictureBox1.Image.Width + pictureBox2.Image.Width + pictureBox3.Image.Width;
            int hei = pictureBox1.Image.Height + pictureBox2.Image.Height + pictureBox3.Image.Height;

            Bitmap finImg = new Bitmap(wid, hei);
            Graphics g1 = Graphics.FromImage(finImg);

            var x = 0;
            var y = 0;
            Image img_ = null;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    img_ = bmps[i, j];
                    if (j > 0)
                    {
                        x += img_.Width;
                    }

                    g1.DrawImage(img_, new Point(x, y));


                }
                y += img_.Height;
                x = 0;
            }
            pictureBox10.Image = finImg;


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
