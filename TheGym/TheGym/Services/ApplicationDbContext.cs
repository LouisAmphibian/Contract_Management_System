using Microsoft.EntityFrameworkCore;
using TheGym.Models;

namespace TheGym.Services
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //To inject infomation to the database
        {

        }



    }
}