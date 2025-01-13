using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Chambre> Chambres { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}

public class Chambre
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public int Capacite { get; set; }
}