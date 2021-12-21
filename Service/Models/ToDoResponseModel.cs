using System;

namespace Service
{
   public class ToDoResponseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }
        public bool IsDone { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
