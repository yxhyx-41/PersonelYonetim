using Microsoft.EntityFrameworkCore;
using PersonelYonetim.Models;

namespace PersonelYonetim.Data
{
    public class PersonelDbContext : DbContext
    {
        public PersonelDbContext(DbContextOptions<PersonelDbContext> options)
            : base(options)
        {
        }

        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }
    }
}