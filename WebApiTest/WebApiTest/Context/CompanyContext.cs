using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Models;

namespace WebApiTest.Context
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions options)
          : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}