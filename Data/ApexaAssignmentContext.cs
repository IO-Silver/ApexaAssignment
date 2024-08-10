using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApexaAssignment.Models;

namespace ApexaAssignment.Data
{
    public class ApexaAssignmentContext : DbContext
    {
        public ApexaAssignmentContext (DbContextOptions<ApexaAssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<ApexaAssignment.Models.Advisor> Advisor { get; set; } = default!;
    }
}
