using System;
using System.Windows.Forms;
using System.Drawing;

namespace SierpinskiTeppich
{
   
    class Sierpinski : Form
    {
        int iteration = 0;
        public Sierpinski()
        {
            Width = 600;
            Height = 600;
            Text = "Sierpinski-Teppich"; 
        }
        static void Main()
        {
            Application.Run(new Sierpinski());
        }
        override protected void OnPaint(PaintEventArgs e)
        {
            RectangleF bounds = e.Graphics.VisibleClipBounds; // um die Groesse des sichtbaren Bereichs zu ermitteln

            //Brush und Graphics-Object anlegen zur Übergabe an rekursive Methode
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            

            //Aufruf der rekusriven Methode
            // Beginne mit dem Zeichnen, wenn iteration > 0 (Anzahl an Rekursionen > 0)


                SierpinskiTeppich(e.Graphics, solidBrush, bounds.X, bounds.Y, bounds.Width, bounds.Height, iteration);

            

        }
        private void SierpinskiTeppich(Graphics g, Brush brush, Single x, Single y, Single width, Single height, int iteration)
        {
            // Rekursion
            // Zuerst einmal zeichnen, anschließend für die 8 neuen Rechtecke
            Graphics rectangle = g;
             if(iteration == 0)
            {
                g.FillRectangle(Brushes.White, x, y, width, height);
            }
            else
            {
                rectangle.FillRectangle(brush, Convert.ToInt16(width / 3.0), Convert.ToInt16(height / 3.0), Convert.ToInt16(width / 3.0), Convert.ToInt16(height / 3.0));
                float x1 = x / 3;
                float y1 = y / 3;
                float width1 = width / 3;
                float height1 = height / 3;


                SierpinskiTeppich(g, brush, x1, y1, width1, height1, iteration - 1);
                SierpinskiTeppich(g, brush, x1, y1, width1, height1, iteration - 1);
                SierpinskiTeppich(g, brush, x1, y1, width1, height1, iteration - 1);
                SierpinskiTeppich(g, brush, x1, y1, width1, height1, iteration - 1);
                SierpinskiTeppich(g, brush, x1, y1, width1, height1, iteration - 1);
                SierpinskiTeppich(g, brush, x1, y1, width1, height1, iteration - 1);
                SierpinskiTeppich(g, brush, x1, y1, width1, height1, iteration - 1);
                SierpinskiTeppich(g, brush, x1, y1, width1, height1, iteration - 1);

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
