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
            //Confirm

            MessageBoxResult result = MessageBox.Show("Are you sure you want to Clear the Itineary and\nDiscard any Unsaved Progress?", "Clear Itinerary", MessageBoxButton.YesNo);

            //Modify, if user chooses to rewrite into an existing itinerary
            if (result.ToString().Equals("Yes"))
            { //If user wants to wipe current buffer for new one
                mw.bufferItinerary = new Itinerary(""); //Wipes buffer itinerary

                //If an itinerary was previously displayed, reset it to reflect new load
                if (mw.mainFrame.Content.GetType() == typeof(threeFramePage))
                {
                    if ((mw.mainFrame.Content as threeFramePage).topRightFrame.Content.GetType() == typeof(Itinerarypage))
                    {
                        Itinerarypage ip = new Itinerarypage(mw);
                        (mw.mainFrame.Content as threeFramePage).topRightFrame.Content = ip;
                        Itinerary_leftpannel lp = new Itinerary_leftpannel(mw, ip);
                        (mw.mainFrame.Content as threeFramePage).leftFrame.Content = lp;
                    }
                    else //navigate to itinerary page
                    {
                        mw.switchToItineraryMode();
                    }

                }
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
                Account acc = mw.AccountDatabase[mw.currentAcount];
                if (acc.itineraryDict.Count == 0)
                {
                    MessageBox.Show("There are No Itinearies Saved on this Account to Load");
                }
                else
                {
                    itineraryLoadWindow ilw = new itineraryLoadWindow(mw);
                    ilw.ShowDialog();
                }
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
