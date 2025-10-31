using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementBLL.Services.interfaces;
using GymManagementBLL.Services.ViewModels.MemberVM;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.interfaces;

namespace GymManagementBLL.Services.Classes
{
    internal class MemberService : IMemberService
    {
      
        private readonly IUnitOfWork _unitOfWork;
        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }


        public bool createMember(CreateMemberVM member)
        {
            try
            {


                if (IsEmailExists(member.Email) || IsPhoneExists(member.PhoneNumber))
                {
                    return false;
                }
                var AddMember = new Member()
                {
                    Name = member.Name,
                    Email = member.Email,
                    Phone = member.PhoneNumber,

                    DateOfBirth = member.DateOfBirth,
                    gender = member.Gender,
                    Address = new Address()
                    {
                        BuildingNumber = member.BuildingId,
                        Street = member.Street,
                        City = member.City,
                    },
                    HealthRecord = new HealthRecord()
                    {
                        BloodType = member.HealthRecord.BloodType,
                        Height = member.HealthRecord.Height,
                        Weight = member.HealthRecord.Weight,
                        Note = member.HealthRecord.Note,

                    },
                };
                 _unitOfWork.GetRepo<Member>().Add(AddMember) ;
                return _unitOfWork.SaveChanges()>0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteMember(int memberId)
        {
            try
            {
                var existingMember = _unitOfWork.GetRepo<Member>().GetById(memberId);
                if (existingMember == null)
                {
                    return false;
                }
                var HasActiveSession = _unitOfWork.GetRepo<MemberSession>().GetAll(m => m.MemberId == memberId && m.Session.StartDate > DateTime.Now).Any();
                if (HasActiveSession) return false;
                 _unitOfWork.GetRepo<Member>().Delete(existingMember) ;

                return _unitOfWork.SaveChanges() > 0;



            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<MemberVM> GetAllMembers()
        {
            var Members = _unitOfWork.GetRepo<Member>().GetAll();
            if (Members == null || !Members.Any())
            {
                return [];
            }
            var MemberVMs = new List<MemberVM>();
            foreach (var member in Members)
            {
                var memberVM = new MemberVM()
                {
                    Id = member.Id,
                    Name = member.Name,
                    Email = member.Email,
                    PhotoUrl = member.photo,
                };
                MemberVMs.Add(memberVM);

                ;
            }
            return MemberVMs;
        }


        public MemberVM? GetMemberDetails(int id)
        {
            var member = _unitOfWork.GetRepo<Member>().GetById(id);
            if (member == null)
            {
                return null;
            }
            var memberVM = new MemberVM()
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email,
                PhotoUrl = member.photo,
                Gender = member.gender.ToString(),
                DateOfBirth = member.DateOfBirth.ToShortDateString(),
                address = $"{member.Address?.BuildingNumber}- {member.Address?.Street}- {member.Address?.City}"

            };

            var mempership = _unitOfWork.GetRepo<Membership>().GetAll(m => m.MemberId == member.Id && m.Satus == "Active").FirstOrDefault();
            if (mempership is not null)
            {
                memberVM.PlanName = mempership.Plan.Name;
                memberVM.MemberShipStartDate = mempership.CreatedAt.ToShortDateString();
                memberVM.MemberShipEndDate = mempership.EndDate.ToShortDateString();

            }


            return memberVM;

        }

        public HealthRecordVM? GetMemberHealthRecord(int memberId)
        {
            var MemberHealthRec = _unitOfWork.GetRepo<HealthRecord>().GetById(memberId);
            if (MemberHealthRec == null)
            {
                return null;
            }
            return new HealthRecordVM()
            {
                Height = (int)MemberHealthRec.Height,
                Weight = (int)MemberHealthRec.Weight,
                BloodType = MemberHealthRec.BloodType,
                Note = MemberHealthRec.Note,
            };

        }

        public MemberToUpdateVM? UpdateMember(MemberVM member)
        {
            var existingMember = _unitOfWork.GetRepo<Member>().GetById(member.Id);
            if (existingMember == null)
            {
                return null;
            }
            var memberToUpdateVM = new MemberToUpdateVM()
            {
                Email = existingMember.Email,
                PhoneNumber = existingMember.Phone,
                BuildingId = existingMember.Address.BuildingNumber,
                Street = existingMember.Address.Street,
                City = existingMember.Address.City,
            };
            return memberToUpdateVM;

        }

        public bool UpdateMemberDetails(int memberId, MemberToUpdateVM member)
        {
            try
            {
                if (IsEmailExists(member.Email) || IsPhoneExists(member.PhoneNumber))
                {
                                        return  false;
                }
                var existingMember = _unitOfWork.GetRepo<Member>().GetById(memberId);
                if (existingMember == null)
                {
                    return false;
                }
                existingMember.Email = member.Email;
                existingMember.Phone = member.PhoneNumber;
                existingMember.Address.BuildingNumber = member.BuildingId;
                existingMember.Address.Street = member.Street;
                existingMember.Address.City = member.City;
                existingMember.UpdatedAt = DateTime.Now;
                 _unitOfWork.GetRepo<Member>().Update(existingMember) ;
                return _unitOfWork.SaveChanges() > 0;



            }
            catch (Exception)
            {
                return false;

            }
        }


        #region Helpers
        private bool IsEmailExists(string email)
        {
            var emailExists = _unitOfWork.GetRepo<Member>().GetAll(m => m.Email == email ).Any();
            
            return emailExists ;
        }
        private bool IsPhoneExists(string phone)
        {
            var phoneExists = _unitOfWork.GetRepo<Member>().GetAll(m => m.Phone == phone).Any();
            return phoneExists;
        }
        #endregion
    }
}
