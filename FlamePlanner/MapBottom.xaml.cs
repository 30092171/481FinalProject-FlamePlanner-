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
                    if (!Enum.TryParse<EventFilter>(m.Tag.ToString(), out b))
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
    }
    public enum EventFilter
    {
        NONE, Family, Concert, Food, Special, Video, Exhibit, Shop, Sport, Theatre
    }
}
