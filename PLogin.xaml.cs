using GUIYael.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace GUIYael
{
    /// <summary>
    /// Interaction logic for PLogin.xaml
    /// </summary>
    public partial class PLogin : Page
    {
        MenuItem MIinOut;
        public PLogin()
        {
            InitializeComponent();
        }
        public PLogin( MenuItem MI)
        {
            InitializeComponent();
            MIinOut=MI;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserDTO myUser = Global.server.GetUserByTzAndPassword(txtTZ.Text,txtPass.Password);
            if (myUser != null)
            {
           
                    MessageBox.Show(" שלום ל"  + myUser.FirstName +" "+ myUser.LastName);
                Global.currentUser = myUser;
               MIinOut.Header = "התנתקות";

                //NavigationService myFrame = NavigationService.GetNavigationService(this);

                //myFrame.Navigate(new MainWindow());




                MainWindow.CurrentPage.RefreshMenu();
                NavigationService nav = NavigationService.GetNavigationService(this);
                   //nav.Navigate(null);
                   nav.Navigate(new PageCategory());

                //if (NavigationService.CanGoBack)
                //    NavigationService.GoBack();
                //else
                //{
                //    NavigationService nav = NavigationService.GetNavigationService(this);
                //    //nav.Navigate(null);
                //    nav.Navigate(new MainWindow());
                //}

            }
            else MessageBox.Show(" אחד מהנתונים שהקשת שגוי");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new PUser());

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new PageCategory());
        }
    }
}
