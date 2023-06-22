using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo()
                {
                    Id = 1,
                    Item = "Do the laundry",
                    Description = "Wash all the clothes and the bedding linen",
                    DueDate = DateTime.Now,
                }
                );
        }
    }
}
