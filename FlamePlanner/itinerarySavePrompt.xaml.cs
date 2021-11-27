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
    /// Interaction logic for itinerarySavePrompt.xaml
    /// </summary>
    public partial class itinerarySavePrompt : Window
    {
        private MainWindow mw;
        public itinerarySavePrompt(MainWindow mw)
        {


            this.mw = mw;
            InitializeComponent();//Initialize component first
            Account acc = mw.AccountDatabase[mw.currentAcount];//Call current account
            List<string> keys = new List<string>(acc.itineraryDict.Keys);
            savedList.Items.Clear();//Clear savedlist at the beginning

            foreach (string name in keys)
            {
                ListViewItem item = new ListViewItem();//Call list view to print out itinerary names
                item.Content = name;
                item.HorizontalContentAlignment = HorizontalAlignment.Center;//Center the text
                savedList.Items.Add(item);//Add new names
            }

        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //This is just an info page, can close right away
        }
    }
}
