using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;

namespace GymManagementDAL.Repositories.interfaces
{
    internal interface IHealthRecordRepo
    {
        //GetAllHealthRecords
        IEnumerable<HealthRecord> GetAllHealthRecords();
        //GetHealthRecordById
        HealthRecord? GetHealthRecord(int id);
        //AddHealthRecord
        int AddHealthRecord(HealthRecord healthRecord);
        //UpdateHealthRecord
        int UpdateHealthRecord(HealthRecord healthRecord);
        //DeleteHealthRecord
        int DeleteHealthRecord(int id);
    }
}
