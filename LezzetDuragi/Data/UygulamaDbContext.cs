using Microsoft.EntityFrameworkCore;
using LezzetDuragi.Models;

namespace LezzetDuragi.Data;

public class UygulamaDbContext : DbContext
{
    public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
    {
    }

    // Yemek tablomuzu veritabanında temsil edecek satır
    public DbSet<Yemek> Yemekler { get; set; }
}