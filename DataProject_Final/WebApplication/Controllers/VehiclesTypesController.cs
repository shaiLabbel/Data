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
    public class VehiclesTypesController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                List<VehicleTypeDTO> m = new List<VehicleTypeDTO>();
                m = db.Vehicles.Select(x => new VehicleTypeDTO()
                {
                    Type = x.Type


                }).ToList();

                return Ok(m);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
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