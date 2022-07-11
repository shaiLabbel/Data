using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataProject_Final;

namespace WebApplication.Controllers
{
    public class DeletedVehiclesController : ApiController
    { // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] DeletedVehicles value)
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                ReasonsDeleteVehicles r = db.ReasonsDeleteVehicles.Single(i => i.Reason == value.Reason);
                int num = r.Number;
                value.NumberReason = num;
                value.DeletionDate = DateTime.Today;
                db.DeletedVehicles.Add(value);
                db.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}