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
using GUIYael.ServiceReference1;
namespace GUIYael
{
    /// <summary>
    /// Interaction logic for PCity.xaml
    /// </summary>
    public partial class PCity : Page
    {
        CityDTO city1 = new CityDTO();
        public PCity()
        {
            InitializeComponent();
            this .DataContext = city1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (city1.NameCity == null || city1.NameCity== "")
            {
                MessageBox.Show("הקש שם עיר");
                return;
            }
            MessageBox.Show(Global.server.AddCity(city1).ToString()) ;
        }
    }
}
