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
    /// Interaction logic for UCHall.xaml
    /// </summary>
    public partial class UCHall : UserControl
    {bool say = false;
        HallDTO hallDTO1 = new HallDTO();
        public UCHall(HallDTO hallDTO)
        {
            InitializeComponent();
            this.hallDTO1 = hallDTO;
            this.DataContext = hallDTO1;

            HallImg.Source = Picture.GetImage(hallDTO1.Image);
        }

        public UCHall(HallDTO hallDTO ,int a)
        {
            InitializeComponent();
            this.hallDTO1 = hallDTO;
            say = true;
            this.DataContext = hallDTO1;

            HallImg.Source = Picture.GetImage(hallDTO1.Image);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { if (say == true)
            {
                HallDTO selectedHall = this.DataContext as HallDTO;

                NavigationService myFrame = NavigationService.GetNavigationService(this);
                myFrame.Navigate(new PAvelibele(selectedHall ,1));
            }
            else
            {
                HallDTO selectedHall = this.DataContext as HallDTO;

                NavigationService myFrame = NavigationService.GetNavigationService(this);
                myFrame.Navigate(new PAvelibele(selectedHall));
            }
        }
    }
}
       