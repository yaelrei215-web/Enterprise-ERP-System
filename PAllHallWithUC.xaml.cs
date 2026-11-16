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
    /// Interaction logic for PAllHallWithUC.xaml
    /// </summary>
    public partial class PAllHallWithUC : Page
    {
        public PAllHallWithUC()
        {
            InitializeComponent();
            List<HallDTO> halls =Global.server.GetAllHall();

           
            foreach (HallDTO hall1 in halls)
            {
                UCHall UC = new UCHall(hall1);
                WRPHall.Children.Add(UC);


            }
        }
        public PAllHallWithUC(int a)
        {
            InitializeComponent();
            List<HallDTO> halls = Global.server.GetAllHall();


            foreach (HallDTO hall1 in halls)
            {
                UCHall UC = new UCHall(hall1 ,a);
                WRPHall.Children.Add(UC);


            }
        }
        }
}
