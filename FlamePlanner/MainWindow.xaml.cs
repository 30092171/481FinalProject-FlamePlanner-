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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool loggedIn;
        public SolidColorBrush NAV_SELECT_COLOUR = Brushes.LightCoral; //Should be treated as a constant, kept it public for simplicity

        public Dictionary<string, Account> AccountDatabase; //Dictioary of accounts. Key = Username, Value = Account Object
        public string currentAcount = ""; //string representing username of the current account

        public Itinerary bufferItinerary;

        public MainWindow()
        {
            InitializeComponent();

            this.AccountDatabase = new Dictionary<string, Account>();

            //Account GuestAccount = new Account("Guest", "1234"); //dummy guest account for users who do not log in
            //this.AccountDatabase["Guest"] = GuestAccount; //Adds account to database
            //this.currentAcount = "Guest"; //Current username is Guest
            this.loggedIn = false; //No one has logged in yet
            this.bufferItinerary = new Itinerary("");

            mainFrame.Content = new startPage(this); //Program starts with the start page loaded in the main frame
            navBarStackPanel.Visibility = Visibility.Hidden; //Hides nav bar until user starts itinerary proccess
            helpButton.Visibility = Visibility.Hidden;
        }

        ///// <summary>
        /////  Resets current account to guest
        ///// </summary>
        ///// <param name="wipe"> If true, will reset stored guest account; false, just swithes currentAccount field</param>
        //public void backToGuestAccount(bool wipe)
        //{
        //    this.currentAcount = "Guest";
        //    this.loggedIn = false;

        //    if (wipe)
        //    {
        //        this.AccountDatabase.Remove("Guest");
        //        this.AccountDatabase["Guest"] = new Account("Guest", "1234");
        //    }
        //}

        private void nav_itinerary_Click(object sender, RoutedEventArgs e)
        {
            //This should only matter if the page is not currently selected, we use button colour to track this
            if (nav_itinerary.Background != NAV_SELECT_COLOUR)
            {
                resetNavButtonColours(Brushes.LightGray);
                nav_itinerary.Background = NAV_SELECT_COLOUR;
                //Navigate to itinary page
                if (mainFrame.Content != null && mainFrame.Content.GetType() == typeof(threeFramePage))
                {
                    threeFramePage tfp = mainFrame.Content as threeFramePage;
                    tfp.topRightFrame.Content = new Itinerarypage(this);
                    tfp.bottomRightFrame.Content = new Itinerary_bottom(this);
                    
                    if (tfp.leftFrame.Content == null || tfp.leftFrame.Content.GetType() != typeof(Itinerary_leftpannel))
                    {
                        Itinerary_leftpannel ilp = new Itinerary_leftpannel(this);
                        tfp.leftFrame.Content = ilp;
                    }
                    //ensure itinerary frame is loaded in left, if it is not load it...
                }
            }
        }

        private void nav_map_Click(object sender, RoutedEventArgs e)
        {
            //This should only matter if the page is not currently selected, we use button colour to track this
            if (nav_map.Background != NAV_SELECT_COLOUR)
            {
                resetNavButtonColours(Brushes.LightGray);
                nav_map.Background = NAV_SELECT_COLOUR;
                //Navigate to map page
                if (mainFrame.Content != null && mainFrame.Content.GetType() == typeof(threeFramePage))
                {
                    threeFramePage tfp = mainFrame.Content as threeFramePage;
                    tfp.topRightFrame.Content = new MapLarge();
                    tfp.bottomRightFrame.Content = new MapBottom(this);
                    if(tfp.leftFrame.Content == null || tfp.leftFrame.Content.GetType() != typeof(Event_left))
                    {
                        Event_left el = new Event_left(this);
                        tfp.leftFrame.Content = el;
                    }
                    //ensure itinerary frame is loaded in left, if it is not load it...
                }
            }
        }
        /// <summary>
        /// Resets all nav buttons to default unselected colour to which is usally lightGrey
        /// </summary>
        /// <param name="colour"></param>
        private void resetNavButtonColours(SolidColorBrush colour) {
            nav_itinerary.Background = colour;
            nav_map.Background = colour;
            nav_events.Background = colour;

        }

        private void nav_events_Click(object sender, RoutedEventArgs e)
        {
            //This should only matter if the page is not currently selected, we use button colour to track this
            if (nav_events.Background != NAV_SELECT_COLOUR)
            {
                resetNavButtonColours(Brushes.LightGray);
                nav_events.Background = NAV_SELECT_COLOUR;
                //Navigate to events page
                if (mainFrame.Content != null && mainFrame.Content.GetType() == typeof(threeFramePage))
                {
                    threeFramePage tfp = mainFrame.Content as threeFramePage;
                    tfp.topRightFrame.Content = new EventScreen(this);
                    tfp.bottomRightFrame.Content = new EventControls(this);
                    if (tfp.leftFrame.Content == null || tfp.leftFrame.Content.GetType() != typeof(Event_left))
                    {
                        Event_left el = new Event_left(this);
                        tfp.leftFrame.Content = el;
                    }
                    //ensure itinerary frame is loaded in left, if it is not load it...
                }
            }
            
        }

        private void logInOutButton_Click(object sender, RoutedEventArgs e)
        {
            TextBlock t = new TextBlock();
            t.TextWrapping = TextWrapping.Wrap;
            t.TextAlignment = TextAlignment.Center;

            if (!this.loggedIn)
            {
                mainSignupLoginWindow mslw = new mainSignupLoginWindow(this);
                mslw.ShowDialog(); //Displays log in window (locks main window)
                
                //not needed anymore as this is done at the end of the log in and sign up windows
                //t.Text = "SIGN OUT";
                //this.loggedIn = true;
            }
            else //button says sign out
            {
                t.Text = "LOG IN / REGISTER";
                this.loggedIn = false;
                logInOutButton.Content = t;
            }
            //logInOutButton.Content = t;
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            //Three Frame is Displayed
            if (mainFrame.Content != null && mainFrame.Content.GetType() == typeof(threeFramePage))
            {
                if (nav_itinerary.Background == NAV_SELECT_COLOUR) //Itinerary Screen
                {
                    helpOverlayFrame.Visibility = Visibility.Visible;
                    helpOverlayFrame.Content = new itineraryHelpOverlay(this);

                }
                else if (nav_events.Background == NAV_SELECT_COLOUR) //Events screen
                {
                    helpOverlayFrame.Visibility = Visibility.Visible;
                    helpOverlayFrame.Content = new eventHelpOverlay(this);
                }
                else if (nav_map.Background == NAV_SELECT_COLOUR) //Map screen
                {
                    helpOverlayFrame.Visibility = Visibility.Visible;
                    helpOverlayFrame.Content = new mapHelpOverlay(this);
                }
                
            }
            
        }
    }
}
