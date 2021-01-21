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
    }

    public class TodoTask
    {
        public int TodoTaskId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public TodoTaskStatus Status { get; } = TodoTaskStatus.New;
    }

    public enum TodoTaskStatus
    {
        New,
        Todo,
        InProgress,
        Done,
        Closed
    }
}
