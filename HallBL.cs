using ServerYaelReichenberg.DAL;
using ServerYaelReichenberg.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ServerYaelReichenberg.BL
{
    public class HallBL
    {
        public HallDTO Convert(Hall hallM)
        {
            if (hallM == null) return null;
            HallDTO hallP = new HallDTO();
            hallP.IdHall = hallM.IdHall;
            hallP.Name = hallM.Name;
            hallP.IdCity = hallM.IdCity;
            hallP.city = new CityBL().Convert(hallM.city);
            hallP.Price = hallM.Price;
            hallP.Amount = hallM.Amount;
            hallP.Street = hallM.Street;
            hallP.CellPhone = hallM.CellPhone;
            hallP.HouseNumber = hallM.HouseNumber;
            hallP.Image = hallM.Image;
        
            return hallP;
        }

        // המרה ל-DAL
        public Hall Convert(HallDTO hallP)
        {
            Hall hallM = new Hall();
            hallM.IdHall = hallP.IdHall;
            hallM.Name = hallP.Name;
            hallM.IdCity = hallP.IdCity;
            hallM.Price = hallP.Price;
            hallM.Amount = hallP.Amount;    
            hallM.Street = hallP.Street;
            hallM.HouseNumber = hallP.HouseNumber;
            hallM.CellPhone = hallP.CellPhone;
            hallM.Image = hallP.Image;
            return hallM;
        }

        public bool Update(HallDTO hallUpdete)
        {
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            List<Hall> lstUHall = db.Halls.ToList();
            foreach (Hall hall in lstUHall)
            {

                if (hall.Name == hallUpdete.Name &&
                    hall.city.NameCity == hallUpdete.city.NameCity &&
                    hall.Street == hallUpdete.Street &&
                    hall.HouseNumber == hallUpdete.HouseNumber)
                {

                }

            }
            db.SaveChanges();
            return true;
        }
        public int Add(HallDTO hallP)
        {
            Hall hallM = Convert(hallP);
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            db.Halls.Add(hallM);
            db.SaveChanges();
            return hallM.IdHall;
        }
        public List<HallDTO> Convert(List<Hall> hall)
        {
            List<HallDTO> listP = new List<HallDTO>();
            foreach (Hall hallM in hall)
            {
                listP.Add(Convert(hallM));
            }
            return listP;
        }

        public List<HallDTO> GetAll()
        { 
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            List<Hall> list = db.Halls.ToList();
            return Convert(list);

     
        }
   
    }
}
