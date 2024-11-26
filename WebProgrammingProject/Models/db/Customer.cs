using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace WebProgrammingProject.Models.db
{
    public class Customer
    {
        public Person PersonalInfo { get; set; }
        List<Rendezvous> Rendezvous { get; set; }

    }

}
