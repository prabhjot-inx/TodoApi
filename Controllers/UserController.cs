// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Repositories;



namespace TodoApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  private readonly IRepository<User> userRepository;
  public UserController(IRepository<User> userRepo)
  {
    userRepository = userRepo;
  }


  [HttpGet]
  public async Task<ActionResult<IEnumerable<User>>> GetUsers()
  {
    var users = await userRepository.GetAll();
    return Ok(users);
  }

  [HttpGet("{ID}")]
  public async Task<ActionResult<User>> GetByID(int ID)
  {
    var user = await userRepository.GetById(ID);
    return Ok(user);
  }

  [HttpPost]
  public async Task<ActionResult<User>> Create(User user)
  {
    User ur = userRepository.Add(user);
    return CreatedAtAction(nameof(GetByID), new { ID = ur.ID}, ur);
  }

  [HttpPut("{ID}")]
  public async Task<ActionResult<User>> Update(int ID, User user)
  {
    User ur = await userRepository.GetById(ID);
    if (ur == null)
    {
      return NotFound();
    }
    ur.Username = user.Username;
    ur.Password = user.Password;
    userRepository.Update(ur);
    return Ok(ur);
  }

  [HttpDelete("{ID}")]
  public async Task<ActionResult> Delete(int ID)
  {
    User ur = await userRepository.GetById(ID);
    if (ur == null)
    {
      return NotFound();
    }
    
    userRepository.Delete(ur);
    return NoContent();
  }
}

// namespace TodoApi.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class UserController : ControllerBase
//     {
//         private readonly IRepository<TodoItem> todoItemRepository;

//         public UserController(IRepository<TodoItem> todoItemRepo)
//         {
//             todoItemRepository = todoItemRepo;
//         }

//         // GET: api/TodoItems
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
//         {
//           if (_context.TodoItems == null)
//           {
//               return NotFound();
//           }
//             return await _context.TodoItems.ToListAsync();
//         }

//         // GET: api/TodoItems/5
//         [HttpGet("{id}")]
//         public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
//         {
//           if (_context.TodoItems == null)
//           {
//               return NotFound();
//           }
//             var todoItem = await _context.TodoItems.FindAsync(id);

//             if (todoItem == null)
//             {
//                 return NotFound();
//             }

//             return todoItem;
//         }

//         // PUT: api/TodoItems/5
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
//         {
//             if (id != todoItem.id)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(todoItem).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!TodoItemExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return NoContent();
//         }

//         // POST: api/TodoItems
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPost]
//         public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
//         {
//           if (_context.TodoItems == null)
//           {
//               return Problem("Entity set 'TodoContext.TodoItems'  is null.");
//           }
//             _context.TodoItems.Add(todoItem);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction("GetTodoItem", new { id = todoItem.id }, todoItem);
//         }

//         // DELETE: api/TodoItems/5
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteTodoItem(long id)
//         {
//             if (_context.TodoItems == null)
//             {
//                 return NotFound();
//             }
//             var todoItem = await _context.TodoItems.FindAsync(id);
//             if (todoItem == null)
//             {
//                 return NotFound();
//             }

//             _context.TodoItems.Remove(todoItem);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }

//         private bool TodoItemExists(long id)
//         {
//             return (_context.TodoItems?.Any(e => e.id == id)).GetValueOrDefault();
//         }
//     }
// }
