namespace WebProgrammingProject.Models
{
    public class AvailableTime
    {
        public DateTime start_t {  get; set; }
        public DateTime end_t { get; set; }
        public TimeSpan availableTimeSpan { get; set; }

        public AvailableTime(DateTime start, DateTime end)
        {
            start_t = start;
            end_t= end;
            availableTimeSpan = end.Subtract(start);
        }

        //public TimeSpan availableSpan 
        //aradaki zamani donduren bir degiskene de ihtiyacim var basladigi zaman direkt calistirirsa
    }
}
