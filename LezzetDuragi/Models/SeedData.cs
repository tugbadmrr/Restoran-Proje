using Microsoft.EntityFrameworkCore;
using LezzetDuragi.Data;

namespace LezzetDuragi.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new UygulamaDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<UygulamaDbContext>>()))
        {
            // Veritabanının oluştuğundan emin ol (Tabloları oluşturur)
            context.Database.EnsureCreated();

            // Veritabanı zaten doluysa işlem yapma
            if (context.Yemekler.Any())
            {
                return;
            }

            context.Yemekler.AddRange(
                new Yemek
                {
                    Ad = "Süzme Mercimek Çorbası",
                    Fiyat = 90.00M,
                    Aciklama = "Kemik suyu ile hazırlanmış, tereyağlı sos eşliğinde.",
                    EklenmeTarihi = DateTime.Now
                },
                new Yemek
                {
                    Ad = "Adana Kebap",
                    Fiyat = 320.00M,
                    Aciklama = "Zırh kıyması, özel baharatlar, közlenmiş domates ve biber ile.",
                    EklenmeTarihi = DateTime.Now
                },
                new Yemek
                {
                    Ad = "İskender Kebap",
                    Fiyat = 380.00M,
                    Aciklama = "Özel pideler üzerinde döner dilimleri, domates sosu ve kızgın tereyağı.",
                    EklenmeTarihi = DateTime.Now
                },
                new Yemek
                {
                    Ad = "Beyti Sarma",
                    Fiyat = 350.00M,
                    Aciklama = "Lavaşa sarılı kuzu kıyma, yoğurt ve özel sos eşliğinde.",
                    EklenmeTarihi = DateTime.Now
                },
                new Yemek
                {
                    Ad = "Kayseri Mantısı",
                    Fiyat = 280.00M,
                    Aciklama = "El açması hamur, sarımsaklı yoğurt ve sumaklı sos.",
                    EklenmeTarihi = DateTime.Now
                },
                new Yemek
                {
                    Ad = "Lahmacun (Acılı)",
                    Fiyat = 110.00M,
                    Aciklama = "Taş fırında odun ateşinde pişmiş, bol malzemeli çıtır lezzet.",
                    EklenmeTarihi = DateTime.Now
                },
                new Yemek
                {
                    Ad = "Mevsim Salatası",
                    Fiyat = 80.00M,
                    Aciklama = "Taze yeşillikler, havuç, mor lahana, zeytinyağı ve limon sosu.",
                    EklenmeTarihi = DateTime.Now
                },
                new Yemek
                {
                    Ad = "Gavurdağı Salatası",
                    Fiyat = 120.00M,
                    Aciklama = "İnce kıyım domates, biber, soğan ve bol ceviz içi.",
                    EklenmeTarihi = DateTime.Now
                },
                new Yemek
                {
                    Ad = "Künefe",
                    Fiyat = 180.00M,
                    Aciklama = "Hatay peyniri ile hazırlanmış, bol fıstıklı sıcak tatlı.",
                    EklenmeTarihi = DateTime.Now
                },
                new Yemek
                {
                    Ad = "Fıstıklı Baklava (Porsiyon)",
                    Fiyat = 200.00M,
                    Aciklama = "Gaziantep fıstığı ile hazırlanmış, 3 dilim çıtır baklava.",
                    EklenmeTarihi = DateTime.Now
                },
                new Yemek
                {
                    Ad = "Fırın Sütlaç",
                    Fiyat = 100.00M,
                    Aciklama = "Üzeri nar gibi kızarmış, köy sütü ile yapılmış.",
                    EklenmeTarihi = DateTime.Now
                },
                new Yemek
                {
                    Ad = "Yayık Ayranı",
                    Fiyat = 40.00M,
                    Aciklama = "Bol köpüklü, ev yapımı taze ayran.",
                    EklenmeTarihi = DateTime.Now
                }
            );

            context.SaveChanges(); // Verileri kaydet
        }
    }
}
