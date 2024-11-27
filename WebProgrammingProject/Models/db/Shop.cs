using Microsoft.EntityFrameworkCore;

namespace WebProgrammingProject.Models.db
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public List<Barber> Barbers { get; set; }
        public Shopkeeper Shopkeeper { get; set; }
    }
}
