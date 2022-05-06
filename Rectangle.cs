using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShapeAnimator
{
    class Rectangle
    {
        public double X;
        public double Y;
        public double Width;
        public double Height;
        public int DirectionX = 1;
        public int DirectionY = 1;
        public Brush Color;

        public Rectangle(double x, double y, double w, double h, Brush c)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
            Color = c;
        }

        public void Draw(Canvas canvas)
        {
            System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
            rect.Width = 100;
            rect.Height = 50;
            rect.Stroke = Color;

            Canvas.SetLeft(rect, X);
            Canvas.SetTop(rect, Y);
            canvas.Children.Add(rect);
        }

        public void Shift(Canvas canvas)
        {
            X += 5 * DirectionX;
            Y += 5 * DirectionY;
            if (X + Width + 5 > canvas.ActualWidth)
            {
                DirectionX = -1;
            }
            if (X + Width/2 + 5< Width/2)
            {
                DirectionX = 1;
            }
            if (Y + Width/2 + 5 > canvas.ActualHeight)
            {
                DirectionY = -1;
            }
            if (Y + Width/2 < Height)
            {
                DirectionY = 1;
            }
        }
    }
}
