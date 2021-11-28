using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FlamePlanner
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Page
    {
        private static double SCROLLSENSITIVITY = 0.1;
        private MainWindow mw;
        private bool mouseHeld = false;
        private Point lastPoint;

        public Map(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }
        private void stampede_Click(object sender, RoutedEventArgs e)
        {
            EventPopUpWindow epw = new EventPopUpWindow(mw, AllEvents.Stampede);
            epw.ShowDialog();
        }

        private void thriller_Click(object sender, RoutedEventArgs e)
        {
            EventPopUpWindow epw = new EventPopUpWindow(mw, AllEvents.Thriller);
            epw.ShowDialog();
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
            if(e.Delta > 0)
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
            mapScale.ScaleX = 2*mapScale.ScaleX;
            mapScale.ScaleY = 2 * mapScale.ScaleY;
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            mapScale.ScaleX = mapScale.ScaleX/2;
            mapScale.ScaleY = mapScale.ScaleY/2;
        }
    }
}
