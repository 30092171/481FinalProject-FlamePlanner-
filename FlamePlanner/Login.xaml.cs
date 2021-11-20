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
using static FlamePlanner.Account;

namespace FlamePlanner
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private MainWindow mw;
        private bool success = false;
        public Login(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void submitLogInButton_Click(object sender, RoutedEventArgs e)
        {
            //If user exist in data base then proceed
            if (mw.AccountDatabase.ContainsKey(usernameField.Text) == true)
            {
                Account a = mw.AccountDatabase[usernameField.Text];
                //Check if the stored password is the same as the password stored in the database
                if (a.CheckPassword(passwordField.Password)==true)
                {
                    success = true;//Return true if it exists
                }
                //If its not in the database return false
                else
                {
                    //Check if the stored password does not equal to the input password
                    errorMessage1_Click(sender, e);
                    success = false;
                }
            }
            else {
                //If the user does not exist
                success = false;

                if (usernameField.Text.Equals(""))
                {
                    errorMessage3_Click(sender, e);
                }

                else if (passwordField.Password.Equals(""))
                {
                    errorMessage4_Click(sender, e);
                }

                else if (!usernameField.Equals("") && !mw.AccountDatabase.ContainsKey(usernameField.Text)) {
                    errorMessage2_Click(sender, e);
                }


            }



            //Check log in
            if (!success) //if log in unsuccessful (dummy for now)
            {
                mw.loggedIn = false;

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
                mw.currentAcount = usernameField.Text;
                this.Close();
            }
                
        }


        private void errorMessage1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Incorrect password, log In Unsuccesful!", "My App", MessageBoxButton.OK);
        }

        private void errorMessage2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User does not exist, log In Unsuccesful!", "My App", MessageBoxButton.OK);
        }
        private void errorMessage3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have not entered a username, log In Unsuccesful!", "My App", MessageBoxButton.OK);
        }

        private void errorMessage4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have not entered a password, log In Unsuccesful!", "My App", MessageBoxButton.OK);
        }


    }
}
