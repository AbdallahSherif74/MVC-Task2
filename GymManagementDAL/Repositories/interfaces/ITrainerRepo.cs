using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;

namespace GymManagementDAL.Repositories.interfaces
{
    internal interface ITrainerRepo
    {
        //GetAllTrainers
        IEnumerable<Trainer> GetAllTrainers();
        //GetTrainerById
        Trainer? GetTrainer(int id);
        //AddTrainer
        int AddTrainer(Trainer trainer);
        //UpdateTrainer
        int UpdateTrainer(Trainer trainer);
        //DeleteTrainer
        int DeleteTrainer(int id);
    }
}
