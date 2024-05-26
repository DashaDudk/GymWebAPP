using GymWebAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace GymWebAPP.Models
{
    public class GymAPIContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGym> UserGyms { get; set; }
        public virtual DbSet<Gym> Gyms { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                        .HasMany(c => c.Gyms)
                        .WithOne(g => g.Category)
                        .HasForeignKey(g => g.CategoryId);

            modelBuilder.Entity<Gym>()
                .HasOne(g => g.Category) // Кожне тренування має одну категорію
                .WithMany(c => c.Gyms) // Один до багатьох: одна категорія містить багато тренувань
                .HasForeignKey(g => g.CategoryId); // Зовнішній ключ в таблиці тренувань для посилання на категорію
        }
        public GymAPIContext(DbContextOptions<GymAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
