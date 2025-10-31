using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymManagementDAL.Repositories.Classes
{
    public class GenericRepo <TEntity>: IGenericRepo<TEntity> where TEntity:BaseEntity, new()
    {
         private readonly GymDbContext _dbcontext;
        public GenericRepo(GymDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public void Add(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Add(entity);
           
        }

        public void Delete(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Remove(entity);
           
        }

       

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool>? condition = null)
        {
            if (condition == null)
            {
                return _dbcontext.Set<TEntity>().AsNoTracking().ToList();
            }
            else
            {
                return _dbcontext.Set<TEntity>().AsNoTracking().Where(condition).ToList();
            }
        }

        public TEntity? GetById(int id)
        {
            return _dbcontext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Update(entity);

        }
    }
}
