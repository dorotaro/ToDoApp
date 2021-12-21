using System;

namespace Service
{
   public class ToDoRequestModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
