using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.db
{
    public class Rendezvous
    {
        [Key]
        public int Id { get; set; }
        public DateTime When { get; set; }
        public int CustomerId { get; set; }
        public int BarberId { get; set; }
    }
}
