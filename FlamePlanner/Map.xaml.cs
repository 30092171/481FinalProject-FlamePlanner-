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
            EventPopUpWindow epw = new EventPopUpWindow(mw)
                .SetTitle((sender as MapEventButton).Text)
                .SetImage(new BitmapImage(new Uri("CalgaryStampedeEvent.jpg", UriKind.Relative)))
                .SetTime("11:00 AM - 12:00 AM")
                .SetDate("July 3 - 12 2020")
                .SetLocation("Stampede Grounds (1410 Olympic Way SE, Calgary, AB T2G 2W1)")
                .SetDescription("At the heart of the Calgary Stampede, you’ll find more than 2,500 dedicated volunteers. They embody western values by hosting events across the city, supporting community celebrations and making the Calgary Stampede The Greatest Outdoor Show on Earth. In addition, the Board of Directors are unpaid volunteers who contribute their time to govern the affairs of the Calgary Stampede.")
                .SetLinks("https://www.calgarystampede.com/");
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
