using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.db
{
    public class Barber
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        public Person PersonalInfo { get; set; }
        public List<Rendezvous> Rendezvous { get; set; }
        public List<AvailableTime> AvailableTimes { get; set; }
        public List<String> Proficiencies { get; set; }
        public string Role  = "B";
    }
}
