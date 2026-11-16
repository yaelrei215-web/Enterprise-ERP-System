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
    /// Interaction logic for PCategory.xaml
    /// </summary>
    public partial class PCategory : Page
    {
        CategoryDTO CategoryDTO1 = new CategoryDTO();
        public PCategory()
        {
            InitializeComponent();
            this.DataContext = this.CategoryDTO1;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryDTO1.NameCategory==null|| CategoryDTO1.NameCategory == "")
            {
                MessageBox.Show("הקש שם קטגוריה");
                return;
            }
            MessageBox.Show(Global.server.AddCategory(CategoryDTO1).ToString());
   
        }
    }
}
