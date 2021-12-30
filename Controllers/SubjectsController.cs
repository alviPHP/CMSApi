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
    public class SubjectsController : ControllerBase
    {
        private  ISubjectRepository _repository;

        public SubjectsController(ISubjectRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult> GetSubjects()
        {
            var result = await _repository.GetSubjects();
            return Ok(result);
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSubject(int id)
        {
            var subject = await _repository.GetSubject(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, Subject subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }            

            try
            {
                await _repository.UpdateSubject(id, subject);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
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

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostSubject(Subject subject)
        {
            await _repository.AddSubject(subject);

            return CreatedAtAction("GetSubject", new { id = subject.Id }, subject);
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _repository.GetSubject(id);
            if (subject == null)
            {
                return NotFound();
            }

            await _repository.DeleteSubject(subject);

            return NoContent();
        }

        private bool SubjectExists(int id)
        {
            var subjects = _repository.GetSubjects();
            return subjects.Result.Any(e => e.Id == id);
        }

       [HttpGet]
       [Route("GetSubjectsByCourseId/{id}")]
        public async Task<ActionResult> GetSubjectsByCourseId(int id)
        {
            
            var result = await _repository.GetSubjectsByCourseId(id);
            return Ok(result);
        }
    }
}
