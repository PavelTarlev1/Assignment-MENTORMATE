using Assignment_2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;


        public DataContext (IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }


        public DbSet<RoomModel> RoomModels { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
