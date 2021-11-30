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
using System.Windows.Shapes;

namespace FlamePlanner
{
    /// <summary>
    /// Interaction logic for itineraryLoadWindow.xaml
    /// Assumes user is logged into a valid account and there is at least one Itineary Saved
    /// </summary>
    public partial class itineraryLoadWindow : Window
    {
        private MainWindow mw;
        private Account acc;
        public itineraryLoadWindow(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();

            //Once again, Assumes user is logged in and acc.itineraryDict.Count > 0
            this.acc = mw.AccountDatabase[mw.currentAcount];
            loadItineraryList();

            
        }

        private void loadItineraryList()
        {
            itineraryList.Items.Clear();
            List<string> keys = new List<string>(acc.itineraryDict.Keys); //Might not work but try it


            foreach (string name in keys)
            {
                ListViewItem item = new ListViewItem();//Call list view to print out itinerary names
                item.Content = name;
                item.HorizontalContentAlignment = HorizontalAlignment.Right;//Right Align the text
                item.Tag = name;
                itineraryList.Items.Add(item);//Add new names
            }
            
        }

        private void loadItinerary_Click(object sender, RoutedEventArgs e)
        {
            if (itineraryList.SelectedItem != null)
            {
                //loadingWarning.Visibility = Visibility.Collapsed;
                //loadingMessage.Visibility = Visibility.Visible;

                
                ListViewItem item = itineraryList.SelectedItem as ListViewItem;
                string selectedName = item.Tag.ToString();                

                mw.bufferItinerary = new Itinerary(acc.itineraryDict[selectedName]); //Should exist since keys are what make the ListViewItems tags
                
                //If an itinerary was previously displayed, reset it to reflect new load
                if(mw.mainFrame.Content.GetType() == typeof(threeFramePage))
                {
                    if((mw.mainFrame.Content as threeFramePage).topRightFrame.Content.GetType() == typeof(Itinerarypage)){
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

                this.Close();

            }
        }

        private void itineraryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itineraryList.SelectedItem != null)
            {
                //Loading Message Doesn't work for now because XML updates when function returns after loading...
                //loadingWarning.Visibility = Visibility.Collapsed;
                //loadingMessage.Visibility = Visibility.Visible;


                //Load preview frame here
                ListViewItem item = itineraryList.SelectedItem as ListViewItem;
                string selection = item.Tag.ToString();
               
                Itinerary i = new Itinerary(acc.itineraryDict[selection]);


                Itinerarypage ip = new Itinerarypage(mw);
                ip.switchItineraryToDisplay(i);
                ip.customEventButton.Visibility = Visibility.Collapsed; //Hides + button as it is a preview
                ip.printButton.Visibility = Visibility.Collapsed;
                this.previewFrame.Content = ip;

                //loadingWarning.Visibility = Visibility.Visible;
                //loadingMessage.Visibility = Visibility.Collapsed;

            }

        }
    }
}
