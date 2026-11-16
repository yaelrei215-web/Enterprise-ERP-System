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
    /// Interaction logic for PAllUserWithUC.xaml
    /// </summary>
    public partial class PAllUserWithUC : Page
    {
        public PAllUserWithUC()
        {
            InitializeComponent();
            List<UserDTO>  users = Global.server.GetUserList().ToList();
            foreach (UserDTO user1 in users) 
              {
                UCUser UC = new UCUser(user1);
                WRPUsers.Children.Add(UC);
              }
        }
    }
}
