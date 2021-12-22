namespace Persistence.Extensions
{
    public static class ToDosExtensions
    {
       /* public static ToDoReadModel MapToReadModel(this ToDoWriteModel model)
        {
            return new ToDoReadModel
            {
                Id = model.Id.ToString(),
                Title = model.Title,
                Description = model.Description,
                Difficulty = model.Difficulty,
                IsDone = model.IsDone,
                DateCreated = model.DateCreated
            };
        }*/


        //  NOT NECESSARY - MAPPING FROM WRITE TO READ MODEL IS DONE AT DOMAIN LEVEL -> NO NEED TO RETURN THE ACTUAL ENTRY TO DATABASE AS A READ MODEL
        //ONLY TASK IS DONE AT PERSISTENCE LEVEL
    }
}
