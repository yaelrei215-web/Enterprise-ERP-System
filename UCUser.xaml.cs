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
    /// Interaction logic for UCUser.xaml
    /// </summary>
    public partial class UCUser : UserControl
    { UserDTO UserDTO1 = new UserDTO();
        public UCUser(UserDTO User1)
        {
            InitializeComponent();
            this.UserDTO1 = User1;
           
            this.DataContext = UserDTO1;
            
            MyIMG.Source = Picture.GetImage(UserDTO1.UserImag);
        }
    }
}
