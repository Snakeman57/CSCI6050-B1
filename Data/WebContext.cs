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
    public DbSet<Role> Roles { get; set; }
    public DbSet<CineWebUser> User { get; set; }
    public DbSet<PayCard> PaymentCards { get; set; }
    public DbSet<MoviePromotion> Promotions { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ShowTime> ShowTimes { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Theater> Theaters { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketType> TicketTypes { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

}
