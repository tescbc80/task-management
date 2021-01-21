using System;
using System.ComponentModel.DataAnnotations;

namespace CBC.TaskManagement.WebApi.Models
{
    public class TodoTaskModel
    {
        [Required] public string Title { get; set; }
        public string Description { get; set; }
    }
}