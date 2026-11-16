using GUIYael.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for shoppingBasket.xaml
    /// </summary>
    



    public partial class shoppingBasket : Page
    {


        int sum = 0;
        int sumMeal1 = 0;

        public shoppingBasket()
        {
            InitializeComponent();

            foreach (MealInBusket meal in Global.lstMealInBusket)
            {
                UCMeal UC = new UCMeal(meal);

                stpMeals.Children.Add(UC);
                sum += (((int)meal.Amount) * (int)meal.Meal.CountMeal);
                sumMeal1 += (meal.Amount);
            }
            sumPrice.Text = sum.ToString();
            sumMeal.Text = sumMeal1.ToString();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool say = false;
            List<DateTime> dates = new List<DateTime>();

            foreach (OrderHallDTO orderHall1 in Global.server.GetAllOrderHall())

            {
                if (orderHall1.IdUser == Global.currentUser.Id)
                {
                    if (orderHall1.Complate != 2 && orderHall1.EventDate >= DateTime.Today)
                    {
                        dates.Add(orderHall1.EventDate.Value);
                        say = true;
                    }
                }
            }
            if (say == true)
            {

                NavigationService myFrame = NavigationService.GetNavigationService(this);

                myFrame.Navigate(new POrder(Convert.ToInt32(sumMeal.Text), Convert.ToInt32(sumPrice.Text), dates));
            }
            if (say == false)
            {
                MessageBox.Show("לא בחרת אולם עליך לבחור אולם קודם הוספת מוצרים ");
                NavigationService myFrame = NavigationService.GetNavigationService(this);

                myFrame.Navigate(new PAllHallWithUC(1));

            }

        }
    }
}
