using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Circle : Shape
    {
        protected Rectangle locationRect;

        public Circle(Form myForm, Rectangle rect, Color color) : base(myForm, color)
        {
            locationRect = rect;
        }
        public override void Draw()
        {
            base.Draw();
            //Rectangle rect = new Rectangle(400, 100, 200, 200);
            formGraphics.FillEllipse(myBrush, locationRect);
        }
    }
}
