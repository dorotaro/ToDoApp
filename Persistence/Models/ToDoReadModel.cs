﻿using System;

namespace Persistence
{
   public class ToDoReadModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public bool IsDone { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
