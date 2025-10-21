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
    internal class HealthRecordRepo : IHealthRecordRepo
    {
        private readonly GymDbContext _dbContext;
        public HealthRecordRepo(GymDbContext dbContext) {
        
            _dbContext = dbContext;
        }
        public int AddHealthRecord(HealthRecord healthRecord)
        {
            _dbContext.HealthRecords.Add(healthRecord);
            return _dbContext.SaveChanges();

        }

        public int DeleteHealthRecord(int id)
        {
            var healthRecord = _dbContext.HealthRecords.Find(id);
            if (healthRecord == null)
            {
                return 0;
            }
            _dbContext.HealthRecords.Remove(healthRecord);
            return _dbContext.SaveChanges();

        }

        public IEnumerable<HealthRecord> GetAllHealthRecords()
        {
            return _dbContext.HealthRecords.ToList();

        }

        public HealthRecord? GetHealthRecord(int id)
        {
            return _dbContext.HealthRecords.Find(id);

        }

        public int UpdateHealthRecord(HealthRecord healthRecord)
        {
            _dbContext.HealthRecords.Update(healthRecord);
            return _dbContext.SaveChanges();

        }
    }
}
