using System;

namespace Persistence
{
   public class ToDoWriteModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
