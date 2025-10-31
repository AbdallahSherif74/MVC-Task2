using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace GymManagementDAL.Repositories.interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepo<TEntity> GetRepo<TEntity>() where TEntity: BaseEntity,new()  ;

        int SaveChanges();
    }
}
