using BusinessLayer.Interface;
using CommonLayer.Model.NotesModels;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NotesBL : INotesBL
    {
        private readonly INotesRL _notesRL;
        public NotesBL(INotesRL notesRL)
        {
            this._notesRL = notesRL;
        }


        public bool CreateNotes(AddNotesModel model)
        {
            return _notesRL.CreateNotes(model);
        }

        public bool Delete(Notes notes)
        {
            try
            {
                return this._notesRL.Delete(notes);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Notes> DisplayNotes()
        {
            try
            {
                return this._notesRL.DisplayNotes();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool EditNotes(EditNotesModel editNotesModel, long Id)
        {
            try
            {
                return this._notesRL.EditNotes(editNotesModel,Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Notes Get(long Id)
        {
            try
            {
                return this._notesRL.Get(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

