using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMSApi.Database;
using CMSApi.Model;
using CMSApi.IRepository;

namespace CMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _repository;

        public TeachersController(ITeacherRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult> GetTeachers()
        {
            var result = await _repository.GetTeachers();
            return Ok(result);
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTeacher(int id)
        {
            var teacher = await _repository.GetTeacher(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }


            try
            {
                await _repository.UpdateTeacher(id, teacher);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTeacher(Teacher teacher)
        {
            await _repository.AddTeacher(teacher);

            return CreatedAtAction("GetTeacher", new { id = teacher.Id }, teacher);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _repository.GetTeacher(id);
            if (teacher == null)
            {
                return NotFound();
            }

            await _repository.DeleteTeacher(teacher);

            return NoContent();
        }

        private bool TeacherExists(int id)
        {
            return _repository.GetTeachers().Result.Any(e => e.Id == id);
        }
    }
}
