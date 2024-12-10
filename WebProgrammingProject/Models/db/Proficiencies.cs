using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.db
{
    public class Proficiencies
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public TimeSpan duration { get; set; }
    }
}
