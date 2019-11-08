using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDA_Transform_Line
{

    public partial class Form1 : Form
    {
        public static int y2 = 60; // x2
        public static float y1 = 30.0f; // x1
                                        //==============
        public static int x2 = 80; // y2
        public static float x1 = 50; // y1
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Developed by Mr. Touraj Ostovari || 2019 Nov FOR UNIVERSITY LESSON :: Algorithms of computer's graphic";
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            try
            {
                Graphics graphics = e.Graphics;
                Pen pen = new Pen(System.Drawing.Color.Black, 5.0f);


                //==============
                float rep_x1 = x1;
                float rep_y1 = y1;
                System.Collections.Generic.List<float> collect = new List<float>();


                System.Collections.Generic.Dictionary<int, int> pairs = new Dictionary<int, int>();

                float m = float.Parse(((float.Parse((y2 - y1).ToString()) / float.Parse((x2 - x1).ToString())).ToString("f3")));
                if (m > 1)
                {
                    while ((x1 <= x2 || x1 != x2) && (y1 != y2))
                    {
                        collect.Add(x1);
                        x1 += m;
                        y1 += 1.0f;
                    }
                    for (float i = rep_y1; i <= y2;)
                    {
                        try
                        {
                            graphics.DrawLine(pen, i++, float.Parse((Math.Round(collect[(int)i])).ToString()), i, float.Parse((Math.Round(collect[(int)i])).ToString()));
                        }
                        catch (Exception)
                        { }
                    }
                }
                else if (m < 1)
                {
                    while ((x1 != x2) && (y1 <= y2 || y1 != y2))
                    {
                        collect.Add(y1);
                        y1 += m;
                        x1 += 1;
                    }
                    for (float i = rep_x1; i <= x2;)
                    {
                        try
                        {
                            graphics.DrawLine(pen, i++, float.Parse((Math.Round(collect[(int)i])).ToString()), i, float.Parse((Math.Round(collect[(int)i])).ToString()));
                        }
                        catch (Exception)
                        { }
                    }
                }
                else if (m == 1)
                {
                    graphics.DrawLine(pen, x1, y1, x2, y2);
                }
                graphics.Dispose();
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(Source_X.Text) && !String.IsNullOrWhiteSpace(Source_Y.Text) && !String.IsNullOrWhiteSpace(Dest_X.Text) && !String.IsNullOrWhiteSpace(Dest_Y.Text))
            {
                x1 = int.Parse(Source_X.Text);
                y2 = int.Parse(Source_Y.Text);
                x2 = int.Parse(Dest_X.Text);
                y2 = int.Parse(Dest_Y.Text);
            }
            this.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            int tempX = int.Parse(Tx.Text); int tempY = int.Parse(Ty.Text);
            x1  = (x1 + (tempX)); y1 = (y1 + (tempY));
            x2 = (x2 + (tempX)); y2 = (y2 + (tempY));
            }
            catch (Exception)
            {

            }
            finally {this.Invalidate(); }
            
        }
    }
}
