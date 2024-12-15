using WebProgrammingProject.Models.db;

namespace WebProgrammingProject.Models
{
    public class findAppointmentVM
    {
        public  List<Barber> barbers { get; set; } = new List<Barber>();
        public List<Rendezvous> randevular {  get; set; } = new List<Rendezvous>();
        public DateOnly tarih { get; set; }
        public List<Proficiencies> prf = new List<Proficiencies>();
        public homeViewModel hvm { get; set; } = new homeViewModel();
    }
}
