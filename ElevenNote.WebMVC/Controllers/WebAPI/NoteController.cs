using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebMVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Note")]
    public class NoteController : ApiController
    {
        private bool SetStarState(int noteId, bool newState)
        {
            //Create service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);

            //Get note
            var detail = service.GetNoteById(noteId);

            //Create NoteEdit model instance /w new star state
            var updatedNote = new NoteEdit
            {
                NoteID = detail.NoteID,
                Title = detail.Title,
                Content = detail.Content,
                IsStarred = newState
            };

            //Say if it succeeded or nah
            return service.UpdateNote(updatedNote);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}
