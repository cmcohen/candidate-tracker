using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTracker.data
{
    public class CandidateRepository
    {
        private string _connectionString;
        public CandidateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCandidate(Candidate candidate)
        {
            using (var context = new CandidateTrackerDataContext())
            {
                context.Candidates.InsertOnSubmit(candidate);
                context.SubmitChanges();
            }
        }
        public IEnumerable<Candidate> GetCandidates(Status status)
        {
            using (var context = new CandidateTrackerDataContext())
            {
                return context.Candidates.Where(c => c.Status == status).ToList();
            }
        }

        public int GetCount(Status status)
        {
            return GetCandidates(status).Count();
        }

        public Candidate GetCandidate(int id)
        {
            using (var context = new CandidateTrackerDataContext())
            {
                return context.Candidates.FirstOrDefault(c => c.Id == id);
            }
        }

        public void UpdateStatus(int id, Status status)
        {
            using (var context = new CandidateTrackerDataContext())
            {
                context.ExecuteCommand("UPDATE Candidates SET Status = {0} where id = {1}", status, id);
                context.SubmitChanges();
            }
        }
    }
}
