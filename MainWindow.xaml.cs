using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using GUIYael.ServiceReference1;

namespace GUIYael
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public static MainWindow CurrentPage;
        CategoryDTO CategoryDTO1 = new CategoryDTO();

        public MainWindow()
        {
            InitializeComponent();

            CurrentPage = this;
            RefreshMenu();

            if (Global.currentUser == null)
            {
                Global.RefreshGlobal();
                MIInOut.Header = "התחברות";
                myOrder.Visibility = Visibility.Collapsed;
                MIUpdate.Visibility = Visibility.Collapsed;
                ItemOfMeneger.Visibility = Visibility.Collapsed;
            }
       
            if (Global.currentUser != null)
            {myOrder.Visibility = Visibility.Visible;
                MIInOut.Header = "התנתקות";
                MIUpdate.Visibility = Visibility.Visible;

            
                MessageBox.Show("הערך הוא: '" + Global.currentUser.UserType + "'");
                if (Global.currentUser.UserType?.ToString()?.Trim() == "1")
                {
                    ItemOfMeneger.Visibility = Visibility.Visible;
                }
                else
                {
                    ItemOfMeneger.Visibility = Visibility.Collapsed;
                }
            }



            if (Global.currentUser == null)
                {
                Global.RefreshGlobal();
                MIInOut.Header = "התחברות";
                //myOrder.Visibility= Visibility.Collapsed;
            }
                else
                { MIInOut.Header = "התנתקות";
                myOrder.Visibility = Visibility.Visible;
            }
            }












        public void RefreshMenu()
        {
            if (Global.currentUser == null)
            {
                Global.RefreshGlobal();
                MIInOut.Header = "התחברות";
                MIUpdate.Visibility = Visibility.Collapsed;
                ItemOfMeneger.Visibility = Visibility.Collapsed;
            }
            else
            {
                MIInOut.Header = "התנתקות";
                myOrder.Visibility= Visibility.Visible;
                MIUpdate.Visibility = Visibility.Visible;

                if (Global.currentUser.UserType.ToString() == "1")
                {
                    ItemOfMeneger.Visibility = Visibility.Visible;

                }
                else
                    ItemOfMeneger.Visibility = Visibility.Collapsed;
            }
        }

        public MainWindow(UserDTO userDTO1)
        {
            InitializeComponent();
    

            if (Global.currentUser == null)
            {
                Global.RefreshGlobal();
                MIInOut.Header = "התחברות"; }
            else
            { MIInOut.Header = "התנתקות";
                myOrder.Visibility = Visibility.Visible;
            }
        }
        

     





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Service1Client server = new Service1Client();
            CityDTO city1 = new CityDTO();
            city1.NameCity = "צפת";
          MessageBox.Show (server.AddCity (city1).ToString());
 
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new PCity());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new PCities());
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new PUser());
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new PLogin()); 
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new PAllUserWithUC());
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate( new PUser(  Global.currentUser));
        }


        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new PMeal());
        }



        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new PCategory());
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {

            myFrame.Navigate(new shoppingBasket());
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new PageCategory());
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new PAllOrder());
        }

        private void MIInOut_Click(object sender, RoutedEventArgs e)
        {
            if( Global .currentUser !=null ) 
            {
                Global.lstMealInBusket.Clear();
                Global.RefreshGlobal();
                Global.currentUser = null;
                ItemOfMeneger.Visibility = Visibility.Collapsed;
                MIInOut.Header = "התחברות";
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new MainWindow());
            }
            else
            {
                myFrame .Navigate (new PLogin (MIInOut ));
            }
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new PAllHallWithUC());
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new AddHall());
        }

        private void myOrder_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new PMyOrder(Global.currentUser.Id));
        }
    }
}


 