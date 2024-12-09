using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.db
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

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

        public string Role = "C";
    }

}
