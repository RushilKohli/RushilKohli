using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ShapeAnimator
{
    class Square
    {
        public double X;
        public double Y;
        public double Width;
        public double Height;
        public int DirectionX = 1;
        public int DirectionY = 1;
        public Brush Color;

        public Square(double x, double y, double w, double h, Brush c)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
            Color = c;
        }

        public void Draw(Canvas canvas)
        {
            System.Windows.Shapes.Rectangle sq = new System.Windows.Shapes.Rectangle();
            sq.Width = Width;
            sq.Height = Height;
            sq.Stroke = Color;

            Canvas.SetLeft(sq, X);
            Canvas.SetTop(sq, Y);
            canvas.Children.Add(sq);
        }

        public void Shift(Canvas canvas)
        {
            X += 1 * DirectionX;
            Y += 1 * DirectionY;
            if (X + Width > canvas.ActualWidth)
            {
                DirectionX = -1;
            }
            if (X + Width/2 < Width/2)
            {
                DirectionX = 1;
            }
            if (Y + Width + 10 > canvas.ActualHeight)
            {
                DirectionY = -1;
            }
            if (Y + Width/2 < Width/2)
            {
                DirectionY = 1;
            }
        }
    }
}