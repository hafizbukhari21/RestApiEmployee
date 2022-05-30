using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Contex
{
    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions<MyContext> options) : base(options)
        {

        }

        public  DbSet<Employee> Employees { set; get; }
    }
}
