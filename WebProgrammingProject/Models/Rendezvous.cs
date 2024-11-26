using Microsoft.EntityFrameworkCore;

namespace WebProgrammingProject.Models
{
    public class Rendezvous : DbContext
    {
        public int Id { get; set; }
        public DateTime When { get; set; }
    }
}
