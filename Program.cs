using System;
using System.Windows.Forms;
using System.Drawing;

namespace SierpinskiTeppich
{
   
    class Sierpinski : Form
    {
        private int iteration = 0;
        
        public Sierpinski()
        {
            Width = 600;
            Height = 600;
            Text = "Sierpinski-Teppich";
            ResizeRedraw = true;
        }
        static void Main()
        {
            Application.Run(new Sierpinski());
        }

        override protected void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RectangleF bounds = e.Graphics.VisibleClipBounds; // um die Groesse des sichtbaren Bereichs zu ermitteln

            //Brush und Graphics-Object anlegen zur Übergabe an rekursive Methode
            SolidBrush solidBrush = new SolidBrush(Color.DarkBlue);

            //Aufruf der rekusriven Methode
            SierpinskiTeppich(e.Graphics, solidBrush, bounds.X, bounds.Y, bounds.Width, bounds.Height, iteration);
            

        }

        private void SierpinskiTeppich(Graphics g, Brush brush, Single x, Single y, Single width, Single height, int iteration)
        {
            // Rekursion
            // Zuerst einmal zeichnen, anschließend für die 8 neuen Rechtecke
            Graphics rectangle = g;
         

            if(iteration == 0)
            {
                rectangle.FillRectangle(Brushes.BlanchedAlmond, x, y, width, height);
            }
            else
            {
                rectangle.FillRectangle(brush, Convert.ToInt16((x + width / 3.0)), Convert.ToInt16(y + height / 3.0), Convert.ToInt16(width / 3.0), Convert.ToInt16(height / 3.0));

                float width1 = width / 3;
                float xLeft = x;
                float xMiddle = xLeft + width1;
                float xRight = xLeft + (width1 * 2f);
                
                float height1 = height / 3;
                float yTop = y;
                float yMiddle = yTop + height1;
                float yBottom = yTop + (height1 * 2f);


                SierpinskiTeppich(rectangle, brush, xLeft, yTop, width1, height1, iteration - 1);
                SierpinskiTeppich(rectangle, brush, xMiddle, yTop, width1, height1, iteration - 1);
                SierpinskiTeppich(rectangle, brush, xRight, yTop, width1, height1, iteration - 1);
                SierpinskiTeppich(rectangle, brush, xLeft, yMiddle, width1, height1, iteration - 1);
                SierpinskiTeppich(rectangle, brush, xRight, yMiddle, width1, height1, iteration - 1);
                SierpinskiTeppich(rectangle, brush, xLeft, yBottom, width1, height1, iteration - 1);
                SierpinskiTeppich(rectangle, brush, xMiddle, yBottom, width1, height1, iteration - 1);
                SierpinskiTeppich(rectangle, brush, xRight, yBottom, width1, height1, iteration - 1);

            }

        }

        override protected void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            // Mit Pfeiltasten Rekursion verändern
            // Übergabe an Methode SierpinskiTeppich Paramater iteration
            if (e.KeyCode == Keys.Up)
            {
                //erhöhe Rekursion
                iteration++;
                Refresh();
            }
            if (e.KeyCode == Keys.Down)
            {
                // verringere Rekursion 
                if(iteration > 0)
                {
                    iteration--;
                }
                Refresh();
            }

        }
    }
}
