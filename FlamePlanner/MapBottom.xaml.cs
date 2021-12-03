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
    /// Interaction logic for MapBottom.xaml
    /// </summary>
    public partial class MapBottom : UserControl
    {
        private MainWindow mw;
        public MapBottom(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //sort stuff
            threeFramePage tfp = mw.mainFrame.Content as threeFramePage;
            if (tfp == null) return;
            Map map = tfp.topRightFrame.Content as Map;
            if (map == null) return;
            EventFilter f = (EventFilter)comboBox.SelectedIndex;
            foreach (object o in map.mapGrid.Children)
            {
                MapEventButton m = o as MapEventButton;
                if (m == null) continue;
                else
                {
                    EventFilter b;
                    if (!Enum.TryParse(m.Tag.ToString(), out b))
                        b = EventFilter.NONE;
                    if (m.Tag != null && 
                        (f == EventFilter.NONE || b == f))
                    {
                        m.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        m.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        private void addressSearchGoButton_Click(object sender, RoutedEventArgs e)
        {
            //change view
            threeFramePage tfp = mw.mainFrame.Content as threeFramePage;
            tfp.topRightFrame.Content = new Map(mw);
            addressSearchbox.Text = "9 Ave SW";
        }

        private static Thickness stampedeMargin = new Thickness(-938, -638, 0, 0);
        private static Thickness stampedeDotMargin = new Thickness(983, 645, 295, 247);
        private static int stampedeScale = 2;

        private static Thickness ecMargin = new Thickness(-188, 380, 0, 0);
        private static Thickness ecDotMargin = new Thickness(642, 230, 636, 662);
        private static float ecScale = 2.3f;

        private static Thickness wtMargin = new Thickness(-350, -40, 0, 0);
        private static float wtScale = 2;

        private void eventSearchGoButton_Click(object sender, RoutedEventArgs e)
        {
            string evt = eventSearchbox.Text;
            if (evt.Equals("Stampede"))
            {
                threeFramePage tfp = mw.mainFrame.Content as threeFramePage;
                Map map = new Map(mw);
                tfp.topRightFrame.Content = map;
                map.mapGrid.Margin = stampedeMargin;
                //map.blueDot.Margin = stampedeDotMargin;
                map.mapScale.ScaleX = map.mapScale.ScaleY = stampedeScale;
                //addressSearchbox.Text = "Stampede Grounds";
            } else if (evt.Equals("Eau Claire"))
            {
                threeFramePage tfp = mw.mainFrame.Content as threeFramePage;
                Map map = new Map(mw);
                tfp.topRightFrame.Content = map;
                map.mapGrid.Margin = ecMargin;
                //map.blueDot.Margin = ecDotMargin;
                map.mapScale.ScaleX = map.mapScale.ScaleY = ecScale;
                //addressSearchbox.Text = "Eau Claire";
            }else if (evt.Equals("Wine Tasting"))
            {
                threeFramePage tfp = mw.mainFrame.Content as threeFramePage;
                Map map = new Map(mw);
                tfp.topRightFrame.Content = map;
                map.mapGrid.Margin = wtMargin;

                //map.blueDot.Margin = ecDotMargin;
                map.mapScale.ScaleX = map.mapScale.ScaleY = wtScale;
                //addressSearchbox.Text = "Eau Claire";
            }
        }
    }
}
