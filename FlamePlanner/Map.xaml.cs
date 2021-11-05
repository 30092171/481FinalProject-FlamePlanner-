using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlamePlanner
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Page
    {
        private MainWindow mw;
        private bool mouseHeld = false;
        private double lastX = 0;
        private double lastY = 0;

        public Map(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }
        private void poi1_Click(object sender, RoutedEventArgs e)
        {
            //MapEvent me = new MapEvent("6 Street SW");
            // me.ShowDialog();
            EventPopUpWindow epw = new EventPopUpWindow(mw);
            epw.EventName = "6 Street SW";
            epw.ShowDialog();


        }
        private void poi2_Click(object sender, RoutedEventArgs e)
        {
            //MapEvent me = new MapEvent("Stampede");
            // me.ShowDialog();
            EventPopUpWindow epw = new EventPopUpWindow(mw);
            epw.EventName = "Stampede";
            epw.ShowDialog();
        }
        private void poi3_Click(object sender, RoutedEventArgs e)
        {
            //MapEvent me = new MapEvent("Prince Island Park");
            // me.ShowDialog();
            EventPopUpWindow epw = new EventPopUpWindow(mw);
            epw.EventName = "Prince Island Park";
            epw.ShowDialog();
        }

        private void mapGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseHeld)
            {
                Thickness margin = mapGrid.Margin;
                margin.Left = mapGrid.Margin.Left + (e.GetPosition(null).X - lastX);
                margin.Top = mapGrid.Margin.Top + (e.GetPosition(null).Y - lastY);
                
                mapGrid.Margin = margin;
                lastX = e.GetPosition(null).X;
                lastY = e.GetPosition(null).Y;

               

            }
        }

        private void mapGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseHeld = true;
            lastX = e.GetPosition(null).X;
            lastY = e.GetPosition(null).Y;
            

        }

        private void mapGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseHeld = false;
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
