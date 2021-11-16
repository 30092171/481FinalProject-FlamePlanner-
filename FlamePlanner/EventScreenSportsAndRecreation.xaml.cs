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
    /// Interaction logic for EventScreenSportsAndRecreation.xaml
    /// </summary>
    public partial class EventScreenSportsAndRecreation : Page
    {
        private MainWindow mw;
        public EventScreenSportsAndRecreation(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Event_Display_Button_Click(object sender, RoutedEventArgs e)
        {
            var tag = ((Button)sender).Tag; //allows for us to determine which of the events were clicked
            //MessageBox.Show(tag.ToString()); //Displays tag content, for debugging
            EventPopUpWindow epw = new EventPopUpWindow(mw);
            //populate epw via getters and setters here?
            epw.ShowDialog(); //Displays event info pop up and locks main window


        }

        private void Event_Up_Button_Click(object sender, RoutedEventArgs e)
        {
            EventScreenSpecialEvents eventscreenspecialevents = new EventScreenSpecialEvents(mw);
            this.NavigationService.Navigate(eventscreenspecialevents);
        }

        private void Event_Down_Button_Click(object sender, RoutedEventArgs e)
        {
            EventScreenFoodAndDrink eventscreenfoodanddrink = new EventScreenFoodAndDrink(mw);
            this.NavigationService.Navigate(eventscreenfoodanddrink);
        }
    }
}
