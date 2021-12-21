using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI_ToDoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDosController : ControllerBase
    {
        private readonly IToDosService _toDosService;

        public ToDosController(IToDosService toDosService)
        {
            _toDosService = toDosService;
        }

        [HttpGet]
        [Route("api/[controller]/GetById")]
        public async Task<ToDoResponseModel> GetById(Guid id)
        {
            return await _toDosService.GetById(id);
        }

        [HttpGet]
        [Route("api/[controller]/GetAll")]
        public async Task<IEnumerable<ToDoResponseModel>> GetAll()
        {
            return await _toDosService.GetAll();
        }


        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult> AddToDoItem(string title, string description, Difficulty difficulty)
        {
            var model = new ToDoRequestModel
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                Difficulty = difficulty,
                DateCreated = DateTime.Now
            };

            await _toDosService.AddToDoItem(model);

            return Ok();

        }


        [HttpDelete]
        [Route("api/[controller]/DeleteById")]
        public async Task<ActionResult> DeleteTodoItem(Guid id)
        {
            await _toDosService.DeleteToDoItem(id);

            return Ok();

        }

        [HttpDelete]
        [Route("api/[controller]/DeleteAll")]
        public async Task<ActionResult> DeleteAll()
        {
            await _toDosService.DeleteAll();

            return Ok();

        }


        [HttpPut]
        [Route("api/[controller]/EditById")]
        public async Task<ActionResult> EditToDoItem(Guid id, string newTitle, string newDescription, Difficulty newDifficulty)
        {
            var toDo = await GetById(id);

            var editedToDo = new ToDoRequestModel
            {
                Id = toDo.Id,
                Title = newTitle,
                Description = newDescription,
                Difficulty = newDifficulty,
                DateCreated = toDo.DateCreated
            };

            await _toDosService.EditToDoItem(editedToDo);

            return Ok();
        }
    }
}

