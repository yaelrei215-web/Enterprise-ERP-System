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
    /// Interaction logic for PUser.xaml
    /// </summary>
    public partial class PUser : Page
    { UserDTO userDTO1 = new UserDTO();
        string statusPage = "";
        
        
        
        
        
        public PUser()
        {
            InitializeComponent();
            this.DataContext = this.userDTO1;
            this.statusPage = "ADD";
            DateTime eighteenYearsAgo = DateTime.Today.AddYears(-18);


            myCalendar.DisplayDateEnd = eighteenYearsAgo;


            myCalendar.DisplayDate = eighteenYearsAgo;

            cmbCities.ItemsSource = Global.server.GetCityList();
            if (Global.currentUser == null || Global.currentUser.UserType == "2")

            {
                ItemOfMeneger.Visibility = Visibility.Collapsed;
                ItemOfMeneger1.Visibility = Visibility.Collapsed;
            }
            else

                if (Global.currentUser.UserType == "1")

                {
                    ItemOfMeneger.Visibility = Visibility.Visible;
                    ItemOfMeneger1.Visibility = Visibility.Visible;
                }


        }
        public PUser(UserDTO user1)
        {
            InitializeComponent();
            this.userDTO1 = user1;
            DateTime eighteenYearsAgo = DateTime.Today.AddYears(-18);


            myCalendar.DisplayDateEnd = eighteenYearsAgo;


            myCalendar.DisplayDate = eighteenYearsAgo;

            cmbCities.ItemsSource = Global.server.GetCityList();
            cmbCities.SelectedIndex = userDTO1.IdCity - 1;
            ItemOfMeneger1.SelectedValue = userDTO1.UserType;
            if (Global.currentUser == null || Global.currentUser.UserType == "2")

            {
                ItemOfMeneger.Visibility = Visibility.Collapsed;
                ItemOfMeneger1.Visibility = Visibility.Collapsed;
            }
            else

                if (Global.currentUser.UserType == "1")

                {
                    ItemOfMeneger.Visibility = Visibility.Visible;
                    ItemOfMeneger1.Visibility = Visibility.Visible;
                }
            this.DataContext = this.userDTO1;
            this.statusPage = "UPDATE";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userDTO1.FirstName) ||
      string.IsNullOrWhiteSpace(userDTO1.LastName) ||
      userDTO1.Birthday == null ||
      string.IsNullOrWhiteSpace(userDTO1.CellPhone) ||
      string.IsNullOrWhiteSpace(userDTO1.Street) ||
 
      userDTO1.NumOfHouse == null || userDTO1.NumOfHouse == 0 ||
      string.IsNullOrWhiteSpace(userDTO1.PassWord) ||
      userDTO1.city == null)
            
                //if (userDTO1.FirstName==null||userDTO1.LastName==null||userDTO1.Birthday==null||userDTO1.CellPhone==null||userDTO1.Street==null||userDTO1.NumOfHouse==null||userDTO1.PassWord==null||userDTO1.city==null)
                {
                MessageBox.Show("עליך למלא את כל הפרטים!");
                return;
            }
            this.userDTO1.IdCity = userDTO1.city.IdCity;
                this.userDTO1.IsDeleted = false;
                if (this.userDTO1.UserType == null)
                    this.userDTO1.UserType = "2";
                if (statusPage == "ADD")
                {
                    if (Validation.GetHasError(tz))
                    {
                        MessageBox.Show(" תעודת הזהות אינה תקינה!");
                        return;
                    }

                    int kod = Global.server.AddUser(this.userDTO1);
                    MessageBox.Show("נוספת/ה למערכת!"); ;
                }
                else if (statusPage == "UPDATE")
                {
                    if (Validation.GetHasError(tz))
                    {
                        MessageBox.Show("לא ניתן להמשיך. תעודת הזהות אינה תקינה!");
                        return;
                    }
                    if (Global.server.UpdateUser(this.userDTO1) == true)
                        MessageBox.Show("עודכן בהצלחה");
                    else MessageBox.Show("העדכון נכשל");
                }
            }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string namePicture = Picture.UploadImage_Dlg();
            userDTO1.UserImag=namePicture;
            MyIMG.Source=Picture.GetImage(namePicture);
        }
    }
}
