using System;
using System.ComponentModel.DataAnnotations;
using CBC.TaskManagement.WebApi.TodoTasksApi.Domain.SeedWork;

namespace CBC.TaskManagement.WebApi.TodoTasksApi.Domain
{
    public class TodoTask
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }


        [MaxLength(500)] 
        public string Description { get; set; }

        public TodoTaskStatus Status { get; set; }

        public bool IsComplete => Status == TodoTaskStatus.Done;
    }
}
