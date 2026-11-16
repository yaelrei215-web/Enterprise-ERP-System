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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUIYael
{
    /// <summary>
    /// Interaction logic for PDataOrder.xaml
    /// </summary>
    public partial class PDataOrder : Page
    {
    
        List<DataOrderDTO> allMeals;
        OrderDTO order;

        public PDataOrder(OrderDTO orderDTO2,int id)
        {
            InitializeComponent();

          
            this.lstMeals.ItemsSource = Global.server.GetAllDataOrder(id);
            
            this.id.Text = id.ToString();

            List<UserDTO> allUsers = Global.server.GetAllUser().ToList();
            UserDTO user = null;
            foreach (UserDTO user1 in allUsers)
            {
               
                if (user1.Id == orderDTO2.IdUser)
                {
                    user = user1;
                    break; 
                }
            }



            this.User.Text = user.FirstName + " " + user.LastName;

           this.CityName.Text =user.city.NameCity;

            this.sumPrice.Text = orderDTO2.SumPrice.ToString() + " ₪";
        } }
    }
