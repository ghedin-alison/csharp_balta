using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

[ApiController]
public class HomeController: ControllerBase
{
    //Get all
    [HttpGet] //Métodos dentro de controllers podem ser chamados de action
    [Route("/")]
    public IActionResult Get([FromServices] AppDbContext context)
        =>  Ok(context.Todos.ToList());
    
    //Get one
    [HttpGet] //Métodos dentro de controllers podem ser chamados de action
    [Route("/{id:int}")]
    public IActionResult GetById([FromRoute]int id, [FromServices] AppDbContext context)
    {
        var todos = context.Todos.FirstOrDefault(x => x.Id == id);
        if (todos == null)
            return NotFound();
        return Ok(todos);
    }
    
    //Post
    [HttpPost]
    [Route("/")]
    public IActionResult Post([FromBody]TodoModel todo,
                          [FromServices] AppDbContext context)
    {
        context.Todos.Add(todo);
        context.SaveChanges();
        return Created($"/{todo.Id}", todo);
    }
    
    //Put
    [HttpPut]
    [Route("/{id:int}")]
    public IActionResult Put(
        [FromRoute] int id,
        [FromBody]TodoModel todo,
        [FromServices] AppDbContext context)
    {
        var model = context.Todos.FirstOrDefault(x => x.Id == id);
        if(model == null) 
            return NotFound();
        
        model.Title = todo.Title;
        model.Done = todo.Done;
        model.CreateAt = todo.CreateAt;
            
        context.Todos.Update(model);
        context.SaveChanges();
        return Ok(model);
    }
    
    //Delete
    [HttpDelete] //Métodos dentro de controllers podem ser chamados de action
    [Route("/{id:int}")]
    public IActionResult Delete([FromRoute]int id, [FromServices] AppDbContext context)
    {
        var model = context.Todos.FirstOrDefault(x => x.Id == id);
        if (model == null)
            return NotFound();
        context.Todos.Remove(model);
        context.SaveChanges();
        
        return Ok(model);
    }

}