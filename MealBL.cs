using ServerYaelReichenberg.DAL;
using ServerYaelReichenberg.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerYaelReichenberg.BL
{
    public class MealBL
    {
 
        public MealDTO Convert(Meal mealM)
        {
            MealDTO mealP = new MealDTO();

            mealP.IdMeal = mealM.IdMeal;
            mealP.NameMeal = mealM.NameMeal;
            mealP.Described = mealM.Described;
            mealP.CountMeal = mealM.CountMeal;
            mealP.IdCategory = mealM.IdCategory;
            mealP.Category = new CategoryBL().Convert(mealM.Category);
            mealP.Image = mealM.Image;
            return mealP;
        }

        public Meal Convert(MealDTO mealP)
        {
            Meal mealM = new Meal();
           
            mealP.IdMeal = mealM.IdMeal;
            mealM.NameMeal = mealP.NameMeal;
            mealM.Described = mealP.Described;
            mealM.CountMeal = mealP.CountMeal;
            mealM.IdCategory = mealP.IdCategory;
            mealM.Image = mealP.Image;
            return mealM;
        }

      
        public List<MealDTO> Convert(List<Meal> meals)
        {
            List<MealDTO> listP = new List<MealDTO>();
            foreach (Meal Meal1 in meals)
            {
                listP.Add(Convert(Meal1));
            }
            return listP;
        }

     
        public List<MealDTO> GetAll()
        {
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();

            return Convert(db.Meals.ToList());

        }



        public int Add(MealDTO mealP)
        {
            Meal mealM = Convert(mealP);
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            db.Meals.Add(mealM);
           
            db.SaveChanges();
            return mealM.IdMeal;
           
        }


        public List<MealDTO> Check(int id)
        {  
            List<MealDTO> listP = new List<MealDTO>();
            List<MealDTO> allMeal = GetAll();
            foreach (MealDTO meal1 in allMeal)
            {
                if (meal1.IdMeal == id)
                {
                    listP.Add(meal1); 
                }
            }
            return listP;
        }
    }

}

