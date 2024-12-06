using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.db
{
    public class Shopkeeper
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Person PersonalInfo { get; set; }
        [Required]
        public List<Shop> Shops{ get; set; }

        public string Role = "A";
    }
}
