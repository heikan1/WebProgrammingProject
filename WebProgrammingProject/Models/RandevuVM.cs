using WebProgrammingProject.Models.db;

namespace WebProgrammingProject.Models
{
    public class RandevuVM
    {
        public List<Rendezvous> myRendezvous { get; set; } = new List<Rendezvous>();
        public Customer user { get; set; } = new Customer();
        public Barber barber { get; set; } = new Barber();
        public string userRole { get; set; } = "C";
    }
}
