using ServerYaelReichenberg.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerYaelReichenberg.DTO
{
    public class MealDTO
    {
        public int IdMeal { get; set; }
        public string NameMeal { get; set; }
        public string Described { get; set; }
        public Nullable<float> CountMeal { get; set; }
        public Nullable<int> IdCategory { get; set; }
        public string Image { get; set; }
        public CategoryDTO Category { get; set; }
        
    }
}
