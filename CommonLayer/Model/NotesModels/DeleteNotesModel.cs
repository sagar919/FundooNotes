using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model.NotesModels
{
    public class DeleteNotesModel
    {
        [Required]
        public int Id { get; set; }
      
    }
}
