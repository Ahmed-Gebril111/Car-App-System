using CarApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApplication.DAL.Contexts
{
    public class MVCAppDbContext:DbContext
    {

        public MVCAppDbContext(DbContextOptions<MVCAppDbContext> options):base(options) 
        {
            
        }

        public DbSet<Car> Cars {  get; set; } 

    }
}
