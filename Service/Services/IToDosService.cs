using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IToDosService
    {
        Task<ToDoResponseModel> GetById(Guid id);
        Task<IEnumerable<ToDoResponseModel>> GetAll();
        Task<ToDoResponseModel> AddToDoItem (ToDoRequestModel toDoWriteModel);
        Task EditToDoItem(ToDoRequestModel toDoRequestModel);
        Task DeleteToDoItem(Guid id);
        Task DeleteAll();

    }
}
