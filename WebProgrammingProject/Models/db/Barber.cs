namespace WebProgrammingProject.Models.db
{
    public class Barber
    {
        public Person PersonalInfo { get; set; }
        List<Rendezvous> Rendezvous { get; set; }
        List<AvailableTime> AvailableTimes { get; set; }
    }
}
