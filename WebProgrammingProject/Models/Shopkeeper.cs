using Microsoft.EntityFrameworkCore;

namespace WebProgrammingProject.Models
{
    public class Shopkeeper : DbContext
    {
        public Person PersonalInfo { get; set; }
        public List<Shop> Shops { get; set; }

    }
}
