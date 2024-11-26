using Microsoft.EntityFrameworkCore;

namespace WebProgrammingProject.Models
{
    public class Shop : DbContext
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        List<Barber> Barbers { get; set; }
        
    }
}
