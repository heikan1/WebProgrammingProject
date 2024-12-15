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
        //saatini berberlerin availableliklarindan gunleri de salon ve berberler ile karsilastirarak yaparsin
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int BarberId { get; set; }
        [Required]
        public bool isApproved { get; set; } = false;
        public string operation { get; set; }
        //operationdan duration + when alirim
    }
}
