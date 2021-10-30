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
    /// Interaction logic for startPage.xaml
    /// </summary>
    public partial class startPage : Page
    {
        private MainWindow mw;
        public startPage(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void startCreateButton_Click(object sender, RoutedEventArgs e)
        {
            mw.navBarStackPanel.Visibility = Visibility.Visible;
            mw.helpButton.Visibility = Visibility.Visible;
            mw.mainFrame.Content = new threeFramePage(0,mw); //Navigates to new Itinerary Page
            mw.nav_itinerary.Background = mw.NAV_SELECT_COLOUR; //Selects the appropriate nav tab
        }

        private void startLoadButton_Click(object sender, RoutedEventArgs e)
        {
            //Log in window then load threeFramePage 0
            //Create New ITINERARY (Prompt to save?)
            if (!mw.loggedIn)
            {
                itinerarySaveOptions isow = new itinerarySaveOptions(mw);
                isow.ShowDialog();
            }
            else //logged in
            {
                itineraryLoadWindow ilw = new itineraryLoadWindow(mw);
                ilw.ShowDialog(); //Allows user to select itinerary to load

                //Communication should be done within other window

                //Sets up application, itinerary should already be populated
                mw.navBarStackPanel.Visibility = Visibility.Visible;
                mw.helpButton.Visibility = Visibility.Visible;
                mw.mainFrame.Content = new threeFramePage(0, mw); //Navigates to new Itinerary Page
            }
            //mw.navBarStackPanel.Visibility = Visibility.Visible;
            //mw.nav_itinerary.Background = mw.NAV_SELECT_COLOUR; //Selects the appropriate nav tab
        }
    }
}
