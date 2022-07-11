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
    public class ManufacturersController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                List<ManuDTO> m = new List<ManuDTO>();
                m = db.Manufacturers.Select(x => new ManuDTO()
                {
                    Manufacturer = x.Manufacturer
                

                }).ToList();

                return Ok(m);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
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