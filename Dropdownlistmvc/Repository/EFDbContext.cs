using Dropdownlistmvc.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dropdownlistmvc.Repository
{
    public class EFDbContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Gender> Genders { get; set; }
    }
}