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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-7H9S4CS\\SQLEXPRESS;Initial Catalog=Indio;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Name).HasColumnName("NAME");
            });
        }
    }
}
