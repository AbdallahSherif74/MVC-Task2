using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementBLL.Services.interfaces;
using GymManagementBLL.Services.ViewModels.MemberVM;
using GymManagementBLL.Services.ViewModels.TrainerVMs;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.interfaces;

namespace GymManagementBLL.Services.Classes
{
    internal class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrainerService(IUnitOfWork unitOfWork) {
        
            _unitOfWork = unitOfWork;
        }

        public bool createTrainer(CreateTrainerVM trainerVM)
        {
            try
            {
                if (IsEmailExists(trainerVM.Email) || IsPhoneExists(trainerVM.Phone))
                {
                    return false;

                }
                
                var AddTrainer = new Trainer()
                {
                    Name = trainerVM.Name,
                    Email = trainerVM.Email,
                    Phone = trainerVM.Phone,
                    DateOfBirth = trainerVM.DateOfBirth,
                    speciallities = trainerVM.Speciallity,
                    gender = trainerVM.Gender,
                    Address = new Address()
                    {
                        BuildingNumber = trainerVM.BuildingId,
                        Street = trainerVM.Street,
                        City = trainerVM.City,
                    },
                };

                _unitOfWork.GetRepo<Trainer>().Add(AddTrainer);
                return _unitOfWork.SaveChanges() > 0;


            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteTrainer(int id)
        {
            try
            {
                var existingTrainer = _unitOfWork.GetRepo<Trainer>().GetById(id);
                if (existingTrainer == null)
                {
                    return false;
                }
                var HasActiveSession = _unitOfWork.GetRepo<Session>().GetAll(S=> S.TrainerID == id && S.EndDate > DateTime.Now).Any();
                if (HasActiveSession) return false;
                _unitOfWork.GetRepo<Trainer>().Delete(existingTrainer);
                return _unitOfWork.SaveChanges() > 0;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<TrainerVM> GetAllTrainers()
        {
            var trainers= _unitOfWork.GetRepo<Trainer>().GetAll();
            if (trainers == null || !trainers.Any())
            {
                return [];
            }
            return trainers.Select(T => new TrainerVM
            {
                Id = T.Id,
                Name = T.Name,
                Email = T.Email,
                Phone = T.Phone,
                Speciallities = T.speciallities.ToString()
            }).ToList();
        }

        public TrainerVM? GetTrainerDetails(int id)
        {
            var trainer = _unitOfWork.GetRepo<Trainer>().GetById(id);
            if(trainer == null)
            {
                return null;
            }
            var trainerVM=new TrainerVM()
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                Speciallities = trainer.speciallities.ToString()
            };
            return trainerVM;
        }

        public TrainerToUpdateVM? UpdateMember(TrainerVM member)
        {
            var trainer = _unitOfWork.GetRepo<Trainer>().GetById(member.Id);
            if (trainer == null)
            {
                return null;
            }
            var trainerToUpdateVM = new TrainerToUpdateVM()
            {
              
                Email = trainer.Email,
                PhoneNumber = trainer.Phone,
                Speciallity = trainer.speciallities,
                City = trainer.Address?.City ?? string.Empty,
                Street = trainer.Address?.Street ?? string.Empty,
                BuildingId = trainer.Address?.BuildingNumber ?? 0,
            };
            return trainerToUpdateVM;


        }

        public bool UpdateTrainerDetails(int trainerId, TrainerToUpdateVM trainer)
        {
            try
            {
                var existingTrainer = _unitOfWork.GetRepo<Trainer>().GetById(trainerId);
                if (existingTrainer == null)
                {
                    return false;
                }
                if (existingTrainer.Email != trainer.Email && IsEmailExists(trainer.Email))
                {
                    return false;
                }
                if (existingTrainer.Phone != trainer.PhoneNumber && IsPhoneExists(trainer.PhoneNumber))
                {
                    return false;
                }
                existingTrainer.Email = trainer.Email;
                existingTrainer.Phone = trainer.PhoneNumber;
                existingTrainer.speciallities = trainer.Speciallity;
                if (existingTrainer.Address == null)
                {
                    existingTrainer.Address = new Address();
                }
                existingTrainer.Address.BuildingNumber = trainer.BuildingId;
                existingTrainer.Address.Street = trainer.Street;
                existingTrainer.Address.City = trainer.City;
                _unitOfWork.GetRepo<Trainer>().Update(existingTrainer);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }



        }



        #region helpers
        private bool IsEmailExists(string email)
        {
            var emailExists = _unitOfWork.GetRepo<Trainer>().GetAll(m => m.Email == email).Any();

            return emailExists;
        }
        private bool IsPhoneExists(string phone)
        {
            var phoneExists = _unitOfWork.GetRepo<Trainer>().GetAll(m => m.Phone == phone).Any();
            return phoneExists;
        }
        #endregion
    }
}
