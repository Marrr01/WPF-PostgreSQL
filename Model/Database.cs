using Microsoft.EntityFrameworkCore;

namespace WpfPostgre
{
    internal class Database : DbContext
    {
        public Database()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Person> Males { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=testdb;Username=postgres;Password=masterkey");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(p => p.GUID).HasColumnName("guid").IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.Gender).HasColumnName("gender").IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.Name).HasColumnName("name").IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.Surname).HasColumnName("surname").IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.CompanyINN).HasColumnName("company_inn").HasMaxLength(10);
            modelBuilder.Entity<Person>().ToTable("males").HasKey(p => p.GUID);

            modelBuilder.Entity<Company>().Property(p => p.CompanyINN).HasColumnName("company_inn").IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Company>().Property(p => p.Name).HasColumnName("name").IsRequired();
            modelBuilder.Entity<Company>().ToTable("companies").HasKey(c => c.CompanyINN);

            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
    }
}
