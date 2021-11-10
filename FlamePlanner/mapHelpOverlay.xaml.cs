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
    /// Interaction logic for mapHelpOverlay.xaml
    /// </summary>
    public partial class mapHelpOverlay : Page
    {
        private MainWindow mw;
        public mapHelpOverlay(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            mw.helpOverlayFrame.Content = null;
            mw.helpOverlayFrame.Visibility = Visibility.Hidden;
        }

        private void navDescriptionBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            navDescription.Visibility = Visibility.Visible;
            //navDescriptionBorder.BorderBrush = Brushes.Transparent;
        }

        private void navDescriptionBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            navDescription.Visibility = Visibility.Hidden;
            //navDescriptionBorder.BorderBrush = Brushes.LightCoral;
        }

        private void logInDescriptionBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            logInDescription.Visibility = Visibility.Visible;
            //logInDescriptionBorder.BorderBrush = Brushes.Transparent;
        }

        private void logInDescriptionBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            logInDescription.Visibility = Visibility.Hidden;
            //logInDescriptionBorder.BorderBrush = Brushes.LightCoral;
        }

        private void screenDescriptionBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            screenDesciption.Visibility = Visibility.Visible;
            //screenDescriptionBorder.BorderBrush = Brushes.Transparent;
        }

        private void screenDescriptionBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            screenDesciption.Visibility = Visibility.Hidden;
            //screenDescriptionBorder.BorderBrush = Brushes.LightCoral;
        }

        private void bottomDescriptionBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            bottomDescription.Visibility = Visibility.Visible;
           // bottomDescriptionBorder.BorderBrush = Brushes.Transparent;
        }

        private void bottomDescriptionBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            bottomDescription.Visibility = Visibility.Hidden;
            //bottomDescriptionBorder.BorderBrush = Brushes.LightCoral;
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
    }
}
