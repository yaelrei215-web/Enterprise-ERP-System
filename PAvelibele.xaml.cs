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
    /// Interaction logic for PAvelibele.xaml
    /// </summary>
    public partial class PAvelibele : Page
    {
        HallDTO hallDTO1 = new HallDTO();
        bool say = false;
        public PAvelibele(HallDTO hallDTO)
        {
            InitializeComponent();
            this.hallDTO1 = hallDTO;


            HallCalendar.DisplayDateStart = DateTime.Today.AddDays(1);
            List<OrderHallDTO> allOrderHalls = Global.server.GetAllOrderHall();

            foreach (OrderHallDTO order in allOrderHalls)
            {
                if (order.IdHall == hallDTO.IdHall && order.EventDate != null)
                {
                    // נוסיף את התאריך לרשימת התאריכים החסומים בלוח השנה
                    DateTime dateToBlock = (DateTime)order.EventDate;
                    HallCalendar.BlackoutDates.Add(new CalendarDateRange(dateToBlock));
                }
            }
        }
        public PAvelibele(HallDTO hallDTO, int a)
        {
            InitializeComponent();
            this.hallDTO1 = hallDTO;
            say = true;

            HallCalendar.DisplayDateStart = DateTime.Today;
            List<OrderHallDTO> allOrderHalls = Global.server.GetAllOrderHall();

            foreach (OrderHallDTO order in allOrderHalls)
            {
                // אם ההזמנה שייכת לאולם שלנו ויש תאריך תקין
                if (order.IdHall == hallDTO.IdHall && order.EventDate != null)
                {
                    // נוסיף את התאריך לרשימת התאריכים החסומים בלוח השנה
                    DateTime dateToBlock = (DateTime)order.EventDate;
                    HallCalendar.BlackoutDates.Add(new CalendarDateRange(dateToBlock));
                }
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (HallCalendar.SelectedDate == null)
            {
                MessageBox.Show("אנא בחר תאריך תקני מתוך לוח השנה!");
                return;

            }
   
                else
            {
                if (say == true)
                {
                    DateTime selectedDate = HallCalendar.SelectedDate.Value;
                    NavigationService myFrame = NavigationService.GetNavigationService(this);
                    myFrame.Navigate(new POrderHall(selectedDate, hallDTO1, 1));
                }
                else
                {
                    DateTime selectedDate = HallCalendar.SelectedDate.Value;
                    NavigationService myFrame = NavigationService.GetNavigationService(this);
                    myFrame.Navigate(new POrderHall(selectedDate, hallDTO1));
                }
            }

        }
    }

}