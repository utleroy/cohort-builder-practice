using System.Collections.Generic;

namespace CohortBuild2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public ICollection<Cohort> Cohorts { get; set; }
    }
}