using ServerYaelReichenberg.DAL;
using ServerYaelReichenberg.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerYaelReichenberg.BL
{
    public class OrderBL
    {
        public OrderDTO Convert(Order orderM)
        {
           
            OrderDTO orderP = new OrderDTO();

            orderP.IdOrder = orderM.IdOrder;
            orderP.TimeOrder = orderM.TimeOrder;
            orderP.IdUser = orderM.IdUser;
            orderP.User = new UserBL().Convert(orderM.USER);
            orderP.NumOfMeal = orderM.NumOfMeal;
            orderP.SumPrice = orderM.SumPrice;
            orderP.IdOrderHall = orderM.IdOrderHall;
            orderP.OrderHall=new OrderHallBL().Convert(orderM.OrderHall);
            orderP.NumCard = orderM.NumCard;
            orderP.Cvv=orderM.Cvv;
            orderP.ExperationDate = orderM.ExperationDate;
          

            return orderP;
        }

        public Order Convert(OrderDTO orderP)
        {
   
            Order orderM = new Order();
            orderM.TimeOrder = orderP.TimeOrder;
            orderM.IdUser = orderP.IdUser;
            orderM.NumOfMeal = orderP.NumOfMeal;
            orderM.SumPrice = orderP.SumPrice;
            orderM.IdOrderHall= (int)orderP.IdOrderHall;
       
            orderM.NumCard = orderP.NumCard;
            orderM.Cvv=orderP.Cvv;
            orderM.ExperationDate = orderP.ExperationDate;
            return orderM;
        }








        public List<OrderDTO> Convert(List<Order> orders)
        {
            List<OrderDTO> listP = new List<OrderDTO>();
            foreach (Order Order1 in orders)
            {
                listP.Add(Convert(Order1));
            }
            return listP;
        }


        public List<OrderDTO> GetAll()
        {
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            {
                return Convert(db.Orders.ToList());
            }
        }






   

        public int Add(OrderDTO orderP)
        {
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            { 
                Order orderM = Convert(orderP);
                db.Orders.Add(orderM);
                db.SaveChanges();
                return orderM.IdOrder;
            }
        }
    }
}
