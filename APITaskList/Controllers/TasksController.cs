using System.Linq;
using APITaskList.Data;
using Microsoft.AspNetCore.Mvc;
using APITaskList.Models;

namespace APITaskList.Controllers
{
    [Produces("application/json")]
    public class TasksController : Controller
    {
        private readonly DataContext _context;
        public TasksController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("v1/tasks")]
        public IActionResult Post([FromBody]Task task)
        {
            try
            {
                _context.Task.Add(task);
                _context.SaveChanges();

                return Ok();
            }
            catch (System.Exception ex)
            {
                return Json(new { Status = "Error", Message = ex.InnerException.Message });
            }
        }

        [HttpGet]
        [Route("v1/tasks")]
        public IActionResult Get()
        {
            return Ok(_context.Task.ToList());
        }

        [HttpGet]
        [Route("v1/tasks/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_context.Task.Find(id));
        }

        [HttpPut]
        [Route("v1/tasks/{id}")]
        public IActionResult Put(int id, [FromBody]Task task)
        {
            try
            {
                Task _task = _context.Task.Find(id);
                _task.Title = task.Title;
                _task.Detail = task.Detail;
                _task.Create_At = task.Create_At;
                _task.Update_At = task.Update_At;
                _task.Delete_At = task.Delete_At;
                _task.Done_At = task.Done_At;

                _context.Entry(_task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                return Ok();
            }
            catch (System.Exception ex)
            {
                return Json(new { Status = "Error", Message = ex.InnerException.Message });
            }
        }

        [HttpDelete]
        [Route("v1/tasks/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _context.Task.Remove(_context.Task.Find(id));
                _context.SaveChanges();

                return Ok();
            }
            catch (System.Exception ex)
            {
                return Json(new { Status = "Error", Message = ex.InnerException.Message });
            }
        }
    }
}