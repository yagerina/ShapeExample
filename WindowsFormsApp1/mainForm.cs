using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class mainForm : Form
    {
        private Random rnd = new Random();
        List<Shape> shapeList = new List<Shape>();
        Timer timer = new Timer();
        Point animatedShapePosition;
        int animationCount = 0;
        int verticalVeloctiy = 0;

        public mainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            timer.Interval = 30;
            timer.Enabled = false;
        }
        private Color randomColor()
        {
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Square mySquare = new Square(this);
            //mySquare.Draw();

            //LetterCircle myCircle = new LetterCircle(this);
            //myCircle.Draw();

            //Triangle myTriangle = new Triangle(this);
            //myTriangle.Draw();
            

            for (int i = 0; i <= 100; i++)
            {
                Rectangle rect = new Rectangle(rnd.Next(1, 1000), rnd.Next(1, 1000), 200, 200);
                Circle aCircle = new Circle(this, rect, randomColor());
                Rectangle rect2 = new Rectangle(rnd.Next(1, 1000), rnd.Next(1, 1000), 200, 200);
                Square aSquare = new Square(this, rect2, randomColor());
                Rectangle rect3 = new Rectangle(rnd.Next(1, 1000), rnd.Next(1, 1000), 200, 200);
                LetterCircle aLetterCircle = new LetterCircle(this, rect3, randomColor());
                //EJY create a random x & y starting point for the shape
                int rX = rnd.Next(1, 1000);
                int rY = rnd.Next(1, 1000);
                //EJY Draw a 200 px triangle, increasing points by the random amounts equally
                Triangle aTriangle = new Triangle(this, new PointF[] { new PointF(100+rX, 0+rY), new PointF(200+rX, 200+rY), new PointF(0+rX, 200+rY) }, randomColor());

                shapeList.Add(aCircle);
                shapeList.Add(aTriangle);
                //shapeList.Add(aSquare);
                //shapeList.Add(aLetterCircle);
            }

            foreach (Shape shape in shapeList)
            {
                shape.Draw();
            }
        }

        private void mainForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Tick += TimerTick;
            timer.Enabled = true;
        }

        public Point CurrentPoint(float t, Point p0, Point p1, Point p2, Point p3)
        {
            float cube = t * t * t;
            float square = t * t;
            float ax = 3 * (p1.X - p0.X);
            float ay = 3 * (p1.Y - p0.Y);
            float bx = 3 * (p2.X - p1.X) - ax;
            float by = 3 * (p2.Y - p1.Y) - ay;
            float cx = p3.X - p0.X - ax - bx;
            float cy = p3.Y - p0.Y - ay - by;
            float x = (cx * cube) + (bx * square) + (ax * t) + p0.X;
            float y = (cy * cube) + (by * square) + (ay * t) + p0.Y;
            return new Point((int)Math.Truncate(x), (int)Math.Truncate(y));
        }

        private void TimerTick(object sender, System.EventArgs e)
        {
            animationCount++;
            
            double t = (animationCount % 100) * .01;
            Point cp = CurrentPoint((float)t, new Point(100, 100), new Point(150, 500), new Point(1000, 200), new Point(1400, 600));
            animatedShapePosition.X = cp.X;
            animatedShapePosition.Y = cp.Y;
            //if (animatedShapePosition.X > 1000 ) { animatedShapePosition.X = 0; }
            Shape animatedShape = new Square(this, new Rectangle(animatedShapePosition.X, animatedShapePosition.Y+20, 50, 50), Color.BlueViolet);

            Graphics g = this.CreateGraphics();
            g.Clear(Color.Black);
            g.DrawBezier(new Pen(Color.Red), new Point(100, 100), new Point(150, 500), new Point(1000, 200), new Point(1400, 600));
            g.DrawBezier(new Pen(Color.Cornsilk), new Point(100, 150), new Point(150, 550), new Point(1000, 250), new Point(1400, 650));
            animatedShape.Draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawBezier(new Pen(Color.Red), new Point(100, 100), new Point(150, 500), new Point(1000, 200), new Point(1400, 600));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SolidBrush sb = new SolidBrush(Color.Blue);
            Graphics g = button4.CreateGraphics();
            Point[] points = { new Point(0, 50), new Point(0, 0), new Point(100, 0) };
            g.FillPolygon(sb, points);
        }
            public Graphics shape;
        public Rectangle rc;

        // constructor
        public void CLASS_NAME(Graphics formGraphics)
        {
            this.shape = formGraphics;
        }

        public void draw(int x, int y, int w, int h)
        {
            SolidBrush myBrush = new SolidBrush(Color.Red);
            this.rc = new Rectangle(20, 30, 20,40);
            this.shape.FillRectangle(myBrush, rc);

            myBrush.Dispose();
        }
    }
    }








