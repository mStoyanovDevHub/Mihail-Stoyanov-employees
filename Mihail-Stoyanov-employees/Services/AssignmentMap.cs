using CsvHelper.Configuration;
using Mihail_Stoyanov_employees.Models;

namespace Mihail_Stoyanov_employees.Services
{
    public sealed class AssignmentMap : ClassMap<AssignmentCsvRow>
    {
        public AssignmentMap()
        {
            Map(m => m.EmpId).Index(0);
            Map(m => m.ProjectId).Index(1);
            Map(m => m.DateFrom).Index(2).TypeConverter<FlexibleDateConverter>();
            Map(m => m.DateTo).Index(3).TypeConverter<FlexibleDateConverter>();
        }
    }
}
