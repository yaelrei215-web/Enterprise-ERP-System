using ServerYaelReichenberg.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerYaelReichenberg.DTO
{
    public class DataOrderDTO
    {
        public int IdOrder { get; set; }
        public int IdMeal { get; set; }
        public Nullable<int> Count { get; set; }

        public MealDTO Meal { get; set; }
        public  OrderDTO Order { get; set; }
    }
}
