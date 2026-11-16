using ServerYaelReichenberg.DAL;
using ServerYaelReichenberg.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerYaelReichenberg.BL
{
    public class UserBL
    {
        public UserDTO Convert(USER userM)
        {
            UserDTO userP = new UserDTO();
            userP.Id = userM.Id;
            userP.Tz = userM.Tz;
            userP.FirstName = userM.FirstName;
            userP.LastName = userM.LastName;
            userP.Street = userM.Street;
            userP.NumOfHouse = userM.NumOfHouse;
            userP.Birthday = userM.Birthday;
            userP.IdCity = userM.IdCity;
            userP.city = new CityBL().Convert(userM.city);
            userP.IsDeleted = userM.IsDeleted;
            userP.CellPhone = userM.CellPhone;
            userP.UserType = userM.UserType;
            userP.UserImag  = userM.UserImag;
            userP.PassWord = userM.PassWord;
            return userP;
        }
        public USER Convert(UserDTO userP)
        {
            USER userM = new USER();
            userM.Id = userP.Id;
            userM.Tz = userP.Tz;
            userM.FirstName = userP.FirstName;
            userM.LastName = userP.LastName;
            userM.Street = userP.Street;
            userM.NumOfHouse = userP.NumOfHouse;
            userM.Birthday = userP.Birthday;
            userM.IdCity = userP.IdCity;
           
            userM.IsDeleted = userP.IsDeleted;
            userM.CellPhone = userP.CellPhone;
            userM.UserType = userP.UserType;
            userM.UserImag = userP.UserImag;
            userM.PassWord = userP.PassWord;
            return userM;
        }
        public List<UserDTO> Convert(List<USER> user)
        {
            List<UserDTO> listP = new List<UserDTO>();
            foreach (USER userM in user)
            {
                listP.Add(Convert(userM));
            }
            return listP;
        }

        public int Add (UserDTO userp) 
        { USER userM = Convert(userp);
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            db.USERS.Add(userM);
            db.SaveChanges();
            return userM.Id;
        }
        public List <UserDTO> GetAll() 
        { DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            List<USER> list = db.USERS.ToList();
            return Convert(list);
        }
        public UserDTO GetUserByTzAndPassword(string tz, string pass) 
        {
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            List <USER> lstUsers = db.USERS.ToList();
            foreach (USER user1 in lstUsers)
            {
                if ((user1.Tz == tz) && (user1.PassWord == pass))
                    return Convert(user1); 
            }
            
            return null;

        }
        public bool Update(UserDTO userUpdated)
        {
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            List<USER> lstUsers = db.USERS.ToList();
            foreach (USER user1 in lstUsers)
            {
                if (user1.Id == userUpdated.Id)
                {
                    
                    user1.Id = userUpdated.Id;
                    user1.Tz = userUpdated.Tz;
                    user1.FirstName = userUpdated.FirstName;
                    user1.LastName = userUpdated.LastName;
                    user1.Street = userUpdated.Street;
                    user1.NumOfHouse = userUpdated.NumOfHouse;
                    user1.Birthday = userUpdated.Birthday;
                    user1.IdCity = userUpdated.IdCity;

                    user1.IsDeleted = userUpdated.IsDeleted;
                    user1.CellPhone = userUpdated.CellPhone;
                    user1.UserType = userUpdated.UserType;
                    user1.UserImag = userUpdated.UserImag;
                    user1.PassWord = userUpdated.PassWord;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
