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
    /// Interaction logic for AddHall.xaml
    /// </summary>
    public partial class AddHall : Page
    {
        HallDTO hall1 = new HallDTO();

        public AddHall()
        {
            InitializeComponent();

        
            this.DataContext = hall1;

        
            cmbCities.ItemsSource = Global.server.GetCityList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (hall1.Name==null||hall1.Amount==null||hall1.city==null||hall1.Street==null||hall1.CellPhone==null||hall1.Price==null||hall1.HouseNumber==null)
            {
                MessageBox.Show("עליך למלא את כל הפרטים!");
                return;
            }
            this.hall1.IdCity = hall1.city.IdCity;
            Global.server.AddHall(hall1);
            MessageBox.Show("האולם נשמר בהצלחה!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string namePicture = Picture.UploadImage_Dlg();
            hall1.Image= namePicture;
            MyIMG.Source = Picture.GetImage(namePicture);
        }
    }
}
