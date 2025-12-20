using System;
using System.ComponentModel.DataAnnotations; // Bu kütüphane kurallar için gerekli

namespace LezzetDuragi.Models
{
    public class Yemek
    {
        public int Id { get; set; }

        [Display(Name = "Yemek Adı")]
        [Required(ErrorMessage = "Lütfen yemek adını boş bırakmayınız.")]
        [StringLength(100, ErrorMessage = "Yemek adı en fazla 100 karakter olabilir.")]
        public string Ad { get; set; } = string.Empty;

        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Fiyat bilgisi zorunludur.")]
        [Range(0, 10000, ErrorMessage = "Fiyat 0 ile 10.000 TL arasında olmalıdır.")]
        public decimal Fiyat { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Yemek açıklaması yazmanız müşteri için önemlidir.")]
        public string? Aciklama { get; set; }

        [Display(Name = "Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now; 
    }
}