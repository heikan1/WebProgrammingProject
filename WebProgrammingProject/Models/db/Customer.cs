using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.db
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public Person PersonalInfo { get; set; }

        public List<Rendezvous> Rendezvous { get; set; }

        public string Role = "C";
    }

}
