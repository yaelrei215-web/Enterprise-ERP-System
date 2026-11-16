using ServerYaelReichenberg.DAL;
using ServerYaelReichenberg.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerYaelReichenberg.BL
{
    public class DataOrderBL
    {
       
        public DataOrderDTO Convert(DataOrder dataOrderM)
        {
            DataOrderDTO dataOrderP = new DataOrderDTO();
            dataOrderP.IdOrder = dataOrderM.IdOrder;
            dataOrderP.IdMeal = dataOrderM.IdMeal;
            dataOrderP.Count = dataOrderM.Count;
            dataOrderP.Meal = new MealBL().Convert(dataOrderM.Meal);
            dataOrderP.Order = new OrderBL().Convert( dataOrderM.Order);
            return dataOrderP;
        }

        
        public DataOrder Convert(DataOrderDTO dataOrderP)
        {
            DataOrder dataOrderM = new DataOrder();
            dataOrderM.IdOrder = dataOrderP.IdOrder;
            dataOrderM.IdMeal = dataOrderP.IdMeal;
            dataOrderM.Count = dataOrderP.Count;
            return dataOrderM;
        }

        public void Add(List<DataOrderDTO> listDataOrderP)
        {
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            List<DataOrderDTO> list = new List<DataOrderDTO>();

            foreach (DataOrderDTO dataOrderP in listDataOrderP)
            {
                bool found = false; 

                foreach (DataOrderDTO dataOrderp2 in list)
                {
                    // בודקים גם שההזמנה וגם שהמנה זהות
                    if (dataOrderP.IdMeal == dataOrderp2.IdMeal && dataOrderP.IdOrder == dataOrderp2.IdOrder)
                    {
                        dataOrderp2.Count += dataOrderP.Count; // מעדכנים כמות
                        found = true; // מסמנים שמצאנו
                        break; // אפשר לעצור את הלולאה הפנימית, מצאנו את מה שחיפשנו
                    }
                }

                // אם סרקנו את כל הרשימה ו-found נשאר false, זה אומר שזו מנה חדשה!
                if (!found)
                {
                    list.Add(dataOrderP); // מוסיפים אותה לרשימה החדשה
                }
            }

            // עכשיו הרשימה 'list' מלאה ומאוחדת, ואפשר לשמור ל-DB בבטחה
            foreach (DataOrderDTO dataOrderP in list)
            {
                DataOrder dataOrderM = new DataOrder();
                dataOrderM.IdOrder = dataOrderP.IdOrder;
                dataOrderM.IdMeal = dataOrderP.IdMeal;
                dataOrderM.Count = dataOrderP.Count;
                db.DataOrders.Add(dataOrderM);
            }

            db.SaveChanges();
        }

        public List<DataOrderDTO> GetAll(int id)
        {
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            List<DataOrder> listDataOrder1 = new List<DataOrder>();
            foreach (DataOrder dataOrder1 in db.DataOrders)
            {
                if (dataOrder1.IdOrder==id)
                {
                    listDataOrder1.Add(dataOrder1);
                    
                }

            }
            return Convert(listDataOrder1.ToList());
            
        }
        public List<DataOrderDTO> Convert(List<DataOrder> listM)
        {
            List<DataOrderDTO> listP = new List<DataOrderDTO>();
            foreach (DataOrder DataOrder1 in listM)
            {
                listP.Add(Convert(DataOrder1));
            }
            return listP;
        }
    }
}