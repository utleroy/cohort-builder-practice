using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CohortBuild2.DAL
{
    public class CohortRepository : IRepository
    {
        public CohortContext CohortDatabase { get; set; }
        public CohortRepository(CohortContext context)
        {
            CohortDatabase = context;
        }
        public CohortRepository()
        {
            CohortDatabase = new CohortContext();
        }
    }
}