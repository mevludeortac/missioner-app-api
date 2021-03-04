using System;

namespace Missioner.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail {get;set;}
        public DateTime CreatedDate {get;set;}
        public DateTime Deadline {get;set;}
        public bool IsReminder {get;set;}
        public int CreatorId {get;set;}
        public int UserId {get;set;}
    }
}