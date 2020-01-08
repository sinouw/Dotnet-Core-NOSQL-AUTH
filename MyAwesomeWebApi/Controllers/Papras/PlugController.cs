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
    [Route("api/Plug")]
    [ApiController]
    public class PlugController : Controller
    {

        private readonly PlugService PlugService;

        public PlugController()
        {
            PlugService = new PlugService("awesomedatabase", "plugs", "mongodb://localhost:27017");

        }

        // GET api/Plug/getallPlugs
        [HttpGet("getallPlugs")]
        public async Task<ActionResult> getAllPlugs()
        {
            var allPlugs = await PlugService.GetAllPlugs();
            return Ok(allPlugs);
        }

        // Get api/Plug/GetPlugById/5
        [HttpGet("GetPlugById/{id}")]
        public async Task<ActionResult<Plug>> GetPlugById(String id)
        {
            return await PlugService.GetPlugById(id);
        }


        // PUT api/Plug/UpdatePlugById/5
        [HttpPut("UpdatePlugById/{id}")]
        public async Task<ActionResult> UpdatePlugById(String id, [FromBody]Plug appPlug)
        {
            await PlugService.UpdatePlugbyId(id, appPlug);

            return NoContent();
        }

        // POST: api/Plug/AddPlug
        [HttpPost("AddPlug")]
        public async Task PostAsync([FromBody]Plug todo)
        {
            await PlugService.InsertPlug(todo);
        }

        // Delete api/Plug/Delete/5
        [HttpDelete("Delete/{id:length(24)}")]
        public async Task<ActionResult> DeleteAsync(String id)
        {
            await PlugService.DeletePlug(id);
            return NoContent();

        }
    }
}