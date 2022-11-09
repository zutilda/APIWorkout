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
using APIWorkout.Models;

namespace APIWorkout.Controllers
{
    public class ModelWorkoutsController : ApiController
    {
        private ZhulinaApiEntities db = new ZhulinaApiEntities();

        // GET: api/ModelWorkouts
        [ResponseType(typeof(List<ModelWorkout>))]
        public IHttpActionResult GetModelWorkouts()
        {
            return Ok(db.Workout.ToList().ConvertAll(x => new ModelWorkout(x)));
        }

        // GET: api/ModelWorkouts/5
        [ResponseType(typeof(ModelWorkout))]
        public IHttpActionResult GetModelWorkout(int id)
        {
            ModelWorkout modelWorkout = db.ModelWorkouts.Find(id);
            if (modelWorkout == null)
            {
                return NotFound();
            }

            return Ok(modelWorkout);
        }

        // PUT: api/ModelWorkouts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModelWorkout(int id, ModelWorkout modelWorkout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelWorkout.id)
            {
                return BadRequest();
            }

            db.Entry(modelWorkout).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelWorkoutExists(id))
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

        // POST: api/ModelWorkouts
        [ResponseType(typeof(ModelWorkout))]
        public IHttpActionResult PostModelWorkout(ModelWorkout modelWorkout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ModelWorkouts.Add(modelWorkout);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = modelWorkout.id }, modelWorkout);
        }

        // DELETE: api/ModelWorkouts/5
        [ResponseType(typeof(ModelWorkout))]
        public IHttpActionResult DeleteModelWorkout(int id)
        {
            ModelWorkout modelWorkout = db.ModelWorkouts.Find(id);
            if (modelWorkout == null)
            {
                return NotFound();
            }

            db.ModelWorkouts.Remove(modelWorkout);
            db.SaveChanges();

            return Ok(modelWorkout);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelWorkoutExists(int id)
        {
            return db.ModelWorkouts.Count(e => e.id == id) > 0;
        }
    }
}