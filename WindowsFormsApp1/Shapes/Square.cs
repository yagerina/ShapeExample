using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Square : Shape
    {
        private Rectangle locationRect;


        public Square(Form myForm, Rectangle rect, Color color) : base(myForm, color)
        {
            locationRect = rect;

        }
        public override void Draw()
        {
            base.Draw();
            formGraphics.FillRectangle(myBrush, locationRect);

        }
    }
}
