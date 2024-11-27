namespace WebProgrammingProject.Models.db
{
    public class Barber
    {
        public int Id { get; set; }
        public Person PersonalInfo { get; set; }
        public List<Rendezvous> Rendezvous { get; set; }
        public List<AvailableTime> AvailableTimes { get; set; }
    }
}
