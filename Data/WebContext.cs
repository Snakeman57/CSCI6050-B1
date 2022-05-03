using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CineWeb.Models;

namespace CineWeb.Data;

public class WebContext : IdentityDbContext<CineWebUser>
{
    public WebContext(DbContextOptions<WebContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<CineWebUser> User { get; set; }
    public DbSet<ShowTime> ShowTime { get; set; }

    public DbSet<Theater> Theater { get; set; }

    public DbSet<MoviePromotion> MoviePromotion { get; set; }

    // public DbSet<CineWeb.Models.Booking> Booking { get; set; }
}
