using CBC.TaskManagement.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBC.TaskManagement.WebApi.Data
{
    public class TodoTaskContext : DbContext
    {
        public TodoTaskContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}
