using ServerYaelReichenberg.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerYaelReichenberg.DTO
{
    public class OrderDTO
    {
        public int IdOrder { get; set; }
        public Nullable<System.TimeSpan> TimeOrder { get; set; }
        public Nullable<int> IdUser { get; set; }
        public Nullable<int> NumOfMeal { get; set; }
        public Nullable<float> SumPrice { get; set; }
        public Nullable<int> IdOrderHall { get; set; }
        public string NumCard { get; set; }
        public string ExperationDate { get; set; }
        public Nullable<int> Cvv { get; set; }
        public OrderHallDTO OrderHall { get; set; }

        public UserDTO User { get; set; }
    }
}
