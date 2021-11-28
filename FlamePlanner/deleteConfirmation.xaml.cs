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
    /// Interaction logic for deleteConfirmation.xaml
    /// </summary>
    public partial class deleteConfirmation : Window
    {
        private MainWindow mw;
        private Account acc;
        public deleteConfirmation(MainWindow mw)
        {
            //Assumes user is logged in and acc.itineraryDict.Count > 0
            this.mw = mw;
            this.acc = mw.AccountDatabase[mw.currentAcount];
            InitializeComponent();
            
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

        private void itineraryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itineraryList.SelectedItem != null)
            {
                //Loading Message Doesn't work for now because XML updates when function returns after loading...
                //warning.Visibility = Visibility.Collapsed;
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

                //warning.Visibility = Visibility.Visible;
                //loadingMessage.Visibility = Visibility.Collapsed;

            }
        }

        private void DeleteItinerary_Click(object sender, RoutedEventArgs e)
        {
            if (itineraryList.SelectedItem != null)
            {
                
                ListViewItem item = itineraryList.SelectedItem as ListViewItem;
                string selectedName = item.Tag.ToString();


                //Confirm
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the Itineary Named \'"+ selectedName+"\' from your account?", "My App", MessageBoxButton.YesNo);

                //Modify, if user chooses to rewrite into an existing itinerary
                if (result.ToString().Equals("Yes"))
                { //If user wants to delete

                    acc.itineraryDict.Remove(selectedName); //Should exist since keys are what make the ListViewItems tags
                    //buffer itinearary does not need to change as they are simply deleting a template
                    this.Close();

                }



                

            }
        }
    }
}
