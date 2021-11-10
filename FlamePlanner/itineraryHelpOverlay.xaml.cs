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
    /// Interaction logic for itineraryHelpOverlay.xaml
    /// </summary>
    public partial class itineraryHelpOverlay : Page
    {
        private MainWindow mw;
        public itineraryHelpOverlay(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            mw.helpOverlayFrame.Content = null;
            mw.helpOverlayFrame.Visibility = Visibility.Hidden;
        }

        private void navDetailsBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            navDetails.Visibility = Visibility.Visible;
            navDetailsBorder.BorderBrush = Brushes.Transparent;
        }

        private void navDetailsBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            navDetails.Visibility = Visibility.Hidden;
            navDetailsBorder.BorderBrush = Brushes.LightCoral;
        }

        private void logInDetailsBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            loginDetails.Visibility = Visibility.Visible;
            logInDetailsBorder.BorderBrush = Brushes.Transparent;
        }

        private void logInDetailsBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            loginDetails.Visibility = Visibility.Hidden;
            logInDetailsBorder.BorderBrush = Brushes.LightCoral;
        }

        private void screenDetailsBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            screenDetails.Visibility = Visibility.Visible;
            screenDetailsBorder.BorderBrush = Brushes.Transparent;
        }

        private void screenDetailsBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            screenDetails.Visibility = Visibility.Hidden;
            screenDetailsBorder.BorderBrush = Brushes.LightCoral;
        }

        private void bottomDetailsBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            bottomDetails.Visibility = Visibility.Visible;
            bottomDetailsBorder.BorderBrush = Brushes.Transparent;
        }

        private void bottomDetailsBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            bottomDetails.Visibility = Visibility.Hidden;
            bottomDetailsBorder.BorderBrush = Brushes.LightCoral;
        }

        private void leftDetailsBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            leftDetails.Visibility = Visibility.Visible;
            leftDetailsBorder.BorderBrush = Brushes.Transparent;
        }

        private void leftDetailsBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            leftDetails.Visibility = Visibility.Hidden;
            leftDetailsBorder.BorderBrush = Brushes.LightCoral;
        }
    }
}
