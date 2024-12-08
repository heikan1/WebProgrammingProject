using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.db
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        [Required]
        public List<Barber> Barbers { get; set; } = new List<Barber>();

        public int ShopkeeperId { get; set; } // Required foreign key property
        public Shopkeeper? shopkeeper { get; set; }

    }
}
