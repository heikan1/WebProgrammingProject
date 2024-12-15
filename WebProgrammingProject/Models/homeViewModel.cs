using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebProgrammingProject.Models.db;

namespace WebProgrammingProject.Models
{
    public class homeViewModel
    {
        [DisplayName("Şehir seçiniz:")]
        public string city { get; set; } = string.Empty;
        [DisplayName("tarih seçiniz:")]
        public DateOnly tarih { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
