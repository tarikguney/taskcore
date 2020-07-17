using System;

namespace TaskCore.Dal.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? DueDateTime { get; set; }
        public int Priority { get; set; }
        public bool Completed { get; set; }
        public string CategoryId { get; set; }
    }
}