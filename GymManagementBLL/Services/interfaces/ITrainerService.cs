using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementBLL.Services.ViewModels.MemberVM;
using GymManagementBLL.Services.ViewModels.TrainerVMs;

namespace GymManagementBLL.Services.interfaces
{
    internal interface ITrainerService
    {
        IEnumerable<TrainerVM> GetAllTrainers();
        TrainerVM? GetTrainerDetails(int id);
        bool createTrainer(CreateTrainerVM trainerVM);
        TrainerToUpdateVM? UpdateMember(TrainerVM member);
        bool UpdateTrainerDetails(int trainerId, TrainerToUpdateVM trainer);
        bool deleteTrainer(int id);







    }
}
