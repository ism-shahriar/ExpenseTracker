using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManagerAPI.Entities
{
    public class ExpenseManagerDBContext:DbContext
    {
        public ExpenseManagerDBContext()
        {

        }
        public ExpenseManagerDBContext(DbContextOptions<ExpenseManagerDBContext> options)
           : base(options)
        {
        }


        public DbSet<Client> Clients { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        public DbSet<ExpenseDetail> ExpenseDetails { get; set; }

    }
}
