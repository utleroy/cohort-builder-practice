using CohortBuild2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CohortBuild2.DAL
{
    public class CohortContext : ApplicationDbContext
    {
        public virtual DbSet<Cohort> Cohorts { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
    }
}