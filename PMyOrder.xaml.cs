using GUIYael;
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
    /// Interaction logic for PMyOrder.xaml
    /// </summary>
    public partial class PMyOrder : Page
    {
        List<OrderHallDTO> listOrderHall = new List<OrderHallDTO>();

        public PMyOrder(int id)
        {
            InitializeComponent();
            foreach (OrderHallDTO orderHall in Global.server.GetAllOrderHall())
            {
                if (orderHall.IdUser == id && orderHall.EventDate >= DateTime.Today)
                { listOrderHall.Add(orderHall); }
            }

            this.DataContext = listOrderHall;
         
        }


        private void ifHas_Loaded(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            OrderHallDTO orderHall = btn.DataContext as OrderHallDTO;
            if (orderHall == null) return;

           
            if (orderHall.Complate == 2)
            {
                btn.Content = "👁️ לצפייה בפרטי התפריט";
            }
            else
            {
                btn.Content = "🛒 להשלמת הקנייה (בחירת תפריט)";
               
            }
        }

      
        private void ifHas_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            OrderHallDTO orderHall = clickedButton.DataContext as OrderHallDTO;
            if (orderHall == null) return;

         
            if (orderHall.Complate == 2)
            {
                bool foundMealOrder = false;

                foreach (OrderDTO order in Global.server.GetOrderList())
                {
                    if (order.IdOrderHall == orderHall.IdOrderHall)
                    {
                    
                        this.NavigationService.Navigate(new PMealOfOrder(order.IdOrder));
                        foundMealOrder = true;
                        break;
                    }
                }

                             if (!foundMealOrder)
                           {
                              MessageBox.Show("לא נמצא פירוט מנות משויך להזמנה זו במערכת.");
                           }
            }
           
            else
            {
                this.NavigationService.Navigate(new PageCategory());
            }
        }
    }
}