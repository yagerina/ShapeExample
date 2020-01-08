using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class LetterCircle : Circle
    {

        public LetterCircle(Form myForm, Rectangle rect, Color color) : base(myForm, rect, color)
        {

        }
        public override void Draw()
        {
            base.Draw();
            Font circlefont = new Font("Comic Sans", 70.0f);
            myBrush.Color = Color.Black;
            formGraphics.DrawString("C", circlefont, myBrush, locationRect.X + locationRect.Width / 4, locationRect.Y + locationRect.Height / 4);
        }
    }
}
