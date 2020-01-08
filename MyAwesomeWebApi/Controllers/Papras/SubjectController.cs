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
    [Route("api/Subject")]
    [ApiController]
    public class SubjectController : Controller
    {

        private readonly SubjectService SubjectService;

        public SubjectController()
        {
            SubjectService = new SubjectService("awesomedatabase", "subjects", "mongodb://localhost:27017");

        }

        // GET api/Subject/getallSubjects
        [HttpGet("getallSubjects")]
        public async Task<ActionResult> getAllSubjects()
        {
            var allSubjects = await SubjectService.GetAllSubjects();
            return Ok(allSubjects);
        }

        // Get api/Subject/GetSubjectById/5
        [HttpGet("GetSubjectById/{id}")]
        public async Task<ActionResult<Subject>> GetSubjectById(String id)
        {
            return await SubjectService.GetSubjectById(id);
        }


        // PUT api/Subject/UpdateSubjectById/5
        [HttpPut("UpdateSubjectById/{id}")]
        public async Task<ActionResult> UpdateSubjectById(String id, [FromBody]Subject appSubject)
        {
            await SubjectService.UpdatesubjectbyId(id, appSubject);

            return NoContent();
        }

        // POST: api/Subject/AddSubject
        [HttpPost("AddSubject")]
        public async Task PostAsync([FromBody]Subject todo)
        {
            await SubjectService.InsertSubject(todo);
        }

        // Delete api/Subject/Delete/5
        [HttpDelete("Delete/{id:length(24)}")]
        public async Task<ActionResult> DeleteAsync(String id)
        {
            await SubjectService.Deletesubject(id);
            return NoContent();

        }

    }
}