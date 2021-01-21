using CBC.TaskManagement.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBC.TaskManagement.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
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
