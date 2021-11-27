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
    /// Interaction logic for threeFramePage.xaml
    /// </summary>
    public partial class threeFramePage : Page
    {

        private MainWindow mw;
       /// <summary>
       /// 0 for itinerary (default)
       /// 1 for map
       /// 2 for events
       /// </summary>
       /// <param name="type"> This represents the type to which the main window should be set up</param>
        public threeFramePage(int type, MainWindow mw)
        {
            if (type < 0 || type > 2)
            {
                type = 0;
            }

            this.mw = mw;
            InitializeComponent();
            

            if (type == 0)
            {
                Itinerarypage ip = new Itinerarypage(mw);
                topRightFrame.Content = ip;
                bottomRightFrame.Content = new Itinerary_bottom(mw,ip);
                leftFrame.Content = new Itinerary_leftpannel(mw,ip);
                mw.nav_itinerary.Background = mw.NAV_SELECT_COLOUR;

            }
            else if (type == 1)
            {
                //Load map pages
                leftFrame.Content = new Event_left(mw);
                bottomRightFrame.Content = new MapBottom(mw);
                topRightFrame.Content = new Map(mw);
                mw.nav_map.Background = mw.NAV_SELECT_COLOUR;
            }
            else {
                //Load events pages
                leftFrame.Content = new Event_left(mw);
                bottomRightFrame.Content = new EventControls(mw);
                topRightFrame.Content = new EventScreen(mw);
                mw.nav_events.Background = mw.NAV_SELECT_COLOUR;
            }
                    
        }

        public void ResetAllFrames() {
            topRightFrame.Content = null;
            bottomRightFrame.Content = null;
            leftFrame.Content = null;
        }

        private void createNewItineraryButton_Click(object sender, RoutedEventArgs e)
        {
            //Create New ITINERARY (Prompt to save?)
            if (!mw.loggedIn)
            {
                itinerarySaveOptions isow = new itinerarySaveOptions(mw);
                isow.ShowDialog();
            }
        }

        private void loadItineraryButton_Click(object sender, RoutedEventArgs e)
        {
            //Load another itinerary (Have they logged in?) Prompt to save?
            if (!mw.loggedIn)
            {
                itinerarySaveOptions isow = new itinerarySaveOptions(mw);
                isow.ShowDialog();
            }
            else //logged in
            {
                itineraryLoadWindow ilw = new itineraryLoadWindow(mw);
                ilw.ShowDialog();
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //Save itinerary (Have they logged in?)
            if (!mw.loggedIn)
            {
                itinerarySaveOptions isow = new itinerarySaveOptions(mw);
                isow.ShowDialog();
            }
            else //logged in
            {
                ItinerarySave isw = new ItinerarySave(mw);
                isw.ShowDialog();
            }
        }
    }
}
