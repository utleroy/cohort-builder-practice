using CohortBuild2.DAL;
using CohortBuild2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohortBuild2Test.DAL
{
    [TestClass]
   public class FakeCohortRepositoryTest
    {
        public Mock<CohortContext> mock_context { get; set; }

        public Mock<DbSet<Cohort>> mock_cohort_set { get; set; }

        public CohortRepository repo { get; set; }
        public IQueryable<Cohort> query_cohort { get; set; }
        public List<Cohort> fake_cohort_table { get; set; }
        public List<Instructor> fake_instructor_table { get; set; }
        public List<Student> fake_student_table { get; set; }

        [TestInitialize]
        public void Setup()
        {
            fake_cohort_table = new List<Cohort>();
            fake_instructor_table = new List<Instructor>();
            fake_student_table = new List<Student>();

            mock_context = new Mock<CohortContext>();
            mock_cohort_set = new Mock<DbSet<Cohort>>();
            repo = new CohortRepository(mock_context.Object);
        }

        public void SetUpMocksAsQueryable()
        {
            var cohortQueryable = fake_cohort_table.AsQueryable();

            mock_cohort_set.As<IQueryable<Cohort>>().Setup(x => x.Provider).Returns(cohortQueryable.Provider);
            mock_cohort_set.As<IQueryable<Cohort>>().Setup(x => x.Expression).Returns(cohortQueryable.Expression);
            mock_cohort_set.As<IQueryable<Cohort>>().Setup(x => x.ElementType).Returns(cohortQueryable.ElementType);
            mock_cohort_set.As<IQueryable<Cohort>>().Setup(x => x.GetEnumerator()).Returns(() => cohortQueryable.GetEnumerator());


            var instructorQueryable = fake_instructor_table.AsQueryable();

            mock_cohort_set.As<IQueryable<Instructor>>().Setup(x => x.Provider).Returns(instructorQueryable.Provider);
            mock_cohort_set.As<IQueryable<Instructor>>().Setup(x => x.Expression).Returns(instructorQueryable.Expression);
            mock_cohort_set.As<IQueryable<Instructor>>().Setup(x => x.ElementType).Returns(instructorQueryable.ElementType);
            mock_cohort_set.As<IQueryable<Instructor>>().Setup(x => x.GetEnumerator()).Returns(() => instructorQueryable.GetEnumerator());

            var studentQueryable = fake_student_table.AsQueryable();

            mock_cohort_set.As<IQueryable<Student>>().Setup(x => x.Provider).Returns(studentQueryable.Provider);
            mock_cohort_set.As<IQueryable<Student>>().Setup(x => x.Expression).Returns(studentQueryable.Expression);
            mock_cohort_set.As<IQueryable<Student>>().Setup(x => x.ElementType).Returns(studentQueryable.ElementType);
            mock_cohort_set.As<IQueryable<Student>>().Setup(x => x.GetEnumerator()).Returns(() => studentQueryable.GetEnumerator());
        }

        [TestMethod]
        public void EnureICanCreateInstance()
        {
            CohortRepository repo = new CohortRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void EnsureContextIsNotNull()
        {
            CohortRepository repo = new CohortRepository();
            var context = repo.CohortDatabase;
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void EnsureContextPassedInIsNotNull()
        {
            CohortContext cohortContext = new CohortContext();
            CohortRepository repo = new CohortRepository(cohortContext);
            var context = repo.CohortDatabase;
            Assert.IsNotNull(context);
        }
    }
}
