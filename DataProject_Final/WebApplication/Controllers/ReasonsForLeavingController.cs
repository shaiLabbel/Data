using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataProject_Final;
using WebApplication.DTO;

namespace WebApplication.Controllers
{
    public class ReasonsForLeavingController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                List<ReasonsLeavingDTO> r = new List<ReasonsLeavingDTO>();
                r = db.ReasonsForLeaving.Select(x => new ReasonsLeavingDTO()
                {
                    Number = x.Number,
                    Reason = x.Reason

                }).ToList();

                if (r != null)
                {
                    return Ok(r);
                }
                return BadRequest($" fail with get all reasons");



            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}