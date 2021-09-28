using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model.NotesModels
{
    public class EditNotesModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
       
    }
}
