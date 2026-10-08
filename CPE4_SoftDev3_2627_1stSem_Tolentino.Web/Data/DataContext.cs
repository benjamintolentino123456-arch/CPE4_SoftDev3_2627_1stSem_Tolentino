using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
 
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        
    }
}
