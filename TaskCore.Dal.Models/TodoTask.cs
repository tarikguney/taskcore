using System;

namespace TaskCore.Dal.Models
{
    public class TodoTask
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public DateTimeOffset? DueDateTime { get; set; }
        public int Priority { get; set; }
        public bool Completed { get; set; }
        public string? CategoryId { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset? CompletionDate { get; set; }
        
    }
}