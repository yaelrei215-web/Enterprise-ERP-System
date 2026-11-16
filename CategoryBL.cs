using ServerYaelReichenberg.DAL;
using ServerYaelReichenberg.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerYaelReichenberg.BL
{
    public class CategoryBL
    {
       
        public CategoryDTO Convert(Category categoryM)
        {
          
            CategoryDTO categoryP = new CategoryDTO();

            categoryP.IdCategory = categoryM.IdCategory;
            categoryP.NameCategory = categoryM.NameCategory;
            return categoryP;
        }

       
        public Category Convert(CategoryDTO categoryP)
        {
            Category categoryM = new Category();
            categoryM.NameCategory = categoryP.NameCategory;
            categoryM.IdCategory = categoryP.IdCategory;
            return categoryM;
        }

     
        public List<CategoryDTO> Convert(List<Category> categories)
        {
            List<CategoryDTO> listP = new List<CategoryDTO>();
            foreach (Category Category1 in categories)
            {
                listP.Add(Convert(Category1));
            }
            return listP;
        }

      
        public List<CategoryDTO> GetAll()
        {
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            {
                return Convert(db.Categories.ToList());
            }
        }
        
      
        public int Add(CategoryDTO categoryP)
        {
            DbYaelReichenbergEntities4 db = new DbYaelReichenbergEntities4();
            {
                Category categoryM = Convert(categoryP);
                db.Categories.Add(categoryM);
                db.SaveChanges();
                return categoryM.IdCategory;
            }
        }
    }
}