using CommonLayer.Model.NotesModels;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface INotesBL
    {
        bool CreateNotes(AddNotesModel model);

        IEnumerable<Notes> DisplayNotes();

        Notes Get(long Id);

        bool Delete(Notes notes);

        bool EditNotes(EditNotesModel editNotesModel, long Id);

        bool ArchiveNote(long Id);

        bool ChangeColor(long Id, ChangeColorModel changeColorModel);

        bool TrashNote(long Id);

        bool PinNote(long Id);

        IEnumerable<Notes> NotesByCategory( string Category, long userId);

        bool AddRemainder(long Id, AddRemainderModel addReminderModel);
    }
}
