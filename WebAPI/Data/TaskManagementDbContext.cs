using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.WebAPI.Data
{
    public class TaskManagementDbContext : DbContext
    {
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
