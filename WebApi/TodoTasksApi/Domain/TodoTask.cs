namespace CBC.TaskManagement.WebApi.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TodoTask
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }


        [MaxLength(500)] 
        public string Description { get; set; }

        public TodoTaskStatus Status { get; set; }

        public bool IsComplete { get { return this.Status == TodoTaskStatus.Done; } }

    }
}
