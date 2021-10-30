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
    /// Interaction logic for customEventInputWindow.xaml
    /// </summary>
    public partial class customEventInputWindow : Window
    {
        private MainWindow mw;
        public customEventInputWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            //Create event in mainWindow somehow
            this.Close();
        }
    }
}
