namespace PersonelYonetim.Models
{
    public class Departman
    {
        public int DepartmanID { get; set; }
        public string DepartmanAdi { get; set; }

        public ICollection<Personel> Personeller { get; set; }
    }
}