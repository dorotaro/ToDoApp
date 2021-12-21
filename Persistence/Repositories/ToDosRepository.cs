using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Persistence
{
    public class ToDosRepository : IToDosRepository
    {
        private readonly ISqlClient _sqlClient;
        private readonly string tableName = "todosrepository";

        public ToDosRepository(ISqlClient sqlClient)
        {
            _sqlClient = sqlClient;
        }

    

        public async Task<IEnumerable<ToDoReadModel>> GetAll()
        {
            var query = $"SELECT * FROM {tableName}";

           var todos = await _sqlClient.Query<ToDoReadModel>(query);

            return todos;
        }

        public async Task AddToDoItem(ToDoWriteModel toDoWriteModel)
        {
            var query = $"INSERT INTO {tableName} " +
                        $"(Id, Title, Description, Difficulty, DateCreated)" +
                        $"VALUES (@Id, @Title, @Description, @Difficulty, @DateCreated); ";

            var param = new ToDoWriteModel
            {
                Id = toDoWriteModel.Id,
                Title = toDoWriteModel.Title,
                Description = toDoWriteModel.Description,
                Difficulty = toDoWriteModel.Difficulty,
                DateCreated = toDoWriteModel.DateCreated,
            };

             await _sqlClient.Execute<ToDoReadModel>(query, param);

            

            //return ToReadModel(param);
        }

        public async Task EditToDoItem(ToDoWriteModel toDoWriteModel)
        {
            //var toDo = await GetById(id);

            var query = $"UPDATE {tableName} " +
                        $"SET Title=@Title, Description=@Description, Difficulty=@Difficulty" +
                        $" WHERE Id=@Id";

            var param = new
            {
                Id = toDoWriteModel.Id,
                Title = toDoWriteModel.Title,
                Description = toDoWriteModel.Description,
                Difficulty = toDoWriteModel.Difficulty,
                DateCreated = toDoWriteModel.DateCreated,
            };

            await _sqlClient.Execute<ToDoWriteModel>(query, param);



        }

        public async Task DeleteToDoItem(Guid id)
        {
            var query = $"DELETE FROM {tableName} WHERE Id=@id";

            var param = new { Id = id };

             await _sqlClient.Execute<ToDoReadModel>(query, param);

            
        }

        public async Task DeleteAll()
        {
            var query = $"DELETE FROM {tableName}";

            await _sqlClient.Execute<ToDoReadModel>(query);
        }

        public async Task<ToDoReadModel> GetById(Guid Id)
        {

            var query = $"SELECT * FROM {tableName} WHERE Id=@id";

            var param = new {id = Id};

            var todos = await _sqlClient.Query<ToDoReadModel>(query, param);

            return todos.First();
           
        }
    }
}
