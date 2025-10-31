using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Data.Contexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.interfaces;

namespace GymManagementDAL.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GymDbContext _dbcontext;  
        public UnitOfWork(GymDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        private readonly Dictionary<Type, object> _repositories = new();
        public IGenericRepo<TEntity> GetRepo<TEntity>() where TEntity : BaseEntity, new()
        {
            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                var repositoryInstance = new GenericRepo<TEntity>(_dbcontext);
                _repositories[type] = repositoryInstance;
            }
            return (IGenericRepo<TEntity>)_repositories[type];
        }

        public int SaveChanges()
        {
            return _dbcontext.SaveChanges();
        }

       
    }
}
