using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.db
{
    public class Rendezvous
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime When { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int BarberId { get; set; }
        [Required]
        public string operation { get; set; }
    }
}
