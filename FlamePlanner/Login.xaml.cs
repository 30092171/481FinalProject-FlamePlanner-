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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private MainWindow mw;
        private bool success = true;
        public Login(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void submitLogInButton_Click(object sender, RoutedEventArgs e)
        {
            //Check log in
            if (!success) //if log in unsuccessful (dummy for now)
            {
                this.errorMessageBlock.Visibility = Visibility.Visible;
            }
            else //Log in Successful
            {
                //Post data to mw somehow
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
