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
    /// <summary>S
    /// Interaction logic for PAllMealWithUC.xaml
    /// </summary>
    public partial class PAllMealWithUC : Page
    {

        public PAllMealWithUC()
        {
            InitializeComponent();


            List<MealDTO> meals = Global.server.GetMealList().ToList();
            foreach (MealDTO meal1 in meals)
            {
                UCMeal UC = new UCMeal(meal1);
                WRPMeal.Children.Add(UC);
            }
        }
        public PAllMealWithUC(int id)


        {
            InitializeComponent();


            List<MealDTO> meals = Global.server.GetMealList().ToList();


            foreach (MealDTO meal1 in meals)
            {
               if (meal1.Category.IdCategory == id)
                {

                    UCMeal UC = new UCMeal(meal1);
                    WRPMeal.Children.Add(UC);
                }
               

            }

        }
    }
}