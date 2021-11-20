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
        private bool success = false;
        private MainWindow mw;
        public signupWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {

            //Check if confirmed password and passwords arent the same then don't log in
            if (!passwordField.Password.Equals(confirmPasswordField.Password) && !confirmPasswordField.Password.Equals(passwordField.Password))
            {
                success = false;
                errorMessage1_Click(sender, e);
            }

            //Check if there is already a username in the database and if the username is blank
            if (mw.AccountDatabase.ContainsKey(usernameField.Text) && !usernameField.Text.Equals(""))
            {
                success = false;
                errorMessage2_Click(sender, e);
            }

            //Add username and password into account database if username/password are not blank, username does not exist in database and if the confirmed password equals password
       else if (!mw.AccountDatabase.ContainsKey(usernameField.Text) && !usernameField.Text.Equals("") && !passwordField.Password.Equals("") && passwordField.Password.Equals(confirmPasswordField.Password)) {
                Account newAccount = new Account(usernameField.Text, passwordField.Password);
                mw.AccountDatabase[usernameField.Text] = newAccount;
                mw.currentAcount = usernameField.Text;
                success = true;
            }
            //If username and password already exist then don't log in
            else {
                success = false;
                if (passwordField.Password.Equals(""))
                {
                    errorMessage4_Click(sender, e);
                }
                else
                {
                    if (usernameField.Text.Equals(""))
                    {
                        errorMessage3_Click(sender, e);
                    }
                    
                }

            }

            if (!passwordField.Password.Equals(confirmPasswordField.Password) && !confirmPasswordField.Password.Equals(passwordField.Password))
            {
                success = false;
            }




            if (success == false)//if sign up unsuccessful (dummy for now)
            {
                mw.loggedIn = false;


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
                mw.currentAcount = usernameField.Text;
                this.Close();
            }
        }

        private void errorMessage1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wrong confirmed password, signup Unsuccesful!", "My App", MessageBoxButton.OK);
        }

        private void errorMessage2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User already exists, signup Unsuccesful!", "My App", MessageBoxButton.OK);
        }

        private void errorMessage3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have not entered a username, signup Unsuccesful!", "My App", MessageBoxButton.OK);
        }

        private void errorMessage4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have not entered a password or confirmed password, signup Unsuccesful!", "My App", MessageBoxButton.OK);
        }

    }
}
