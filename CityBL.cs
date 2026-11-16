using ServerYaelReichenberg.DAL;
using ServerYaelReichenberg.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerYaelReichenberg.BL
{
    public class CityBL
    {
        public CityDTO Convert(city cityM)
        {
            CityDTO cityP = new CityDTO();
            cityP.IdCity = cityM.IdCity;
            cityP.NameCity = cityM.NameCity;
            return cityP;
        }
        public city Convert(CityDTO cityP)
        {
            city cityM = new city();
            cityM.IdCity = cityP.IdCity;
            cityM.NameCity = cityP.NameCity;
            return cityM;
        }

        public List<CityDTO> Convert(List<city> list)

        {
            List<CityDTO> listP = new List<CityDTO>();
            foreach (city x in list)
            {
                listP.Add(Convert(x));
            }
            return listP;

        }

        public int Add (CityDTO city) 
        
        {city cityM = new city();
            cityM = this.Convert(city);
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            db.cities.Add(cityM);
            db.SaveChanges();
            return cityM.IdCity;
        }

        public List <CityDTO> GetAll()

        { DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            List<city> listM =db.cities.ToList();
            return Convert(listM); 
        
        
        }  
    }
}
