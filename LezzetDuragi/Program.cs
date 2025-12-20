using Microsoft.EntityFrameworkCore;
using LezzetDuragi.Data;
using LezzetDuragi.Models;

var builder = WebApplication.CreateBuilder(args);

// Veritabanı bağlantısını ekliyoruz
builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC servisini ekle
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Hata yönetimi ve güvenlik ayarları
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // İşte .NET 8'in sevdiği kod bu!

app.UseRouting();

app.UseAuthorization();

// Rota ayarları
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// --- OTOMATİK VERİ EKLEME BAŞLANGICI ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}
// --- OTOMATİK VERİ EKLEME BİTİŞİ ---

app.Run();