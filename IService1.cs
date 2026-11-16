using ServerYaelReichenberg.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServerYaelReichenberg
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int AddCity(CityDTO cityP);

        [OperationContract]
        List<CityDTO> GetCityList();

        [OperationContract]
        int AddUser(UserDTO userP);
        [OperationContract]
        List<UserDTO> GetUserList();
        [OperationContract]
        UserDTO GetUserByTzAndPassword(string tz, string pass);
        [OperationContract]
        bool UpdateUser(UserDTO userUpdated);
        [OperationContract]
        List<CategoryDTO> GetCategoryList();
        [OperationContract]
        int AddCategory(CategoryDTO categoryP);
        [OperationContract]
        List<MealDTO> GetMealList();
        [OperationContract]

        List<OrderDTO> GetOrderList();
        [OperationContract]
        List<UserDTO> GetAllUser();
        [OperationContract]
        List<DataOrderDTO> GetAllDataOrder(int id);
        [OperationContract]
        int AddMeal(MealDTO mealP);
        [OperationContract]
        void AddDataOrder(List< DataOrderDTO> DataOrderP);
        [OperationContract]
        int AddOrder(OrderDTO orderP);
        [OperationContract]
        List<MealDTO> CheckMeal(int id);
        [OperationContract]
        List<HallDTO> GetAllHall();
        [OperationContract]
        int AddHall(HallDTO hallP);
        [OperationContract]
        int AddOrderHall(OrderHallDTO orderHallP);
        [OperationContract]
        List<OrderHallDTO> GetAllOrderHall();
        [OperationContract]
        bool UpdateOrderHalll(OrderHallDTO updated);
    }
}
