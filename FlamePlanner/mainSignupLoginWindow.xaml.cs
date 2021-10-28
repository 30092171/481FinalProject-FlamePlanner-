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
    /// Interaction logic for mainSignupLoginWindow.xaml
    /// </summary>
    public partial class mainSignupLoginWindow : Window
    {
        private MainWindow mw;
        public mainSignupLoginWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            this.MaxWidth = mw.Width;
        }

        private void logInButton_Click(object sender, RoutedEventArgs e)
        {
            Login lw = new Login(mw);
            this.Close();
            lw.ShowDialog();
            
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            signupWindow sw = new signupWindow(mw);
            this.Close();
            sw.ShowDialog();
        }
    }
}
