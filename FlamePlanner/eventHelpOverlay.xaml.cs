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
    /// Interaction logic for eventHelpOverlay.xaml
    /// </summary>
    public partial class eventHelpOverlay : Page
    {
        private MainWindow mw;
        public eventHelpOverlay(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            mw.helpOverlayFrame.Content = null;
            //mw.helpOverlayFrame.Visibility = Visibility.Hidden;
        }

        private void logInHelpTextBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            logInHelpText.Visibility = Visibility.Visible;
            //logInHelpTextBorder.BorderBrush = Brushes.Transparent;
        }

        private void logInHelpTextBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            logInHelpText.Visibility = Visibility.Hidden;
            //logInHelpTextBorder.BorderBrush = Brushes.LightCoral;
        }

        private void currentPageDescriptionBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            currentPageDescription.Visibility = Visibility.Visible;
            //currentPageDescriptionBorder.BorderBrush = Brushes.Transparent;
        }

        private void currentPageDescriptionBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            currentPageDescription.Visibility = Visibility.Hidden;
            //currentPageDescriptionBorder.BorderBrush = Brushes.LightCoral;
        }

        private void navBarDescriptionBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            navBarDescription.Visibility = Visibility.Visible;
            //navBarDescriptionBorder.BorderBrush = Brushes.Transparent;
        }

        private void navBarDescriptionBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            navBarDescription.Visibility = Visibility.Hidden;
            //navBarDescriptionBorder.BorderBrush = Brushes.LightCoral;
        }

        private void leftDescriptionBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            leftDescription.Visibility = Visibility.Visible;
            //leftDescriptionBorder.BorderBrush = Brushes.Transparent;
        }

        private void leftDescriptionBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            leftDescription.Visibility = Visibility.Hidden;
            //leftDescriptionBorder.BorderBrush = Brushes.LightCoral;
        }

        private void bottomDescriptionBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            bottomDescription.Visibility = Visibility.Visible;
            //bottomDescriptionBorder.BorderBrush = Brushes.Transparent;
        }

        private void bottomDescriptionBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            bottomDescription.Visibility = Visibility.Hidden;
            //bottomDescriptionBorder.BorderBrush = Brushes.LightCoral;
        }
    }
}
