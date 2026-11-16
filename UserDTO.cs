using ServerYaelReichenberg.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerYaelReichenberg.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Tz { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Street { get; set; }
        public int IdCity { get; set; }
        public Nullable<int> NumOfHouse { get; set; }
        public string CellPhone { get; set; }
        public string PassWord { get; set; }
        public string UserType { get; set; }
        public string UserImag { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public  CityDTO city { get; set; }
    }
}
