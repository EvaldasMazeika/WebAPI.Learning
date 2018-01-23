using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApi.TODOList.Entities
{
    public class TodosContext : DbContext
    {
        public TodosContext(DbContextOptions<TodosContext> options)
            : base(options)
        {
        }
        public DbSet<Todo> Todo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("Todos");
        }
    }
}
