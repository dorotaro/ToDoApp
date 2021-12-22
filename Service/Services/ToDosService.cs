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

        public async Task<ToDoResponseModel> AddToDoItem(ToDoRequestModel toDoRequestModel)
        {

            //business logic is here - mapping to response model,
            //and return to controller is only from this layer (not from persistence - that would be excessive)

            var model = toDoRequestModel.MapToWriteModel();
            
            await _toDosRepository.AddToDoItem(model);

            return toDoRequestModel.MapToResponseModel();

        }
        public async Task<ToDoResponseModel> GetById(Guid id)
        {
           var model =  await _toDosRepository.GetById(id);

           var responseModel = model.MapToResponseModel();

           return responseModel;
        }

        public async Task<IEnumerable<ToDoResponseModel>> GetAll()
        {
            var models = await _toDosRepository.GetAll();

            var responseModels = new List<ToDoResponseModel>();

            foreach (var model in models) //foreach through ienumerable - why is this possible in this case?
            {
                responseModels.Add(model.MapToResponseModel());
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
            var writeModel = toDoRequestModel.MapToWriteModel();

           await _toDosRepository.EditToDoItem(writeModel);

             
                

        }

       

       
    }
}
