using Microsoft.EntityFrameworkCore;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data.Entities
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext options) : base(options) 
        { 

        }
        protected DataContext() 
        { 

        }

        public DbSet<User> User { get; set; }
    }
}
