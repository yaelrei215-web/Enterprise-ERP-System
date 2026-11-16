using ServerYaelReichenberg.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerYaelReichenberg.DTO
{
    public class HallDTO
    {
        public int IdHall { get; set; }
        public string Name { get; set; }
        public int IdCity { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Amount { get; set; }
        public string Street { get; set; }
        public string CellPhone { get; set; }
        public string HouseNumber { get; set; }
        public string Image { get; set; }
        public CityDTO city { get; set; }
      
    }
}
