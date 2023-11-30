using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExerciseTrackerUI.Models;

public class ExerciseContext : DbContext
{

    public ExerciseContext(DbContextOptions<ExerciseContext> options)
        : base(options)
    {
    }
    
    public DbSet<Exercise> Exercises { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  
    {  
    }

    
}