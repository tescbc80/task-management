namespace CBC.TaskManagement.WebApi.Models
{ 
    using System.ComponentModel.DataAnnotations;

    public partial class TodoTask
    {
        private TodoTask()
        {
        }

        public TodoTask(string description, Category category)
        {
            SetDetails(description, category);
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; private set; }

        [StringLength(50)]
        public string Description { get; private set; }

        public Status TaskStatus { get; private set; }

        public bool IsComplete { get { return this.TaskStatus == Status.Done; } }

        [Required]
        public Category Category { get; private set; }

        public void SetDetails(string description, Category category)
        {
            Title = description;
            Category = category;
        }

        public void MarkComplete()
        {
            this.TaskStatus = Status.Done;
        }

        public void MarkIncomplete()
        {
            this.TaskStatus = Status.InProgress;
        }
    }
}
