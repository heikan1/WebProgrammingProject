using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace WebProgrammingProject.Models.db
{
    public class Shopkeeper
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; } // Required foreign key property
        public Person PersonalInfo{ get; set; } = null!; // Required reference navigation to principal
        
        // Reference navigation to dependent
        //public virtual Person PersonalInfo { get; set; }
        [Required]
        public List<Shop> Shops{ get; set; }

        public string Role = "A";
    }
}
