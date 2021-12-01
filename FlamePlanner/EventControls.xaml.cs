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
    /// Interaction logic for EventControls.xaml
    /// </summary>
    public partial class EventControls : Page
    {
        private MainWindow mw;
        public EventControls(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        private void cbValueType_DropDownClosed(object sender, EventArgs e)
        {
            {
                if (cb.SelectedIndex == 0)
                {
                    if (mw.mainFrame.Content.GetType() == typeof(threeFramePage))
                    {
                        threeFramePage tfp = mw.mainFrame.Content as threeFramePage;
                        tfp.topRightFrame.Content = new EventScreen(mw);

                    }
                }

                if (cb.SelectedIndex == 1)
                {
                    if (mw.mainFrame.Content.GetType() == typeof(threeFramePage))
                    {
                        threeFramePage tfp = mw.mainFrame.Content as threeFramePage;
                        tfp.topRightFrame.Content = new EventScreenFoodAndDrink(mw);

                    }
                }
                if (cb.SelectedIndex == 2)
                {
                    if (mw.mainFrame.Content.GetType() == typeof(threeFramePage))
                    {
                        threeFramePage tfp = mw.mainFrame.Content as threeFramePage;
                        tfp.topRightFrame.Content = new EventScreenSpecialEvents(mw);

                    }
                }
                if (cb.SelectedIndex == 5)
                {
                    if (mw.mainFrame.Content.GetType() == typeof(threeFramePage))
                    {
                        threeFramePage tfp = mw.mainFrame.Content as threeFramePage;
                        tfp.topRightFrame.Content = new EventScreenSportsAndRecreation(mw);

                    }
                }
            }
        }

        private void Event_Search_Button_Click(object sender, RoutedEventArgs e)
        {
            string var;
            string calgaryFlames = "calgary flames";
            string wineEvent = "wine";
            var = textBox.Text;
            if (String.Equals(var, calgaryFlames))
            {
                threeFramePage tfp = mw.mainFrame.Content as threeFramePage;
                tfp.topRightFrame.Content = new EventSearchCalgaryFlames(mw);
                textBox.Text = String.Empty;
            }
            if (String.Equals(var, wineEvent))
            {
                threeFramePage tfp = mw.mainFrame.Content as threeFramePage;
                tfp.topRightFrame.Content = new EventSearchWine(mw);
                textBox.Text = String.Empty;
            }
        }

        private void dp1_change_date(object sender, SelectionChangedEventArgs e)
        {
            if (dp1.SelectedDate == new DateTime(2021, 9, 12) && (dp2.SelectedDate == new DateTime(2021, 9, 18)))
            {
                threeFramePage tfp = mw.mainFrame.Content as threeFramePage;
                tfp.topRightFrame.Content = new EventDateRange(mw);
                dp1.SelectedDate = null;
                dp2.SelectedDate = null;
            }    
        }

        private void dp2_change_date(object sender, SelectionChangedEventArgs e)
        {
            if (dp1.SelectedDate == new DateTime(2021, 9, 12) && (dp2.SelectedDate == new DateTime(2021, 9, 18)))
            {
                threeFramePage tfp = mw.mainFrame.Content as threeFramePage;
                tfp.topRightFrame.Content = new EventDateRange(mw);
                dp1.SelectedDate = null;
                dp2.SelectedDate = null;
            }
        }
    }
}
