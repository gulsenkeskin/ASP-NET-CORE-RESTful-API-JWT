namespace Proje.API.DTOs
{
    public class StokDto
    {
        public int Id { get; set; }
        // public DateTime kayit_tarihi { get { return DateTime.Now; } }
        public string stok_kod { get; set; }
        public string stok_adi { get; set; }
        public string kategori { get; set; }
    }
}