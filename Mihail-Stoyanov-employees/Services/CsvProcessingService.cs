using CsvHelper;
using Mihail_Stoyanov_employees.Models;
using System.Globalization;

namespace Mihail_Stoyanov_employees.Services
{
    public class CsvProcessingService : ICsvProcessingService
    {
        public async Task<ProcessingResult> ProcessCsvAsync(IFormFile csvFile)
        {
            if (csvFile == null || csvFile.Length == 0)
                throw new ArgumentException("CSV file is empty or missing.");

            List<AssignmentCsvRow> rows;
            using (Stream stream = csvFile.OpenReadStream())
            using (StreamReader reader = new StreamReader(stream))
            using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<AssignmentMap>();
                rows = csv.GetRecords<AssignmentCsvRow>().ToList();
            }

            Dictionary<(int, int), List<PairProjectDetail>> pairDetails = new();

            foreach (var projectGroup in rows.GroupBy(r => r.ProjectId))
            {
                int projectId = projectGroup.Key;
                var assignments = projectGroup.ToList();

                for (int i = 0; i < assignments.Count; i++)
                {
                    for (int j = i + 1; j < assignments.Count; j++)
                    {
                        AssignmentCsvRow a = assignments[i];
                        AssignmentCsvRow b = assignments[j];

                        DateTime start = a.DateFrom > b.DateFrom ? a.DateFrom : b.DateFrom;
                        DateTime end = a.DateTo < b.DateTo ? a.DateTo : b.DateTo;

                        if (end >= start)
                        {
                            int daysWorked = (int)(end - start).TotalDays + 1;
                            var key = a.EmpId < b.EmpId ? (a.EmpId, b.EmpId) : (b.EmpId, a.EmpId);

                            if (!pairDetails.TryGetValue(key, out var list))
                            {
                                list = new List<PairProjectDetail>();
                                pairDetails[key] = list;
                            }

                            list.Add(new PairProjectDetail
                            {
                                ProjectId = projectId,
                                DaysWorked = daysWorked
                            });
                        }
                    }
                }
            }

            var allPairs = pairDetails
                .Select(kvp => new PairResultDto
                {
                    EmpId1 = kvp.Key.Item1,
                    EmpId2 = kvp.Key.Item2,
                    TotalDays = kvp.Value.Sum(v => v.DaysWorked),
                    Projects = kvp.Value.OrderBy(p => p.ProjectId).ToList()
                })
                .OrderByDescending(p => p.TotalDays)
                .ToList();

            return new ProcessingResult
            {
                TopPair = allPairs.FirstOrDefault(),
                AllPairs = allPairs
            };
        }
    }
}
