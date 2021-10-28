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
    /// Interaction logic for signupWindow.xaml
    /// </summary>
    public partial class signupWindow : Window
    {
        private bool success = true;
        private MainWindow mw;
        public signupWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (!success)//if sign up unsuccessful (dummy for now)
            {
                this.errorMessageBlock.Visibility = Visibility.Visible;
            }
            else //Sign Up successful
            {
                //post data to mw somehow
                TextBlock t = new TextBlock();
                t.TextWrapping = TextWrapping.Wrap;
                t.TextAlignment = TextAlignment.Center;
                t.Text = "SIGN OUT";
                mw.logInOutButton.Content = t;
                mw.loggedIn = true;
                this.Close();
            }
        }
    }
}
