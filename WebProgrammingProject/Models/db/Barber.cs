using NuGet.Packaging.Signing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.db
{

    public class Barber
    {

        [Key]
        public int Id { get; set; }
        //[Required]
        public int ShopId { get; set; }

        [Required(ErrorMessage = "Lütfen ilk isminizi giriniz."), MaxLength(50, ErrorMessage = "İlk isminiz 50 karakterden küçük olmalıdır."), MinLength(2, ErrorMessage = "İlk isminiz 2 karakterden uzun olmalıdır")]
        [DisplayName("İlk İsim")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lütfen soy isminizi giriniz."), MaxLength(50, ErrorMessage = "Soy isminiz 50 karakterden küçük olmalıdır."), MinLength(2, ErrorMessage = "Soy İsminiz 2 karakterden uzun olmalıdır")]
        [DisplayName("Soy İsim")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz."), EmailAddress(ErrorMessage = "Lütfen geçerli bir elektronik posta adresi giriniz.")]
        [DisplayName("Elektronik Posta adresi")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz."), MinLength(10, ErrorMessage = "Şifreniz 10 karakterden uzun olmalıdır."), MaxLength(100, ErrorMessage = "Şifreniz 100 karakterden küçük olmalıdır.")]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Lütfen maaş giriniz.")]
        [Range(0, int.MaxValue, ErrorMessage = "Lütfen 0'dan büyük eşit bir maaş değeri giriniz.")]
        [DisplayName("Maaş")]
        public int Wage{ get; set; }
        //public List<Rendezvous> Rendezvous { get; set; }
        //public List<AvailableTime> AvailableTimes { get; set; }
        
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        // List to hold selected days
        public List<DayOfWeekEnum> SelectedDays { get; set; } = new List<DayOfWeekEnum>();

        // Helper property to generate all days of the week
        public List<DayOfWeekEnum> AllDays { get; set; } = Enum.GetValues(typeof(DayOfWeekEnum))
                                                          .Cast<DayOfWeekEnum>()
                                                          .ToList();        //[Required]

        public int Proficiency { get; set; }
    public string Role  = "B";
    }
}
