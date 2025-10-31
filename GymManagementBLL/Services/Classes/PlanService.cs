using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementBLL.Services.interfaces;
using GymManagementBLL.Services.ViewModels.PlanVMs;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.interfaces;

namespace GymManagementBLL.Services.Classes
{
    internal class PlanService : IPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<PlanVM> GetAllPlans()
        {
            var plans = _unitOfWork.GetRepo<Plan>().GetAll();
            if (plans == null || !plans.Any())
            {
                return [];
            }
            return plans.Select(plan => new PlanVM
            {
                Name = plan.Name,
                Description = plan.Description,
                Price = plan.Price,
                DurationDays = plan.DurationDays,
                IsActive = plan.IsActive
            }).ToList();
        }

        public PlanVM? GetPlanDetails(int id)
        {
            var plan = _unitOfWork.GetRepo<Plan>().GetById(id);
            if (plan == null)
            {
                return null;
            }
            return new PlanVM
            {
                Name = plan.Name,
                Description = plan.Description,
                Price = plan.Price,
                DurationDays = plan.DurationDays,
                IsActive = plan.IsActive
            };

        }

        public UpdatePlanVM? GetPlanForUpdate(int id)
        {
            var plan = _unitOfWork.GetRepo<Plan>().GetById(id);
            if (plan == null|| plan.IsActive==false|| HasActiveMemberships(id))
            {
                return null;
            }
           
            return new UpdatePlanVM
            {
                PlanName = plan.Name,
                Description = plan.Description,
                Price = plan.Price,
                DurationDays = plan.DurationDays
            };

        }

        public bool TogglePlanStatus(int id)
        {
            var plan = _unitOfWork.GetRepo<Plan>().GetById(id);
            if (plan == null)
            {
                return false;
            }
            plan.IsActive = !plan.IsActive;
            try
            {
            _unitOfWork.GetRepo<Plan>().Update(plan);
            return _unitOfWork.SaveChanges() > 0;

            }
            catch (Exception)
            {
                return false;
            }       
        }

        public bool UpdatePlan(int id, UpdatePlanVM updatePlanVM)
        {
            var plan = _unitOfWork.GetRepo<Plan>().GetById(id);
            if (plan == null || plan.IsActive == false || HasActiveMemberships(id))
            {
                return false;
            }
            plan.Name = updatePlanVM.PlanName;
            plan.Description = updatePlanVM.Description;
            plan.Price = updatePlanVM.Price;
            plan.DurationDays = updatePlanVM.DurationDays;
            plan.UpdatedAt = DateTime.Now;

            _unitOfWork.GetRepo<Plan>().Update(plan);
            return _unitOfWork.SaveChanges() > 0;
        }

        #region helpers
        private bool HasActiveMemberships(int planId)
        {
            var activeMemberships = _unitOfWork.GetRepo<Membership>().GetAll(m => m.PlanId == planId && m.Satus=="Active");
            return activeMemberships.Any();
        }

        #endregion
    }
}
