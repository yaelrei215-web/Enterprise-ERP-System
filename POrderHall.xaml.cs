using GUIYael.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace GUIYael
{
    /// <summary>
    /// Interaction logic for POrderHall.xaml
    /// </summary>
    public partial class POrderHall : Page
    {
        bool say = false;
        private HallDTO hall;
        private DateTime date;

        public POrderHall(DateTime date1, HallDTO hall1)
        {
            InitializeComponent();



            this.hall = hall1;
            this.date = date1;

            txtHallName.Text = hall.Name;
            txtCity.Text = hall.city.NameCity;
            txtAddress.Text = $"{hall.Street} {hall.HouseNumber}";
            txtEventDate.Text = date.ToShortDateString();
            txtprice.Text = hall.Price.ToString();
        }
        public POrderHall(DateTime date1, HallDTO hall1, int a)
        {
            InitializeComponent();


            say = true;
            this.hall = hall1;
            this.date = date1;


            txtHallName.Text = hall.Name;
            txtCity.Text = hall.city.NameCity;
            txtAddress.Text = $"{hall.Street} {hall.HouseNumber}";
            txtEventDate.Text = date.ToShortDateString();
            txtprice.Text = hall.Price.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrderHallDTO orderHall = new OrderHallDTO();
            orderHall.Hall = hall;
           
            this.DataContext = orderHall;
            if (Global.server.GetUserByTzAndPassword(tz.Text, password.Text) != null)
            {

                orderHall.USER = Global.server.GetUserByTzAndPassword(tz.Text, password.Text);
                orderHall.IdUser = orderHall.USER.Id;
                orderHall.IdHall = hall.IdHall;
                orderHall.EventDate = date;






                if (numCard.Text.Length != 0)
                { orderHall.NumCard = numCard.Text; }
                else
                {
                    MessageBox.Show("נא להזין מספר כרטיס)");
                    return;
                }




                string input = expdate.Text;

             

              
                if (string.IsNullOrWhiteSpace(input) ||   input.Length != 5 ||  input[2] != '/' || !int.TryParse(input.Substring(0, 2), out int month) ||

                    !int.TryParse(input.Substring(3, 2), out int year) ||
                    month < 1 || month > 12 ||

                    year < 26 ||

              
                    (year == 26 && month < DateTime.Today.Month))
                {
                  
                    expdate.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD2D2"));
                    expdate.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4D4D"));

               
                    MessageBox.Show("תוקף הכרטיס אינו תקין או שפג תוקפו!");

                    return; 
                }
                else { orderHall.ExperationDate= expdate.Text.Trim(); }



                Global.currentOrderHall = orderHall;
                Global.currentOrderHall.Hall = orderHall.Hall;
                if (cvv.Text.Length != 3 || !int.TryParse(cvv.Text, out int checkedCvv))
                {
                    MessageBox.Show("הקש את שלושת הספרות בגב הכרטיס בצורה נכונה");
                    return;
                }
                else
                {
                    // ה-checkedCvv כבר מכיל את המספר המומר והבטוח!
                    orderHall.Cvv = checkedCvv;
                }
                int id = Global.server.AddOrderHall(orderHall);
                orderHall.IdOrderHall = id;
                if (say == true)
                {
                    MessageBox.Show(" ההזמנה התקבלה");
                    NavigationService myFrame = NavigationService.GetNavigationService(this);
                    myFrame.Navigate(new shoppingBasket());
                }
                else
                {

                    MessageBox.Show(" ההזמנה התקבלה");
                    NavigationService myFrame = NavigationService.GetNavigationService(this);
                    myFrame.Navigate(new PFinishOrderHall(orderHall));
                }
            }







            else { MessageBox.Show(" תעודת זהות או סיסמה שגויים או שאינך קיים במערכת"); return; }
        }

    
    }
}

