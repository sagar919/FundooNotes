using BusinessLayer.Interface;
using CommonLayer.Model.NotesModels;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class NotesController : ControllerBase
    {
        public static IConfiguration _config;
        private readonly INotesBL _notesBL;

        public NotesController(INotesBL notesBL)
        {
            _notesBL = notesBL;

        }

        //Create Notes
        [HttpPost]
        public IActionResult CreateNotes(AddNotesModel model)
        {
            try
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
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        //Display Notes
        // GET: api/user
        [HttpGet]
        public IActionResult DisplayNotes()
        {
            try
            {
                IEnumerable<Notes> notes = _notesBL.DisplayNotes();
                return Ok(notes);
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }


        //Delete Notes
        [HttpDelete("{Id}/delete")]
        public IActionResult DeleteNotes(long Id)
        {
            try
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
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
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
        private long GetTokenId()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }

        //Edit Notes
        [HttpPut("{Id}/Edit")]
        public IActionResult EditNotes(EditNotesModel editNotesModel, long Id)
        {

            try
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
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }


        // Archive Notes
        [HttpPut("{Id}/archive")]
        public IActionResult ArchiveNote(long Id)
        {
            try
            {
                var result = _notesBL.ArchiveNote(Id);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "IsArchive function successfull" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "IsArchive function unsuccessfull" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        // Change Color
        [HttpPut("color/{Id}")]
        public IActionResult ChangeColor(long Id, ChangeColorModel changeColorModel)
        {
            try
            {
                var result = _notesBL.ChangeColor(Id, changeColorModel);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Color change successfully completed" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Color Change unsuccessfull" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        // Change isTrash status
        [HttpPut("Trash/{Id}")]
        public IActionResult TrashNote(long Id)
        {
            try
            {
                var result = _notesBL.TrashNote(Id);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "IsTarsh successfull" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "IsTrash unsuccessfull" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        // Change isPin status
        [HttpPut("Pin/{Id}")]
        public IActionResult PinNote(long Id)
        {
            try
            {
                var result = _notesBL.PinNote(Id);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "IsPin successfull" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "IsPin unsuccessfull" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        //Get Notes by category
        [HttpGet("{Category}")]
        public IActionResult NotesByCategory(string Category)
        {
            try
            {
                long userId = GetTokenId();
                IEnumerable<Notes> Notes = _notesBL.NotesByCategory(Category, userId);
                return Ok(Notes);
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        //Add reminder
        [HttpPut("{Id}/addreminder")]
        public IActionResult AddReminder(long Id, AddRemainderModel addReminderModel)
        {
            try
            {
                var result = _notesBL.AddRemainder(Id, addReminderModel);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Reminder Added Successfully " });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Reminder adding unsuccessfull" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }



    }
}
