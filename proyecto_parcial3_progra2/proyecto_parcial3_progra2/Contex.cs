using Microsoft.EntityFrameworkCore;

public class dbContext : DbContext 
{
    public DbSet<Notas> notas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlServer("Server=DESKTOP-H8P0V0H\\SQLEXPRESS;Database=Parcial#3; Trusted_Connection = true; ");
    }
}

