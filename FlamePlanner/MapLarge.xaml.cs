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

namespace FlamePlanner
{
    /// <summary>
    /// Interaction logic for MapLarge.xaml
    /// </summary>
    public partial class MapLarge : Page
    {
        private static int NUMPOINTS = 50;
        private static int ICONSIZE = 20;
        private static double SCROLLSENSITIVITY = 0.05;
        private bool mouseHeld = false;
        private Point lastPoint;
        private Random random;
        public MapLarge()
        {
            InitializeComponent();
            random = new Random();
            //PopulateDummyPoints();
        }

        private Thickness RandomPair()
        {
            return new Thickness(
                random.Next(0, (int)mapImage.Width - ICONSIZE),
                random.Next(0, (int)mapImage.Height - ICONSIZE), 0, 0);
        }

        private void PopulateDummyPoints()
        {
            for (int i = 0; i < NUMPOINTS; ++i)
            {
                Thickness t = RandomPair();
                MapEventButton m = new MapEventButton(true, ICONSIZE, ICONSIZE);
                mapGrid.Children.Add(m);
                m.Margin = t;
                
            }
        }

        private void map_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseHeld)
            {
                Point current = e.GetPosition(null);
                Vector displacement = current - lastPoint;
                Thickness margin = mapGrid.Margin;
                margin.Left += displacement.X;
                margin.Top += displacement.Y;
                mapGrid.Margin = margin;
                lastPoint = current;
            }
        }

        private void map_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseHeld = true;
            lastPoint = e.GetPosition(null);
        }

        private void map_MouseUp(object sender, MouseButtonEventArgs e) => mouseHeld = false;

        private void map_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                mapScale.ScaleX += SCROLLSENSITIVITY;
                mapScale.ScaleY += SCROLLSENSITIVITY;
            }
            else
            {
                mapScale.ScaleX -= SCROLLSENSITIVITY;
                mapScale.ScaleY -= SCROLLSENSITIVITY;
            }
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            mapScale.ScaleX = 2 * mapScale.ScaleX;
            mapScale.ScaleY = 2 * mapScale.ScaleY;
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            mapScale.ScaleX = mapScale.ScaleX / 2;
            mapScale.ScaleY = mapScale.ScaleY / 2;
        }
    }
}
