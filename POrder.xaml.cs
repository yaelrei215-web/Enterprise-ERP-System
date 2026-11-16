using GUIYael.ServiceReference1;

using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for POrder.xaml
    /// </summary>
    public partial class POrder : Page
    { OrderDTO orderDTO1 = new OrderDTO();
       List< DataOrderDTO> listDataOrder = new List< DataOrderDTO>();
       OrderHallDTO orderHall = new OrderHallDTO();

        public POrder(int nMeal , int sum ,List<DateTime> dates)
        {
           
            InitializeComponent();
            numMeal.Text = nMeal.ToString();
            price.Text = sum.ToString();
            cmbDates.ItemsSource = dates;

           this.DataContext = this.orderDTO1;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrderDTO order = orderDTO1;
            if (Global.server.GetUserByTzAndPassword(tz.Text, password.Text) != null)
         { 

                orderDTO1.IdUser = Global.server.GetUserByTzAndPassword(tz.Text, password.Text).Id;


                if (Validation.GetHasError(expdate))
                {
                    MessageBox.Show(" מספר הכרטיס אינו תקין או תקף!");
                    return;
                }
                //if (orderDTO1.ExperationDate != null)
                //{
                //    string expDate = Convert.ToString(orderDTO1.ExperationDate);
                //    orderDTO1.ExperationDate = expDate;
                //}
                TimeSpan selectedTime;
                if (TimeSpan.TryParse(txtReadyTime.Text, out selectedTime))
                {
                    orderDTO1.TimeOrder = selectedTime;
                }
                else
                {
                 
                    MessageBox.Show("נא להזין שעה תקינה בפורמט HH:MM");
                    return;

                }

              
                //if (txtExpiry.Text.Length == 5 && txtExpiry.Text.Contains("/"))
                //{
                //    orderDTO1.ExperationDate = 
                //        txtExpiry.Text;
             
                //}
                //else
                //{
                //    MessageBox.Show("נא להזין תאריך בפורמט חודש/שנה (למשל: 12/26)");
                //    return;
                //}
                if (numberCard.Text.Length != 0)
                {
                    orderDTO1.NumCard = numberCard.Text;

                }
                else
                {
                    MessageBox.Show("נא להזין מספר כרטיס)");
                    return;
                }
               
                orderDTO1.SumPrice = Convert.ToInt32(price.Text);
                orderDTO1.NumOfMeal = Convert.ToInt32(numMeal.Text);
     
                if (orderDTO1.OrderHall == null)
                {
                    orderDTO1.OrderHall = new OrderHallDTO();
                }

                // עכשיו בטוח להמשיך
                orderDTO1.OrderHall.Complate = 2;


                string input = expdate.Text;
                int month = 0;
                int year = 0;

                if (!string.IsNullOrWhiteSpace(input) && input.Length == 5)
                {
                    int.TryParse(input.Substring(0, 2), out month);
                    int.TryParse(input.Substring(3, 2), out year);
                }

                if (string.IsNullOrWhiteSpace(input) || input.Length != 5 || input[2] != '/' || month < 1 || month > 12 || year < 26 || (year == 26 && month < DateTime.Today.Month))
                {
                    expdate.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD2D2"));
                    expdate.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4D4D"));

                    MessageBox.Show("תוקף הכרטיס אינו תקין או שפג תוקפו!");
                    return;
                }
                if (cvv.Text.Length != 3 && !int.TryParse(cvv.Text, out int checkedCvv))

                {
                    MessageBox.Show(" הקש את שלושת הספרות בגב הכטיס בצורה נכונה");
                    return;

                }

                expdate.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FAFAFA"));
                expdate.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));

                //MessageBox.Show("ההזמנה בוצעה בהצלחה!");
           


            foreach (OrderHallDTO orderHall1 in Global.server.GetAllOrderHall())

                {
                    if (orderHall1.IdUser == Global.currentUser.Id)
                    {
                        if (cmbDates.SelectedItem==null) {
                            MessageBox.Show("בחר אחד מהאירועים!");
                            return; }

                          else  if (orderHall1.EventDate == (DateTime)cmbDates.SelectedItem)
                        {
                           
                            if (orderHall1.Complate != 2)
                            {
                                orderHall1.Complate = 2;
                                Global.server.UpdateOrderHalll(orderHall1);

                            }
                        }
                    }
                }
                    int v = Global.server.AddOrder(orderDTO1);
                    //int s = Global.server.AddOrderHall(orderDTO1.OrderHall);

                    foreach (MealInBusket mealInBusket1 in Global.lstMealInBusket)
                {
                    DataOrderDTO dataOrder1 = new DataOrderDTO();
                    dataOrder1.IdOrder = v;
                    dataOrder1.IdMeal = mealInBusket1.Meal.IdMeal;
                    dataOrder1.Count = mealInBusket1.Amount;

                    listDataOrder.Add(dataOrder1);
                }
               
                Global.server.AddDataOrder(listDataOrder);

                MessageBox.Show("ההזמנה נשלחה למערכת");
                Order.Visibility = Visibility.Collapsed;
                seeOrder.Visibility = Visibility.Visible;
                //NavigationService myFrame = NavigationService.GetNavigationService(this);
                //     myFrame.Navigate(new PDataOrder(orderDTO1));
                Global.RefreshAllData();
                NavigationService myFrame = NavigationService.GetNavigationService(this);
                myFrame.Navigate(new PDataOrder(orderDTO1,v));

            }

            else { MessageBox.Show(" תעודת זהות או סיסמה שגויים או שאינך קיים במערכת"); return; }

            }

        private void seeOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbDates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)cmbDates.SelectedItem;
            foreach (OrderHallDTO orderHall1 in Global.server.GetAllOrderHall())
            {
                if (orderHall1.EventDate == selectedDate)
                { orderDTO1.IdOrderHall = orderHall1.IdOrderHall;
                    city.Text = orderHall1.Hall.city.NameCity;
                    name.Text= orderHall1.Hall.Name;
                        street.Text=orderHall1.Hall.Street;
                        number.Text=orderHall1.Hall.HouseNumber;
                }

            }
            
        }
    } 
    }

