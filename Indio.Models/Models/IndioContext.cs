using Indio.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Indio.Models
{
    public partial class IndioContext : DbContext
    {
        public IndioContext()
        {
        }

        public IndioContext(DbContextOptions<IndioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-7H9S4CS\\SQLEXPRESS;Initial Catalog=Indio;Integrated Security=True",
                    x => x.MigrationsAssembly("Indio.Models"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Name).HasColumnName("NAME");
            });

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Email = "admin@admin.com", Name = "Admin", Password = "9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08" });
        }
    }
}
