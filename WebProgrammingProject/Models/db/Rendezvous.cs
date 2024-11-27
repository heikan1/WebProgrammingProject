using Microsoft.EntityFrameworkCore;

namespace WebProgrammingProject.Models.db
{
    public class Rendezvous
    {
        public int Id { get; set; }
        public DateTime When { get; set; }
        public Customer Customer { get; set; }
        public Barber Barber { get; set; }
    }
}
