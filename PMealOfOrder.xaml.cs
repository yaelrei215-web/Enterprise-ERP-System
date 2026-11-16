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
    /// Interaction logic for PMealOfOrder.xaml
    /// </summary>
    public partial class PMealOfOrder : Page
    {
        public PMealOfOrder()
        {
            InitializeComponent();
        }

        public PMealOfOrder(int id)
        {
            InitializeComponent();
            this.lstMeals.ItemsSource = Global.server.GetAllDataOrder(id);
        }
    }

}

