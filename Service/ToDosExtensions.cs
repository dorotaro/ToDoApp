
using Persistence;
using System;

namespace Service
{
    public static class ToDosExtensions
    {
        public static ToDoResponseModel MapToResponseModel(this ToDoRequestModel model)
        {
            return new ToDoResponseModel
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Difficulty = model.Difficulty,
                IsDone = model.IsDone,
                DateCreated = model.DateCreated
            };
        }

        public static ToDoResponseModel MapToResponseModel(this ToDoReadModel model)
        {
            return new ToDoResponseModel
            {
                Id = Guid.Parse(model.Id),
                Title = model.Title,
                Description = model.Description,
                Difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), model.Difficulty),
                IsDone = model.IsDone,
                DateCreated = model.DateCreated
            };
        }

        public static ToDoWriteModel MapToWriteModel(this ToDoRequestModel model)
        {
            return new ToDoWriteModel
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Difficulty = model.Difficulty.ToString(),
                IsDone = model.IsDone,
                DateCreated = model.DateCreated
            };
        }

        
    }
}
