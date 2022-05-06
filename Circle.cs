using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShapeAnimator
{
    class Circle
    {
        public double X;
        public double Y;
        public double Radius;
        public int DirectionX = 1;
        public int DirectionY = 1;
        public Brush Color;

        public Circle(double x, double y, double r, Brush c)
        {
            X = x;
            Y = y;
            Radius = r;
            Color = c;
        }
        public void Draw(Canvas canvas)
        {
            Ellipse e = new Ellipse();
            e.Width = Radius * 2;
            e.Height = Radius * 2;
            e.Stroke = Color;
            Canvas.SetLeft(e, X - Radius);
            Canvas.SetTop(e, Y - Radius);
            canvas.Children.Add(e);
        }

        public void Shift(Canvas canvas)
        {
            X += 1 * DirectionX;
            Y += 1 * DirectionY;

            if (X + 50 > canvas.ActualWidth)
            {
                DirectionX = -1;
            }
            if (X < 50)
            {
                DirectionX = 1;
            }
            if (Y + 50 > canvas.ActualHeight)
            {
                DirectionY = -1;
            }
            if (Y < 50)
            {
                DirectionY = 1;
            }
        }

        /*
        * This method will return true if the point (x, y)
        * is inside this circle object
        */
        public Boolean IsContaining(double x, double y)
        {
            double d = Math.Sqrt((x - X) * (x - X)
                + (y - Y) * (y - Y));
            return d <= Radius;
        }
        /*
         * This method return whether this circle object is
         * crossing rims with another circle c
         */
        public Boolean IsCrossingWith(Circle c)
        {
            double d = Math.Sqrt((X - c.X) * (X - c.X)
                + (Y - c.Y) * (Y - c.Y));
            return d < Radius + c.Radius;
        }
    }
}

