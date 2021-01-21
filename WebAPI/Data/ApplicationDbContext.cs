using CBC.TaskManagement.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBC.TaskManagement.WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
