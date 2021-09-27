﻿using CommonLayer.Model.NotesModels;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL
    {
        readonly UserContext _userContext;
        public NotesRL(UserContext context)
        {
            _userContext = context;
        }

        public bool ArchiveNote(long Id)
        {
            Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id);
            if (notes.IsArchive == false)
            {

                notes.IsArchive = true;

            }
            else
            {

                notes.IsArchive = false;

            }
            _userContext.Notes.Update(notes);
            int result = _userContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangeColor(long Id, ChangeColorModel changeColorModel)
        {
            Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id);
            notes.Color = changeColorModel.Color;


            _userContext.Notes.Update(notes);
            int result = _userContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      

        public bool CreateNotes(AddNotesModel model)
        {

            Notes notesEntity = new Notes();
            notesEntity.Id = model.Id;
            notesEntity.Title = model.Title;
            notesEntity.Message = model.Message;
            notesEntity.Image = model.Image;
            notesEntity.Color = model.Color;
            notesEntity.IsPin = model.IsPin;
            notesEntity.CreatedDate = model.CreatedDate;
            notesEntity.ModifiedDate = model.ModifiedDate;
            notesEntity.AddReminder = model.AddReminder;
            notesEntity.UserId = model.UserId;
            notesEntity.IsArchive = model.IsArchive;
            notesEntity.IsNote = model.IsNote;
            notesEntity.IsTrash = model.IsTrash;
            _userContext.Notes.Add(notesEntity);
            int result = _userContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Delete(Notes notes)
        {
            _userContext.Notes.Remove(notes);
            var result = _userContext.SaveChanges();

            if (result > 0)
            {
                return true;

            }

            else
            {
                return false;
            }
        }
    

    public IEnumerable<Notes> DisplayNotes()
        {
            return _userContext.Notes.ToList();
        }

        public bool EditNotes(EditNotesModel editNotesModel, long Id)
        {
            Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id);
            try
            {
                notes.Title = editNotesModel.Title;
                notes.Message = editNotesModel.Message;
                notes.Image = editNotesModel.Image;
                notes.Color = editNotesModel.Color;
                notes.ModifiedDate = editNotesModel.ModifiedDate;
                _userContext.Notes.Update(notes);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Notes Get(long Id)
        {
           return _userContext.Notes.FirstOrDefault(e => e.Id == Id);
            
        }

        public bool PinNote(long Id)
        {
            Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id);
            if (notes.IsPin == false)
            {

                notes.IsPin = true;

            }
            else
            {

                notes.IsPin = false;

            }
            _userContext.Notes.Update(notes);
            int result = _userContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TrashNote(long Id)
        {
            Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id);
            if (notes.IsTrash == false)
            {

                notes.IsTrash = true;

            }
            else
            {

                notes.IsTrash = false;

            }
            _userContext.Notes.Update(notes);
            int result = _userContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
