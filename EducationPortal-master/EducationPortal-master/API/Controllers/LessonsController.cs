using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private ILessonService LessonService { get; }
        public LessonsController(ILessonService lessonService)
        {
            LessonService = lessonService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Lesson lesson)
        {
            var result = LessonService.Add(lesson);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] Lesson lesson)
        {
            var result = LessonService.Delete(lesson);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Lesson lesson)
        {
            var result = LessonService.Update(lesson);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-lessons")]
        public IActionResult GetLessons()
        {
            var result = LessonService.GetLessons();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-by-lesson-id/{lessonId}")]
        public IActionResult GetByLessonId(int lessonId)
        {
            var result = LessonService.GetByLessonId(lessonId);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
