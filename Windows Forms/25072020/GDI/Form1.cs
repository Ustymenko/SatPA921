using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI
{
    public partial class Form1 : Form
    {
        int k = 0;
        Point center;
        int r = 20;
        int R;
        Timer timer = new Timer();
        public Form1()
        {
          //  DoubleBuffered = true;
            InitializeComponent();
            ClientSize = new Size(600, 600);
            center.X = ClientSize.Width / 2;
            center.Y = ClientSize.Height / 2;
            R = Math.Min(ClientSize.Width, ClientSize.Height) / 2 - 2 * r - 20;

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

        }
        int step = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            //var gr = CreateGraphics();
            //gr.TranslateTransform(center.X, center.Y);
            //gr.RotateTransform((360f/12)*step);
            //gr.FillEllipse(Brushes.Blue,new Rectangle(R,-r/2,2*r,2*r));
            step++;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Text = "" + ++k;
            using (Graphics gr = e.Graphics)
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                for (int i = 0; i < step; i++)
                {
                    gr.TranslateTransform(center.X, center.Y);
                    gr.RotateTransform((360f / 12) * step);
                    gr.FillEllipse(Brushes.Blue, new Rectangle(R, -r / 2, 2 * r, 2 * r));
                    gr.ResetTransform();
                }






                // Pen pen = new Pen(Brushes.Blue, 5);
                // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                // gr.DrawEllipse(pen, 10, 10, 200, 50);
                // Rectangle rec = new Rectangle(220, 10, 200, 50);
                // gr.DrawRectangle(Pens.DarkViolet, rec);

                //// SolidBrush solidBrush = new SolidBrush(Color.Red);
                // SolidBrush solidBrush = new SolidBrush(Color.FromArgb(200,120,240,120));
                // gr.FillRectangle(solidBrush, new Rectangle(10, 30, 200, 50));

                // Rectangle recgr = new Rectangle(220, 70, 200, 50);
                // LinearGradientBrush gradientBrush = new LinearGradientBrush(
                //     recgr, Color.Green, Color.Yellow,  LinearGradientMode.ForwardDiagonal);
                // gr.FillRectangle(gradientBrush, recgr);

                // HatchBrush hatchBrush = new HatchBrush(HatchStyle.DarkHorizontal, Color.Red);
                // gr.FillRectangle(hatchBrush, new Rectangle(430, 70, 100, 50));

                // TextureBrush textureBrush = new TextureBrush(new Bitmap("agent.png"));
                // textureBrush.WrapMode = WrapMode.Tile;
                // gr.FillRectangle(textureBrush, new Rectangle(10, 130, 400, 100));

                // Font font = new Font("Verdana",14, FontStyle.Bold | FontStyle.Underline);
                // gr.DrawString("Hello It Step Zhytomyr", font, gradientBrush, 
                //     new Rectangle(10,250,80,80), new StringFormat {
                //         Alignment=StringAlignment.Center,
                //         LineAlignment = StringAlignment.Center,
                //         FormatFlags = StringFormatFlags.FitBlackBox
                //     }
                //     );

                // var img = new Bitmap("agent.png");
                // gr.DrawImage(img, new Point(150, 250));
                // Rectangle recimg = new Rectangle(250, 250, 50, 50);
                // gr.DrawImage(img, recimg);

                // Rectangle rec1 = new Rectangle(10, 10, 100, 50);
                // Rectangle rec2 = new Rectangle(50, 30, 100, 50);

                // gr.DrawRectangle(Pens.Red, rec1);
                // gr.DrawRectangle(Pens.Black, rec2);

                // Region region1 = new Region(rec1);
                // Region region2 = new Region(rec2);

                //// region1.Intersect(region2);
                // //region1.Exclude(region2);
                // //region1.Complement(region2);
                //// region1.Union(region2);
                // region1.Xor(region2);

                // gr.FillRegion(Brushes.Yellow, region1);

                //GraphicsPath path = new GraphicsPath();
                //path.StartFigure();
                //path.AddEllipse(100, 100, 100, 100);
                //path.CloseFigure();

                //path.StartFigure();
                //path.AddLine(100, 100, 50, 50);
                //path.AddLine(150, 100, 50, 50);
                //path.AddLine(150, 100, 5, 5);
                //path.CloseFigure();
                //gr.FillPath(Brushes.Yellow, path);

                // gr.DrawLine(new Pen(Color.Red,5 ),50, 50, 250, 50);

                // gr.TranslateTransform(50, 50);
                // gr.DrawLine(new Pen(Color.Red,5 ),50, 50, 250, 50);

                // gr.TranslateTransform(-50, -50);
                // gr.DrawLine(new Pen(Color.Blue,5 ),50, 50, 150, 50);

                //// gr.RotateTransform(10);
                // gr.DrawLine(new Pen(Color.Green, 5), 150, 150, 250, 150);

                // //  gr.DrawLine(new Pen(Color.Black, 5), 200, 100, 200, 200);

                // gr.TranslateTransform(200, 150);
                // gr.RotateTransform(90);
                // gr.TranslateTransform(-50,0 );
                // gr.ScaleTransform(1.7f, 0.7f);
                // gr.DrawLine(new Pen(Color.Black, 5), 0, 0, 100, 0);

            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            center.X = ClientSize.Width / 2;
            center.Y = ClientSize.Height / 2;
            R = Math.Min(ClientSize.Width, ClientSize.Height) / 2 - 2 * r - 20;
        }
    }
}
