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
    public class CourseSubjectTeachersController : ControllerBase
    {
        private readonly ICourseTeacherSubjectRepository _repository;

        public CourseSubjectTeachersController(ICourseTeacherSubjectRepository repository)
        {
            _repository = repository;
        }

        // GET: api/CourseSubjectTeachers
        [HttpGet]
        [Route("GetCoursesSubjectsTeachers")]
        public async Task<ActionResult> GetCoursesSubjectsTeachers()
        {
            var result = await _repository.GetCoursesSubjectsTeachers();
            return Ok(result);
        }

        // GET: api/CourseSubjectTeachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCourseSubjectTeacher(int id)
        {
            var courseSubjectTeacher = await _repository.GetCourseSubjectTeacher(id);

            if (courseSubjectTeacher == null)
            {
                return NotFound();
            }

            return Ok(courseSubjectTeacher);
        }

        // PUT: api/CourseSubjectTeachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseSubjectTeacher(int id, CourseSubjectTeacher courseSubjectTeacher)
        {
            if (id != courseSubjectTeacher.Id)
            {
                return BadRequest();
            }            

            try
            {
                await _repository.UpdateCourseSubjectTeacher(id, courseSubjectTeacher);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseSubjectTeacherExists(id))
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

        // POST: api/CourseSubjectTeachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostCourseSubjectTeacher(CourseSubjectTeacher courseSubjectTeacher)
        {
            await _repository.AddCourseSubjectTeacher(courseSubjectTeacher);

            return CreatedAtAction("GetCourseSubjectTeacher", new { id = courseSubjectTeacher.Id }, courseSubjectTeacher);
        }

        // DELETE: api/CourseSubjectTeachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseSubjectTeacher(int id)
        {
            var courseSubjectTeacher = await _repository.GetCourseSubjectTeacher(id);
            if (courseSubjectTeacher == null)
            {
                return NotFound();
            }

            await _repository.DeleteCourseSubjectTeacher(courseSubjectTeacher);

            return NoContent();
        }

        private bool CourseSubjectTeacherExists(int id)
        {
            return _repository.GetCoursesSubjectsTeachers().Result.Any(e => e.Id == id);
        }

        [HttpGet]
        [Route("GetCourseDesignInfo")]
        public async Task<ActionResult> GetCourseDesignInfo()
        {
            var result = await _repository.GetCourseDesignInfo();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetTeachersDataByCourseId/{id}")]
        public async Task<ActionResult> GetTeachersDataByCourseId(int id)
        {
            var result = await _repository.GetTeachersDataByCourseId(id);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetTeachersDataBySubjectId/{id}")]
        public async Task<ActionResult> GetTeachersDataBySubjectId(int id)
        {
            var result = await _repository.GetTeachersDataBySubjectId(id);
            return Ok(result);
        }


        [HttpGet("details")]        
        public int GetCompositeKeyId(int courseId, int subjectId)
        {
            return _repository.GetCompositeKeyId(courseId, subjectId);
        }

    }
}
