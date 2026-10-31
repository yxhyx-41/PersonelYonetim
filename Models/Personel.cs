namespace PersonelYonetim.Models
{
    public class Personel
    {
        public int PersonelID { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }

        public int DepartmanID { get; set; }

        public Departman? Departman { get; set; }
    }
}