using adv.Model;
using Microsoft.EntityFrameworkCore;

namespace adv.Data
{
    public class DataDBContext:DbContext
    {
        public DataDBContext(DbContextOptions<DataDBContext> option):base(option) 
        {
            
        }

       public DbSet<model> Member { get; set; }
       public DbSet<model2> Provider { get; set; }    

      public  DbSet<model3> Pharmacy { get; set; }
    }
}
