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
    /// Interaction logic for PMeal.xaml
    /// </summary>
    public partial class PMeal : Page
    {
        MealDTO MealDTO1 = new MealDTO();
        public PMeal()
        {
            InitializeComponent();

            this.DataContext = this.MealDTO1;
         
            cmbCategory.ItemsSource = Global.server.GetCategoryList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MealDTO1.NameMeal == null || MealDTO1.Image == null || MealDTO1.Described == null || MealDTO1.CountMeal == null || MealDTO1.Category == null)
            { MessageBox.Show("עליך למלא את כל הפרטים");
            return;
        }
        MealDTO1.IdCategory=MealDTO1.Category.IdCategory;
            MessageBox.Show(Global.server.AddMeal(MealDTO1).ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string namePicture = Picture.UploadImage_Dlg();
            MealDTO1.Image = namePicture;
            MyIMG.Source = Picture.GetImage(namePicture);
        }
    }
}
