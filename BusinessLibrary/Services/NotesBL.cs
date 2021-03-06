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

       
        public bool AddRemainder(long Id, AddRemainderModel addReminderModel)
            {
                try
                {
                    return this._notesRL.AddRemainder(Id, addReminderModel);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        

        public bool ArchiveNote(long Id)
        {
            try
            {
                return this._notesRL.ArchiveNote(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool ChangeColor(long Id, ChangeColorModel changeColorModel)
        {
            try
            {
                return this._notesRL.ChangeColor(Id, changeColorModel);
            }
            catch (Exception ex)
            {
                throw;
            }
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
                return this._notesRL.EditNotes(editNotesModel, Id);
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

        public IEnumerable<Notes> NotesByCategory(string Category , long userId)
        {
            try
            {
                return this._notesRL.NotesByCategory(Category, userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool PinNote(long Id)
        {
            try
            {
                return this._notesRL.PinNote(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool TrashNote(long Id)
        {
            try
            {
                return this._notesRL.TrashNote(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

