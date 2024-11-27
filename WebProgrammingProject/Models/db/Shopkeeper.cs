using Microsoft.EntityFrameworkCore;

namespace WebProgrammingProject.Models.db
{
    public class Shopkeeper
    {
        public int Id { get; set; }
        public Person PersonalInfo { get; set; }
        public List<Shop> Shops{ get; set; }

    }
}
