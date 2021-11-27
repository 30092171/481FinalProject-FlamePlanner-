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
    /// Interaction logic for ItinerarySave.xaml
    /// </summary>
    public partial class ItinerarySave : Window
    {
        private MainWindow mw;
        public ItinerarySave(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
            

        }

        private void saveItineraryButton_Click(object sender, RoutedEventArgs e)
        {
            string itinName = itineraryNameField.Text;
            //Ensure field (itinerart name) has been populated by user (maybe suggest default)
            if (itinName != "")
            {
                //Set account to current
                string current = mw.currentAcount;
                Account acc = mw.AccountDatabase[mw.currentAcount];

                //Check if itinerary name exists
                if (acc.itineraryDict.ContainsKey(itinName))
                {
                    MessageBoxResult result = MessageBox.Show("An itinerary with this name already exists.\nDo you want to overwrite into the previously saved itinerary?", "My App", MessageBoxButton.YesNo);
                    
                    //Modify, if user chooses to rewrite into an existing itinerary
                    if (result.ToString().Equals("Yes")){ //If user wants to overwrite

                        //Itinerary wants to be overwritten

                        //Switch to bufferItinerary, convert from string to itinerary
                        mw.bufferItinerary.itineraryTitle = itinName;

                        //Add itinerary name as new key to store new itinerary
                        Itinerary i = new Itinerary(mw.bufferItinerary);
                       

                        //Add buffer itinerary into the dictionary
                        acc.itineraryDict[itinName] = i;

                        //And continue to the next page after saved successfully
                    }
                    else
                    {
                        //If user does not want to re-write then it stays on the same page with error message
                        //exit out of everything, abort save
                        MessageBox.Show("Save Aborted");
                        this.Close();
                        return;
                       
                    }
                }
                else {
                    //Itinerary does not exist previously, so adding a new itinerary would not be a problem

                    //Switch to bufferItinerary, convert from string to itinerary
                    mw.bufferItinerary.itineraryTitle = itinName;


                    //Add itinerary name as new key to store new itinerary
                    Itinerary i = new Itinerary(mw.bufferItinerary);


                    //Add buffer itinerary into the dictionary
                    acc.itineraryDict[itinName] = i;


                    //And continue to the next page after saved successfully
                }



                //Save itinerary in mw under name somehow

                itinerarySavePrompt ispw = new itinerarySavePrompt(mw);

                this.Close();
                ispw.ShowDialog();
            }
            else
            {
                //If input itinerary is blank print error message
                errorMessage1_Click(sender, e);
            }

        }




        private void errorMessage1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Itinerary name cannot be blank", "My App", MessageBoxButton.OK);
        }

        private void errorMessage2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Confirm if you want to re-write into this itinerary", "My App", MessageBoxButton.YesNo);
        }

        private void errorMessage3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Re-enter itinerary name", "My App", MessageBoxButton.YesNo);
        }





    }
}
