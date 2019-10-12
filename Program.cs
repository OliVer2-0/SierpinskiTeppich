using System;
using System.Windows.Forms;
using System.Drawing;

namespace SierpinskiTeppich
{
   
    /// <summary>
    /// Sierpinski creates a Window showing a Sierpinski-Carpet, the level of 
    /// recursion is operated by the arrowkeys.
    /// </summary>
    class Sierpinski : Form
    {
        private int iteration = 0;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="T:SierpinskiTeppich.Sierpinski"/> class.
        /// </summary>
        public Sierpinski()
        {
            Width = 600;
            Height = 600;
            Text = "Sierpinski-Teppich";
            ResizeRedraw = true;
        }

        /// <summary>
        /// The entry point of the program, where the program control 
        /// starts and ends.
        /// </summary>
        static void Main()
        {
            Application.Run(new Sierpinski());
        }

        /// <summary>
        /// Fires the Paint-Event and allows using the graphics-object. 
        /// Calls a recursive method. 
        /// </summary>
        /// <param name="e">E.</param>
        override protected void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // To identify the visible area.
            RectangleF bounds = e.Graphics.VisibleClipBounds;

            SolidBrush solidBrush = new SolidBrush(Color.DarkBlue);

            // Calling a recursive method.
            SierpinskiTeppich(e.Graphics, solidBrush, bounds.X, bounds.Y, bounds.Width, bounds.Height, iteration);
            

        }

        /// <summary>
        /// Draws a Sierpinski-Carpet recursively, by dividing the visible area 
        /// into 9 pieces and painting rectangles depending on the level of recursion.
        /// </summary>
        /// <param name="g">Graphics-Object.</param>
        /// <param name="brush">Brush.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <param name="iteration">Iteration used to set level of recursion.</param>
        private void SierpinskiTeppich(Graphics g, Brush brush, Single x, Single y, Single width, Single height, int iteration)
        {

            Graphics rectangle = g;
         
            // While recursion-level is set to 0, the carpet is a mono colored plain.
            if(iteration == 0)
            {
                rectangle.FillRectangle(Brushes.BlanchedAlmond, x, y, width, height);
            }
            // If the recursion-level is >= 1, the carpet starts showing rectangles. 
            // At level 1 the carpet is divided into 9 pieces and the first rectangle appears in center-piece
            // While increasing the level, the 8 pieces around the center are filled with rectangles.
            // The 8 pieces around the Center are the beginning coordinates for the next calls of the method.
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

        /// <summary>
        /// Uses the KeyDown-Event for checking whether ArrowUp or ArrowDown is pressed.
        /// ArrowUp increased recursion level.
        /// ArrowDown decreases recursion level. 
        /// </summary>
        /// <param name="e">E.</param>
        override protected void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
          
            if (e.KeyCode == Keys.Up)
            { 
                iteration++;
                Refresh();
            }
            if (e.KeyCode == Keys.Down)
            {
                if(iteration > 0)
                {
                    iteration--;
                }
                Refresh();
            }

        }
    }
}
