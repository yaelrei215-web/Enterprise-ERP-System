using ServerYaelReichenberg.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerYaelReichenberg.DTO
{
    public class OrderHallDTO
    {
        public int IdOrderHall { get; set; }
        public Nullable<int> IdUser { get; set; }
        public Nullable<int> Complate { get; set; }

        public int IdHall { get; set; }
        public Nullable<System.DateTime> EventDate { get; set; }
        public string NumCard { get; set; }
        public Nullable<int> Cvv { get; set; }
        public string ExperationDate { get; set; }

        public  HallDTO Hall { get; set; }
        public  UserDTO USER { get; set; }
    }
}
