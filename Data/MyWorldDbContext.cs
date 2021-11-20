using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webappmssql.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace webappmssql.Data
{
    public class MyWorldDbContext:DbContext
    {
        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options):base(options){}

        public DbSet<Gadgets> Gadgets {get;set;}
    }
}
