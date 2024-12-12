using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebProgrammingProject.Models.db
{
    public class AvailableTime
    {
        public int Id { get; set; }
        public TimeOnly shift_start { get; set; }
        public TimeOnly shift_end { get; set; }
        public TimeSpan availableTimeSpan { get; set; }


        public int BarberId { get; set; }  

        /*public AvailableTime(TimeSpan start_t, TimeSpan end_t)
        {
            availableTimeSpan = end_t.Subtract(start_t);
        }*/

        //public TimeSpan availableSpan 
        //aradaki zamani donduren bir degiskene de ihtiyacim var basladigi zaman direkt calistirirsa
    }
}
