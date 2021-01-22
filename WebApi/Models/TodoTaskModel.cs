using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;

namespace CBC.TaskManagement.WebApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents the Model for <see cref="TodoTask"/>
    /// </summary>
    public class TodoTaskModel
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <remarks>This field is required</remarks>
        [Required] public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }
    }
}