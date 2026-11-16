using GUIYael.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
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
    /// Interaction logic for UCMeal.xaml
    /// </summary>
    public partial class UCMeal : UserControl


    {
        

        MealDTO mealDTO1 = new MealDTO();

       
        public UCMeal(MealDTO meal1)
        {
            InitializeComponent();
            txtAmout.Text = "1";
            this.mealDTO1 = meal1;

            this.DataContext = mealDTO1;


            btnAdd.Visibility = Visibility.Visible;
            txtAmout.Visibility = Visibility.Visible;
            txtAmout2.Visibility = Visibility.Collapsed;
            MyIMG.Source = Picture.GetImage(mealDTO1.Image);
  }

        MealInBusket  MealInBusket1 = new MealInBusket(); 


        public UCMeal(MealInBusket meal1)
        {
            InitializeComponent();
      
            this.DataContext = meal1.Meal;
            this.txtAmout2.Text = meal1.Amount.ToString();
            btnAdd.Visibility = Visibility.Collapsed;
            txtAmout.Visibility = Visibility.Collapsed;
            txtAmout2.Visibility = Visibility.Visible;
            MyIMG.Source = Picture.GetImage(meal1.Meal.Image);


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        { if (Global.currentUser == null)
            { MessageBox.Show("אינך יכול להוסיף מוצרים לסל כל עוד אינך מחובר !"); }
           else{ 

                MealInBusket mealInBusket = new MealInBusket();
                mealInBusket.Meal = mealDTO1;

                if (Convert.ToInt32(txtAmout.Text) > 0)
                {
                    mealInBusket.Amount = Convert.ToInt32(txtAmout.Text);

                    Global.lstMealInBusket.Add(mealInBusket);
                    txtBAdded.Visibility = Visibility.Visible;
                }
                else { MessageBox.Show("בחר כמות מהמוצר!"); }
            } 
        }
    }
}



