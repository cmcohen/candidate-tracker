using CandidateTracker.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadidateTracker.web.Models
{
    public class CandidateViewModel
    {
        public IEnumerable<Candidate> Candidates { get; set; }
    }
}