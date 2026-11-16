using GUIYael.ServiceReference1;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUIYael
{
    /// <summary>
    /// Interaction logic for PAllOrder.xaml
    /// </summary>
    public partial class PAllOrder : Page
    {
        List<OrderDTO> orders =new List<OrderDTO>();
       
      
        public PAllOrder()
        {
            InitializeComponent();
            foreach (OrderDTO order in Global.server.GetOrderList().ToList())
            {
                if (order.OrderHall.EventDate >= DateTime.Today)
                { orders.Add(order); }
            }
            this.lstOrders.ItemsSource = this.orders;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           OrderDTO order =((OrderDTO)((Button)sender).DataContext);

            this.NavigationService.Navigate(new PMealOfOrder(order.IdOrder));
        }

        private void lstOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btnSortByDate_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < orders.Count - 1; i++)
            {
                for (int j = 0; j < orders.Count - i - 1; j++)
                {
                  
                    if (orders[j].OrderHall.EventDate > orders[j + 1].OrderHall.EventDate)
                    {
                     
                        OrderDTO temp = orders[j];
                        orders[j] = orders[j + 1];
                        orders[j + 1] = temp;
                    }
                
                    else if (orders[j].OrderHall.EventDate == orders[j + 1].OrderHall.EventDate &&
                             orders[j].TimeOrder > orders[j + 1].TimeOrder)
                    {
                        OrderDTO temp = orders[j];
                        orders[j] = orders[j + 1];
                        orders[j + 1] = temp;
                    }
                }
            }

            this.lstOrders.ItemsSource = null;
            this.lstOrders.ItemsSource = this.orders;
        }
    
    }
}




//foreach (OrderDTO order in orders)
//{ foreach (OrderDTO order1 in orders) }



