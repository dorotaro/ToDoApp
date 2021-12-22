using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IToDosRepository
    {
        Task<ToDoReadModel> GetById (Guid Id);
        Task<IEnumerable<ToDoReadModel>> GetAll();
        Task AddToDoItem  (ToDoWriteModel toDoWriteModel);
        Task EditToDoItem(ToDoWriteModel toDoWriteModel);
        Task DeleteToDoItem(Guid id);
        Task DeleteAll();
    }
}
