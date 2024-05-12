using API.Entity;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class LearningDbContext(DbContextOptions<LearningDbContext> options)
    : DbContext(options)
{
    /*public DbSet<CourseEntity> Courses { get; set; }

    public DbSet<LessonEntity> Lessons { get; set; } */

    public DbSet<UserEntity> Users { get; set; }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new LessonConfiguration());
    } */
}