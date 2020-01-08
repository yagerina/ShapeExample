using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Shape
    {
        //Local class variables
        protected SolidBrush myBrush;
        protected Graphics formGraphics;



        //Constructor
        public Shape(Form myForm, Color color)
        {
            myBrush = new SolidBrush(color);
            formGraphics = myForm.CreateGraphics();

        }

        //destructor
        ~Shape()
        {
            formGraphics.Dispose();
            myBrush.Dispose();
        }

        public virtual void Draw()
        {

        }
    }
}
