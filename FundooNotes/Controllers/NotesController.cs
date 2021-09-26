using BusinessLayer.Interface;
using CommonLayer.Model.NotesModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{

    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {



        private readonly INotesBL _notesBL;

        public NotesController(INotesBL notesBL)
        {
            _notesBL = notesBL;

        }

        [HttpPost("createNotes")]
        public IActionResult CreateNotes(AddNotesModel model)
        {
            if (model == null)
            {
                return BadRequest("notes is empty.");
            }
            var result = _notesBL.CreateNotes(model);
            if (result == true)
            {
                return this.Ok(new { success = true, message = "Note Created Successfully" });
            }
            else
            {
                return this.BadRequest();
            }
        }

        // GET: api/user
        [HttpGet("DisplayNotes")]
        public IActionResult DisplayNotes()
        {
            IEnumerable<Notes> notes = _notesBL.DisplayNotes();
            return Ok(notes);
        }


        [HttpDelete("delete/{Id}")]
        public IActionResult DeleteNotes(long Id)
        {
            Notes notes = _notesBL.Get(Id);
            if (notes == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            var result = _notesBL.Delete(notes);

            if (result == true)
            {
                return this.Ok(new { success = true, message = "Notes Deleted Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Note Deletion Failed" });
            }
        }


    }
}
