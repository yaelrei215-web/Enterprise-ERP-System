using ServerYaelReichenberg.DAL;
using ServerYaelReichenberg.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerYaelReichenberg.BL
{
        public class OrderHallBL
        {
            // המרה מ-Entity (הטבלה במסד נתונים) ל-DTO (מה שהלקוח רואה)
            public  OrderHallDTO Convert(OrderHall orderM)
            {
                OrderHallDTO orderP = new OrderHallDTO();
                orderP.IdOrderHall = orderM.IdOrderHall;
                orderP.IdUser = orderM.IdUser;
            orderP.Complate=orderM.Complate;
                orderP.IdHall = orderM.IdHall;
            orderP.Hall = new HallBL().Convert(orderM.Hall);
            orderP.EventDate = orderM.EventDate;
                orderP.NumCard = orderM.NumCard;
            orderM.Cvv = orderM.Cvv;
                orderP.ExperationDate = orderM.ExperationDate;

             

                return orderP;
            }

            // המרה מ-DTO ל-Entity (כדי לשמור במסד הנתונים)
            public OrderHall Convert(OrderHallDTO orderP)
            {
                OrderHall orderM = new OrderHall();
                orderM.IdOrderHall = orderP.IdOrderHall;
                orderM.IdUser = orderP.IdUser;
            orderM.Complate = orderP.Complate;
                orderM.IdHall = orderP.IdHall;
                orderM.EventDate = orderP.EventDate;
                orderM.NumCard = orderP.NumCard;
            orderM.Cvv= orderP.Cvv;
                orderM.ExperationDate = orderP.ExperationDate;

                return orderM;
            }

            // פונקציית הוספה למסד הנתונים
            public int Add(OrderHallDTO orderHallP)
            {

            OrderHall orderHallM = Convert(orderHallP);
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            db.OrderHalls.Add(orderHallM);
            db.SaveChanges();
            return orderHallM.IdHall;

            
            }
        public List<OrderHallDTO> Convert(List<OrderHall> orderHalls)
        {
            List<OrderHallDTO> listP = new List<OrderHallDTO>();
            foreach (OrderHall OrderHall1 in orderHalls)
            {
                listP.Add(Convert(OrderHall1));
            }
            return listP;
        }


        public List<OrderHallDTO> GetAll()
        {
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            {
                return Convert(db.OrderHalls.ToList());
            }
        }


        public bool Update(OrderHallDTO updated)
        {
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            List<OrderHall> lst = db.OrderHalls.ToList();
            foreach (OrderHall orderHall in lst)
            {
                if (orderHall.IdOrderHall == updated.IdOrderHall)
                {

                    orderHall.IdOrderHall= updated.IdOrderHall;
                    orderHall.IdUser = updated.IdUser;
                    orderHall.Complate = updated.Complate;
                    orderHall.IdHall = updated.IdHall;
                    orderHall.EventDate = updated.EventDate;
                    orderHall.NumCard = updated.NumCard;
                    orderHall.Cvv= updated.Cvv;
                    orderHall.ExperationDate = updated.ExperationDate;
        
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }


    }
}

