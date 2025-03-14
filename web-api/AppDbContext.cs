using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Submission> Submissions { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
