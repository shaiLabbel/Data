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
    public class PickUpController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                List <PickUpDTO> p = new List <PickUpDTO> ();
                p = db.PickUps.Select(x => new PickUpDTO()
                {
                    OrderNumber = (int)x.OrderNumber,
                 PickUpNumber = x.PickUpNumber,
                    CollectionPoint = x.CollectionPoint,
                    CollectionTime = (TimeSpan)x.CollectionTime,
                    Destination = x.Destination
                }).Where(x => x.OrderNumber == id).ToList();

                if (p != null)
                {
                    return Ok(p);
                }
                return BadRequest($" pick up in order number: {id} was not found");

                
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        // POST api/<controller>
        public IHttpActionResult Post([FromBody] PickUps value)
        {
            try
            {

                FinalProjDbContext db = new FinalProjDbContext();
                db.PickUps.Add(value);
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