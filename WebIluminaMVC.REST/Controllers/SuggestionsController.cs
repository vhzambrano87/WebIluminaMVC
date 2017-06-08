using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebIluminaMVC.DataAccess;
using WebIluminaMVC.Model;

namespace WebIluminaMVC.REST.Controllers
{
    public class SuggestionsController : ApiController
    {
        private IluminaContext db = new IluminaContext();

        // GET: api/Suggestions
        public IQueryable<Suggestion> GetSuggestion()
        {
            return db.Suggestion;
        }

        // GET: api/Suggestions/5
        [ResponseType(typeof(Suggestion))]
        public IHttpActionResult GetSuggestion(int id)
        {
            Suggestion suggestion = db.Suggestion.Find(id);
            if (suggestion == null)
            {
                return NotFound();
            }

            return Ok(suggestion);
        }

        // PUT: api/Suggestions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuggestion(int id, Suggestion suggestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suggestion.suggestionID)
            {
                return BadRequest();
            }

            db.Entry(suggestion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuggestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Suggestions
        [ResponseType(typeof(Suggestion))]
        public IHttpActionResult PostSuggestion(Suggestion suggestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suggestion.Add(suggestion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = suggestion.suggestionID }, suggestion);
        }

        // DELETE: api/Suggestions/5
        [ResponseType(typeof(Suggestion))]
        public IHttpActionResult DeleteSuggestion(int id)
        {
            Suggestion suggestion = db.Suggestion.Find(id);
            if (suggestion == null)
            {
                return NotFound();
            }

            db.Suggestion.Remove(suggestion);
            db.SaveChanges();

            return Ok(suggestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuggestionExists(int id)
        {
            return db.Suggestion.Count(e => e.suggestionID == id) > 0;
        }
    }
}