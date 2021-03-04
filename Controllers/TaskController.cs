using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Missioner.Models;


namespace Missioner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly MissionerDbContext _context;

        public TaskController(MissionerDbContext context)
        {
           _context = context;
        }

       [HttpGet]
        public IEnumerable<Task> GetTasks()
        {
            return _context.Tasks.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Task> GetTaskById(int id)
        {
            var task = _context.Tasks.FirstOrDefault(task => task.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return new ObjectResult(task);
        }
       
    }
}
