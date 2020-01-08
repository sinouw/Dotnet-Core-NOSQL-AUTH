using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAwesomeWebApi.Models.Papras;
using MyAwesomeWebApi.Services;

namespace MyAwesomeWebApi.Controllers.Papras
{
    [Route("api/Classroom")]
    [ApiController]
    public class ClassroomController : Controller
    {

        private readonly ClassroomService classroomService;

        public ClassroomController()
        {
            classroomService = new ClassroomService("awesomedatabase", "classrooms", "mongodb://localhost:27017");

        }

        // GET api/Classroom/getallClassrooms
        [HttpGet]
        public async Task<ActionResult> getAllClassrooms()
        {
            var allClassrooms = await classroomService.GetAllclassrooms();
            return Ok(allClassrooms);
        }

        // Get api/Classroom/GetClassroomById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classroom>> GetClassroomById(String id)
        {
            return await classroomService.GetclassroomById(id);
        }


        // PUT api/Classroom/UpdateClassroomById/5
        [HttpPut("UpdateClassroomById/{id}")]
        public async Task<ActionResult> UpdateClassroomById(String id, [FromBody]Classroom appClassroom)
        {
            await classroomService.UpdateclassroombyId(id, appClassroom);

            return NoContent();
        }

        // POST: api/Classroom/addClassroom
        [HttpPost]
        public async Task PostAsync([FromBody]Classroom todo)
        {
            await classroomService.InsertClassroom(todo);
        }

        // Delete api/Classroom/DeleteAsync/5
        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> DeleteAsync(String id)
        {
            await classroomService.Deleteclassroom(id);
            return NoContent();

        }
    }
}