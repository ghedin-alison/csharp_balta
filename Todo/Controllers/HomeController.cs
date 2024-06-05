using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

//Pra Api dar preferência de herdar de ControllerBase
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Get([FromServices]AppDbContext context) 
        => Ok(context.Todos.ToList());

    [HttpGet("/{id:int}")]
    public IActionResult GetById(
        [FromRoute]int id,
        [FromServices]AppDbContext context)
    {
        var todo =  context.Todos.FirstOrDefault(x => x.Id == id);
        if (todo == null)
            return NotFound();
        return Ok(todo);
    }

    [HttpPost("/")]
    public IActionResult Post(
        [FromBody]TodoModel model,
        [FromServices]AppDbContext context)
    {
        context.Todos.Add(model);
        context.SaveChanges();
        return Created($"/{model.Id}", model);
    }
    

    [HttpPut("/{id:int}")]
    public IActionResult Put(
        [FromRoute]int id,
        [FromBody]TodoModel todo,
        [FromServices]AppDbContext context)
    {
        var model =  context.Todos.FirstOrDefault(x => x.Id == id);
        if (model is null)
            return NotFound();
        
        model.Title = todo.Title;
        model.Done = todo.Done;

        context.Todos.Update(model);
        context.SaveChanges();
        return Ok(model);
    }

    [HttpDelete("/{id:int}")]
    public IActionResult Delete(
        [FromRoute]int id,
        [FromServices]AppDbContext context)
    {
        var todo =  context.Todos.FirstOrDefault(x => x.Id == id);
        if (todo == null)
            return NotFound();
        
        context.Todos.Remove(todo);
        context.SaveChanges();
        return Ok(todo);
        
    }

}