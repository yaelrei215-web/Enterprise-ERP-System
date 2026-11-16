using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUIYael.ServiceReference1;

namespace GUIYael
{
    internal class Global
    {
        public static Service1Client server = new Service1Client();
        public static UserDTO currentUser = null;
        public static List<MealInBusket> lstMealInBusket = new List<MealInBusket>();
        public static int priceHall = 0;
        public static OrderHallDTO currentOrderHall = null;





        public static void RefreshAllData()
        {

            server = new Service1Client();
            RefreshGlobal();

        }

        public static void RefreshGlobal()
        {
           
            lstMealInBusket.Clear();
            currentOrderHall = null;
            priceHall = 0;


        }


    }
}
