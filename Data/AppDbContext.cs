

using combineDaySixteenN_TierAPIs.Models;
using Microsoft.EntityFrameworkCore;

namespace combineDaySixteenN_TierAPIs.Data
{
    //The DbContext is the connection to the database
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Supply> Supplies {get; set;}

        //Here we set our tables 
        //Each Dbset is one table
    }
}