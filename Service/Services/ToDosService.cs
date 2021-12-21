using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence;

namespace Service.Services
{
    public class ToDosService : IToDosService
    {
        private readonly IToDosRepository _toDosRepository;
        public ToDosService(IToDosRepository toDosRepository)
        {
            _toDosRepository = toDosRepository;
        }

        public async Task AddToDoItem(ToDoRequestModel toDoRequestModel)
        {
            var model = new ToDoWriteModel
            {
                Id = toDoRequestModel.Id,
                Title = toDoRequestModel.Title,
                Description = toDoRequestModel.Description,
                Difficulty = toDoRequestModel.Difficulty.ToString(),
                DateCreated = toDoRequestModel.DateCreated,

            };

           await _toDosRepository.AddToDoItem(model);
            
        }
        public async Task<ToDoResponseModel> GetById(Guid id)
        {
           var model =  await _toDosRepository.GetById(id);

            var responseModel = new ToDoResponseModel
            {
                Id = Guid.Parse(model.Id),
                Title = model.Title,
                Description = model.Description,
                Difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), model.Difficulty),
                DateCreated = model.DateCreated
            };

            return responseModel;
        }

        public async Task<IEnumerable<ToDoResponseModel>> GetAll()
        {
            var models = await _toDosRepository.GetAll();

            var responseModels = new List<ToDoResponseModel>();

            foreach (var model in models) //foreach through ienumerable - why is this possible in htis case?
            {
                responseModels.Add(
                new ToDoResponseModel
                {
                    Id = Guid.Parse(model.Id),
                    Title = model.Title,
                    Description = model.Description,
                    Difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), model.Difficulty),
                    DateCreated = model.DateCreated
                });
                
            }

            return responseModels;
        }

        public async Task DeleteAll()
        {
            await _toDosRepository.DeleteAll();
        }

        public async Task DeleteToDoItem(Guid id)
        {
            await _toDosRepository.DeleteToDoItem(id);
        }

        public async Task EditToDoItem(ToDoRequestModel toDoRequestModel)
        {
            var writeModel = new ToDoWriteModel
            {
                Id = toDoRequestModel.Id,
                Title = toDoRequestModel.Title,
                Description = toDoRequestModel.Description,
                Difficulty = toDoRequestModel.Difficulty.ToString(),
                DateCreated = toDoRequestModel.DateCreated
            };

           await _toDosRepository.EditToDoItem(writeModel);

             
                

        }

       

       
    }
}
