using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            else if (value > max)
                return max;
            else
                return value;
        }

        private void bSubir_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos png|*.png|Archivos jpg|*.jpg";
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void bDetectar_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap result = new Bitmap(bmp.Width, bmp.Height);

            int[,] sX = new int[,]
        {
        { -1, 0, 1 },
        { -2, 0, 2 },
        { -1, 0, 1 }
        };

            int[,] sY = new int[,]
        {
        { 1, 2, 1 },
        { 0, 0, 0 },
        { -1, -2, -1 }
        };

            for (int i = 1; i < bmp.Width - 1; i++)
            {
                for (int j = 1; j < bmp.Height - 1; j++)
                {
                    int pixelX = 0;
                    int pixelY = 0;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            Color pixelColor = bmp.GetPixel(i + k, j + l);
                            int gris = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                            pixelX += gris * sX[k + 1, l + 1];
                            pixelY += gris * sY[k + 1, l + 1];
                        }
                    }

                    int magnitud = (int)Math.Sqrt(pixelX * pixelX + pixelY * pixelY);
                    magnitud = Clamp(magnitud, 0, 255);
                    result.SetPixel(i, j, Color.FromArgb(magnitud, magnitud, magnitud));
                }
            }

            pictureBox2.Image = result;
        }
    }
}
