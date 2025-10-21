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
    internal class TrainerRepo : ITrainerRepo
    {
        private readonly GymDbContext _dbContext;
        public TrainerRepo(GymDbContext _dbContext)
        {

            this._dbContext = _dbContext;
        }
        public int AddTrainer(Trainer trainer)
        {
            _dbContext.Trainers.Add(trainer);
            return _dbContext.SaveChanges();
        }

        public int DeleteTrainer(int id)
        {
            var trainer = _dbContext.Trainers.Find(id);
            if (trainer == null)
            {
                return 0;
            }
            _dbContext.Trainers.Remove(trainer);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Trainer> GetAllTrainers()
        {
            return _dbContext.Trainers.ToList();
        }

        public Trainer? GetTrainer(int id)
        {
            return _dbContext.Trainers.Find(id);
        }

        public int UpdateTrainer(Trainer trainer)
        {
            _dbContext.Trainers.Update(trainer);
            return _dbContext.SaveChanges();
        }
    }
}
