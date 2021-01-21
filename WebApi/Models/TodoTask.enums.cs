namespace CBC.TaskManagement.WebApi.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class TodoTask
    {
        public enum Status
        {
            Open,
            InProgress,
            Done
        }
    }
}
