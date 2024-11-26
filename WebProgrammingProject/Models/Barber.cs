namespace WebProgrammingProject.Models
{
    public class Barber
    {
        public Person PersonalInfo {  get; set; }
        List<Rendezvous> Rendezvous { get; set; }
        List<AvailableTime> AvailableTimes { get; set; }    
    }
}
