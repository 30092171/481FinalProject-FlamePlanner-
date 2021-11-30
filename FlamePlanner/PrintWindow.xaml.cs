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
    /// Interaction logic for PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {
        private MainWindow mw;
        public PrintWindow(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
            d1.SelectedDate = new DateTime(2021, 9, 5);
            d2.SelectedDate = new DateTime(2021, 9, 12);
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            if(d1.SelectedDate > d2.SelectedDate)
            {
                MessageBox.Show("Your End Date is Earlier than your start Date!");
            }
            else
            {
                MessageBox.Show("Calling System Printing Module...");
                this.Close();
            }
        }
    }
}
