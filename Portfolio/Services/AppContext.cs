using Portfolio.Models;

namespace Portfolio.Services;

using Microsoft.EntityFrameworkCore;


public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options) { }
    public DbSet<Mail> Mails { get; set; }
    
}
