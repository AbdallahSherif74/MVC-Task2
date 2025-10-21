using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;

namespace GymManagementDAL.Repositories.interfaces
{
    internal interface ICategoryRepo
    {
        //GetAllCategories
        IEnumerable<Category> GetAllCategories();
        //GetCategoryById
        Category? GetCategory(int id);
        //AddCategory
        int AddCategory(Category category);
        //UpdateCategory
        int UpdateCategory(Category category);
        //DeleteCategory
        int DeleteCategory(int id);
    }
}
