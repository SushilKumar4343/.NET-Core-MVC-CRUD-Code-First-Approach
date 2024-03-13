using Microsoft.EntityFrameworkCore;
using MVC_CORE_tu.Models;

namespace MVC_CORE_tu.Data
{
    public class ApplictionDbContext : DbContext
    {
        public ApplictionDbContext(DbContextOptions<ApplictionDbContext> options):base(options)
        {
                
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
