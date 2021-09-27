using BusinessLayer.Interface;
using CommonLayer.Model.NotesModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{

    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public static IConfiguration _config;
        private readonly INotesBL _notesBL;

        public NotesController(INotesBL notesBL)
        {
            _notesBL = notesBL;

        }

        //Create Notes
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

        //Display Notes
        // GET: api/user
        [HttpGet("DisplayNotes")]
        public IActionResult DisplayNotes()
        {
            IEnumerable<Notes> notes = _notesBL.DisplayNotes();
            return Ok(notes);
        }


        //Delete Notes
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
        //Generate JWT token
        private static string GenerateJwtToken(long Id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim("Id", Id.ToString()));
         

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              permClaims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //Get Token
        [HttpGet("getTokenId")]
        public long GetTokenId()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }

        //Edit Notes
        [HttpPut("Edit/{Id}")]
        public IActionResult EditNotes(EditNotesModel editNotesModel, long Id)
        {
           
            var result = _notesBL.EditNotes(editNotesModel, Id);
            if (result == true)
            {
                return this.Ok(new { success = true, message = "Notes Edited Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Note Edition Failed" });
            }
        }


       


    }
}
