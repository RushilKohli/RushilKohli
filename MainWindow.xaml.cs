using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ShapeAnimator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int shapeMode = 0; // 0 for circle, 1 for square

        List<Circle> circleArr = new List<Circle>();
        List<Rectangle> rectangleArr = new List<Rectangle>();
        List<Square> squareArr = new List<Square>();
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {   
            InitializeComponent();
        }

        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Setting shape to 0");
            shapeMode = 0;
        }

        private void Square_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Setting shape to 1");
            shapeMode = 1;
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Setting shape to 1");
            shapeMode = 2;
        }

        private void Step_Click(object sender, RoutedEventArgs e)
        {
            Step();
        }

        private void Step()
        {
            ShapeCanvas.Children.Clear();
            foreach (Circle c in circleArr)
            {
                c.Shift(ShapeCanvas);
                c.Draw(ShapeCanvas);
            }

            foreach (Rectangle rect in rectangleArr)
            {
                rect.Shift(ShapeCanvas);
                rect.Draw(ShapeCanvas);
            }

            foreach (Square sq in squareArr)
            {
                sq.Shift(ShapeCanvas);
                sq.Draw(ShapeCanvas);
            }
        }
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(ShapeCanvas);

            if (shapeMode == 0)
            {
                Circle c = new Circle(p.X, p.Y, 50, GetRandomColor());
                c.Draw(ShapeCanvas);
                circleArr.Add(c);
            }
            else if(shapeMode == 1)
            {
                // square
                Square sq = new Square(p.X, p.Y, 100, 100, GetRandomColor());
                sq.Draw(ShapeCanvas);
                squareArr.Add(sq);
            }
            else
            {
                // rectangle
                Rectangle rect = new Rectangle(p.X, p.Y, 100, 50, GetRandomColor());
                rect.Draw(ShapeCanvas);
                rectangleArr.Add(rect);
            }
        }

        private Brush GetRandomColor()
        {
            Brush[] colors = new Brush[] { Brushes.Red, Brushes.Yellow, Brushes.Blue,
                Brushes.Cyan, Brushes.DeepPink, Brushes.Green};
            Random rand = new Random();
            int colorIdx = rand.Next(6);
            return colors[colorIdx];
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            timer.Start();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Step();
        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

        }
    }
}
