namespace WebTemplate.Models;

public class IspitContext : DbContext
{
    public  DbSet<Racun> Racuni { get; set; }
    public  DbSet<Stan> Stanovi { get; set; }

    public IspitContext(DbContextOptions options) : base(options)
    {
        
    }
}
