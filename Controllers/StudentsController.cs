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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentsController(IStudentRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            var result = await _repository.GetStudents();
            return Ok(result);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudent(int id)
        {
            var student = await _repository.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UpdateStudent(id, student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostStudent(Student student)
        {            
            await _repository.AddStudent(student);
            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _repository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            await _repository.DeleteStudent(student);

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _repository.GetStudents().Result.Any(e => e.Id == id);
        }
       
    }
}
