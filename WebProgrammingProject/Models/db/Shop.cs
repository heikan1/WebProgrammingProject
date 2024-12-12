using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.db
{
    public class Shop
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        // List to hold selected days
        public List<DayOfWeekEnum> SelectedDays { get; set; } = new List<DayOfWeekEnum>();

        // Helper property to generate all days of the week
        public List<DayOfWeekEnum> AllDays { get; set; } = Enum.GetValues(typeof(DayOfWeekEnum))
                                                          .Cast<DayOfWeekEnum>()
                                                          .ToList();        //[Required]



        public int ShopkeeperId { get; set; } // Required foreign key property

    }
}
