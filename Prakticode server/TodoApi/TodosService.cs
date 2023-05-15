using TodoApi;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Web;

class TodosService
{
    private ToDoDbContext database;
    
    public TodosService(ToDoDbContext db){
       database=db;
    }
    
    public async Task<DbSet<Item>> GetAll()
    {
        return database.Items;
    }
    public  async Task<Microsoft.AspNetCore.Http.IResult> Post(Item todo)
   {
      var todoItem = await database.Items.FindAsync(todo.Id);
        if (todoItem == null)
        {
          database.Items.Add(todo);
          await database.SaveChangesAsync();
          return Results.Ok(todo);
        }
     
        return Results.Conflict<string>("This ID already exists");
  
   }


    public  async Task<Microsoft.AspNetCore.Http.IResult> Update(int id,Item todo)
   {
    if (id != todo.Id)
        {
            return Results.BadRequest<string>("The submitted IDs do not match");
        }
      if( await database.Items.FindAsync(id) is not Item item)
          return Results.NotFound("This ID not exists");
      item.IsComplete=todo.IsComplete;
      await database.SaveChangesAsync();
      return Results.Ok();
   }
     public  async Task<Microsoft.AspNetCore.Http.IResult> Delete(int id)
     {
        if(await database.Items.FindAsync(id) is Item item)
          {
            database.Items.Remove(item);
            await database.SaveChangesAsync();
            return Results.Ok(item);
          }
        else
          return Results.NotFound("This ID not exists");
      }
}
