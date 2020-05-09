using System;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Entity;

namespace ToDoList.Repository
{

    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
        }

        public DbSet<Employees> Employees { get; set; }
    }
}
