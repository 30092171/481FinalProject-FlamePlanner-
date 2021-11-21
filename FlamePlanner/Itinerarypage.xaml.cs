using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Itinerarypage.xaml
    /// </summary>
    public partial class Itinerarypage : Page
    {
        private MainWindow mw;
        public Itinerarypage(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void customEventButton_Click(object sender, RoutedEventArgs e)
        {
            customEventInputWindow ceiw = new customEventInputWindow(mw);
            ceiw.ShowDialog();
        }

        private void TimeUpButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseLeftButtonDown_TopArrow(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine("Clicked Top arrow button");
        }

        private void Image_MouseLeftButtonDown_DownArrow(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine("Clicked Down arrow button");
        }

        private void Image_MouseLeftButtonDown_LeftArrow(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine("Clicked Left arrow button");
        }

        private void Image_MouseLeftButtonDown_RightArrow(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine("Clicked Right arrow button");
        }
    }
}
