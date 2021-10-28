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
        private bool loggedIn;
        public SolidColorBrush NAV_SELECT_COLOUR = Brushes.LightCoral; //Should be treated as a constant, kept it public for simplicity

        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Content = new startPage(this); //Program starts with the start page loaded in the main frame
            this.loggedIn = false;
            navBarStackPanel.Visibility = Visibility.Hidden; //Hides nav bar until user starts itinerary proccess
            helpButton.Visibility = Visibility.Hidden;
        }

        private void nav_itinerary_Click(object sender, RoutedEventArgs e)
        {
            //This should only matter if the page is not currently selected, we use button colour to track this
            if (nav_itinerary.Background != NAV_SELECT_COLOUR)
            {
                resetNavButtonColours(Brushes.LightGray);
                nav_itinerary.Background = NAV_SELECT_COLOUR;
                //Navigate to itinary page
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
                if (mainFrame.Content.GetType() == typeof(threeFramePage))
                {
                    threeFramePage tfp = mainFrame.Content as threeFramePage;
                    tfp.topRightFrame.Content = new EventScreen(this);
                    tfp.bottomRightFrame.Content = new EventControls(this);
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
                t.Text = "SIGN OUT";
                this.loggedIn = true;
            }
            else
            {
                t.Text = "LOG IN / REGISTER";
                this.loggedIn = false;
            }
            logInOutButton.Content = t;
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            //Three Frame is Displayed
            if (mainFrame.Content.GetType() == typeof(threeFramePage))
            {
                if (nav_itinerary.Background == NAV_SELECT_COLOUR) //Itinerary Screen
                {

                }
                else if (nav_events.Background == NAV_SELECT_COLOUR) //Events screen
                {
                    helpOverlayFrame.Visibility = Visibility.Visible;
                    helpOverlayFrame.Content = new eventHelpOverlay(this);
                }
                else if (nav_map.Background == NAV_SELECT_COLOUR) //Map screen
                {

                }
                
            }
            
        }
    }
}
