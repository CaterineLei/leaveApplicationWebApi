using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LeaveApplication.Models;

namespace LeaveApplication.Controllers
{
    public class LeaveApplicationFormsController : ApiController
    {
        private LeaveApplicationContext db = new LeaveApplicationContext();

        // GET: api/LeaveApplicationForms
        public IQueryable<LeaveApplicationForm> GetLeaveApplicationForms()
        {
            return db.LeaveApplicationForms;
        }

        // GET: api/LeaveApplicationForms/5
        [ResponseType(typeof(LeaveApplicationForm))]
        public async Task<IHttpActionResult> GetLeaveApplicationForm(int id)
        {
            LeaveApplicationForm leaveApplicationForm = await db.LeaveApplicationForms.FindAsync(id);
            if (leaveApplicationForm == null)
            {
                return NotFound();
            }

            return Ok(leaveApplicationForm);
        }

        // PUT: api/LeaveApplicationForms/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLeaveApplicationForm(int id, LeaveApplicationForm leaveApplicationForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leaveApplicationForm.Id)
            {
                return BadRequest();
            }

            db.Entry(leaveApplicationForm).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveApplicationFormExists(id))
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

        // POST: api/LeaveApplicationForms
        [ResponseType(typeof(LeaveApplicationForm))]
        public async Task<IHttpActionResult> PostLeaveApplicationForm(LeaveApplicationForm leaveApplicationForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LeaveApplicationForms.Add(leaveApplicationForm);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = leaveApplicationForm.Id }, leaveApplicationForm);
           // return Ok(leaveApplicationForm);
        }

        // DELETE: api/LeaveApplicationForms/5
        [ResponseType(typeof(LeaveApplicationForm))]
        public async Task<IHttpActionResult> DeleteLeaveApplicationForm(int id)
        {
            LeaveApplicationForm leaveApplicationForm = await db.LeaveApplicationForms.FindAsync(id);
            if (leaveApplicationForm == null)
            {
                return NotFound();
            }

            db.LeaveApplicationForms.Remove(leaveApplicationForm);
            await db.SaveChangesAsync();

            return Ok(leaveApplicationForm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeaveApplicationFormExists(int id)
        {
            return db.LeaveApplicationForms.Count(e => e.Id == id) > 0;
        }
    }
}