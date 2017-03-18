using System.Collections.Generic;

namespace CohortBuild2.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Cohort> Cohorts { get; set; }
    }
}