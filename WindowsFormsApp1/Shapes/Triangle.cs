using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Triangle : Shape
    {
        private PointF[] locationPoints;

        public Triangle(Form myForm, PointF[] points, Color color) : base(myForm, color)
        {
            locationPoints = points;
        }
        public override void Draw()
        {
            base.Draw();
            formGraphics.FillPolygon(myBrush, locationPoints);
        }
    }
}
