using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.interfaces;
using static System.Collections.Specialized.BitVector32;

namespace GymManagementDAL.Repositories.Classes
{
    internal class CategoryRepo : ICategoryRepo
    {
        private readonly GymDbContext _dbContext;
        public CategoryRepo(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            return _dbContext.SaveChanges();


        }

        public int DeleteCategory(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return 0;
            }
            _dbContext.Categories.Remove(category);
            return _dbContext.SaveChanges();

        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();

        }

        public Category? GetCategory(int id)
        {
            return _dbContext.Categories.Find(id);

        }

        public int UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            return _dbContext.SaveChanges();

        }
    }
}
