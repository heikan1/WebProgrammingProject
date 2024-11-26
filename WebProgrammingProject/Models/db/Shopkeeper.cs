using Microsoft.EntityFrameworkCore;

namespace WebProgrammingProject.Models.db
{
    public class Shopkeeper
    {
        public Person PersonalInfo { get; set; }
        public List<Shop> Shops { get; set; }

    }
}
