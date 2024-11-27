using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace WebProgrammingProject.Models.db
{
    public class Customer
    {
        public int Id { get; set; }
        public Person PersonalInfo { get; set; }
        public List<Rendezvous> Rendezvous { get; set; }

    }

}
