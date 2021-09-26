﻿using CommonLayer.Model.NotesModels;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INotesRL
    {
        bool CreateNotes(AddNotesModel model);

        IEnumerable<Notes> DisplayNotes();

        Notes Get(long Id);

        bool Delete(Notes notes);
    }
}
