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
    public class CoursesController : ControllerBase
    {

        private readonly ICoursesRepository _coursesRepository;
        
        public CoursesController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult> GetCourses()
        {
            var result = await _coursesRepository.GetCourses();
            return Ok(result);
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCourse(int id)
        {
            var result = await _coursesRepository.GetCourse(id); 
            return Ok(result);
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {            
            if (id != course.Id)
            {
                return BadRequest();
            }           

            try
            {
                await _coursesRepository.UpdateCourse(id,course);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCourse(Course course)
        {
            await _coursesRepository.AddCourse(course);

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {   
            var course = await _coursesRepository.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }

            await _coursesRepository.DeleteCourse(course);

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _coursesRepository.GetCourses().Result.Any(e => e.Id == id);
        }
    }
}
