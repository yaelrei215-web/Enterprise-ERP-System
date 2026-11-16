using ServerYaelReichenberg.BL;
using ServerYaelReichenberg.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServerYaelReichenberg
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public int AddCategory(CategoryDTO categoryP)
        {
            return new CategoryBL().Add(categoryP);
        }

        public int AddCity(CityDTO cityP)
        {
            return new CityBL().Add(cityP);
        }

        public int AddMeal(MealDTO mealP)
        {
            return new MealBL().Add(mealP);
        }

        public int AddOrder(OrderDTO orderP)
        {
            return new OrderBL().Add(orderP);
        }

        public int AddUser(UserDTO userP)
        {
            return new UserBL().Add(userP);
        }

        public void AddDataOrder(List< DataOrderDTO> DataOrderP)
        {
            new DataOrderBL().Add(DataOrderP);
        }

        public List<MealDTO> CheckMeal(int id)
        {
            return new MealBL().Check(id);
        }

        public List<CategoryDTO> GetCategoryList()
        {
            return new CategoryBL().GetAll();
        }

        public List<CityDTO> GetCityList()
        {
            return new CityBL().GetAll();
        }
        public List<OrderDTO> GetOrderList()
        {
            return new OrderBL().GetAll();
        }
        public List<MealDTO> GetMealList()
        {
            return new MealBL().GetAll();
        }

        public UserDTO GetUserByTzAndPassword(string tz, string pass)
        {
            return new UserBL().GetUserByTzAndPassword(tz, pass);
        }

        public List<UserDTO> GetUserList()
        {
            return new UserBL().GetAll();
        }

        public bool UpdateUser(UserDTO userUpdated)
        {
            return new UserBL().Update(userUpdated);
        }

        public List<DataOrderDTO> GetAllDataOrder(int id)
        {
            return   new DataOrderBL().GetAll(id);
        }

        public List<UserDTO> GetAllUser()
        {
            return new UserBL().GetAll();

        }

        public List<HallDTO> GetAllHall()
        {
           return new HallBL().GetAll();    
        }

        public int AddHall(HallDTO hallP)
        {
            return new HallBL().Add(hallP);
        }

        public int AddOrderHall(OrderHallDTO orderHallP)
        {
            return new OrderHallBL().Add(orderHallP);
        }

        public List<OrderHallDTO> GetAllOrderHall()
        {
           return new OrderHallBL().GetAll();
        }

        public bool UpdateOrderHalll(OrderHallDTO updated)
        {
            return new OrderHallBL().Update(updated);
        }
    }
    }
