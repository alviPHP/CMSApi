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
    public class GradesController : ControllerBase
    {
        private readonly IGradesRepository _repository;

        public GradesController(IGradesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Grades
        [HttpGet]
        [Route("GetGrades")]
        public async Task<ActionResult> GetGrades()
        {
            var result =  await _repository.GetGrades();
            return Ok(result);
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGrade(int id)
        {
            var grade = await _repository.GetGrade(id);

            if (grade == null)
            {
                return NotFound();
            }

            return Ok(grade);
        }

        // PUT: api/Grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(int id, Grade grade)
        {
            if (id != grade.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UppdateGrade(id, grade);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
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

        // POST: api/Grades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostGrade(Grade grade)
        {
            
            await _repository.AddGrade(grade);
            return CreatedAtAction("GetGrade", new { id = grade.Id }, grade);
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var grade = await _repository.GetGrade(id);
            if (grade == null)
            {
                return NotFound();
            }

            await _repository.DeleteGrade(grade);

            return NoContent();
        }

        private bool GradeExists(int id)
        {
            return _repository.GetGrades().Result.Any(e => e.Id == id);
        }

        [HttpGet]
        [Route("GetGradesInfo")]
        public async Task<ActionResult> GetGradesInfo()
        {
            var result = await _repository.GetGradesInfo();
            return Ok(result);
        }


        [HttpGet]
        [Route("GetStudentsDataByCourseId/{id}")]
        public async Task<ActionResult> GetStudentsDataByCourseId(int id)
        {
            var result = await _repository.GetStudentsDataByCourseId(id);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetStudentsDataBySubjectId/{id}")]
        public async Task<ActionResult> GetStudentsDataBySubjectId(int id)
        {
            var result = await _repository.GetStudentsDataBySubjectId(id);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetMarkSheetByStudentId/{id}")]
        public async Task<ActionResult> GetMarkSheetByStudentId(int id)
        {
            var result = await _repository.GetMarkSheetByStudentId(id);
            return Ok(result);
        }

    }
}
