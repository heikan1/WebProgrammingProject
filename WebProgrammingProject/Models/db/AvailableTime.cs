namespace WebProgrammingProject.Models.db
{
    public class AvailableTime
    {
        public int Id { get; set; }
        public DateTime start_t { get; set; }
        public DateTime end_t { get; set; }
        public TimeSpan availableTimeSpan { get; set; }

        public Barber Barber { get; set; }  

        public AvailableTime(DateTime start_t, DateTime end_t)
        {
            availableTimeSpan = end_t.Subtract(start_t);
        }

        //public TimeSpan availableSpan 
        //aradaki zamani donduren bir degiskene de ihtiyacim var basladigi zaman direkt calistirirsa
    }
}
