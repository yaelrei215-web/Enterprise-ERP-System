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
    /// Interaction logic for PageCategory.xaml
    /// </summary>
    public partial class PageCategory : Page
    {
        CategoryDTO CategoryDTO1 = new CategoryDTO();
        public PageCategory()
        {


            InitializeComponent();
            cmbCategory.ItemsSource = Global.server.GetCategoryList();
            this.DataContext = CategoryDTO1;




        }


        private void Button_Click_1(object sender, RoutedEventArgs e)


        {
            NavigationService myFrame = NavigationService.GetNavigationService(this);
            CategoryDTO categoryDTO = cmbCategory.SelectedItem as CategoryDTO;
            if (categoryDTO != null)
            {
                myFrame.Navigate(new PAllMealWithUC(categoryDTO.IdCategory));

            }
            else
            {
                myFrame.Navigate(new PAllMealWithUC());
            }



        }
    }
}
 