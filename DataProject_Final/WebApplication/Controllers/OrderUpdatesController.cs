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
    public class OrderUpdatesController : ApiController
    {
        // GET api/<controller>
 
        public IHttpActionResult Get()
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                OrderUpdates[] updates = db.OrderUpdates.ToArray();
                List<UpdatesDTO> ol = new List<UpdatesDTO>();
                foreach (OrderUpdates i in updates)
                {
                    UpdatesDTO x = new UpdatesDTO();
                    x.UpdateId = i.UpdateId;
                    x.Date = i.Date;
                    x.Time = i.Time;
                    x.OrderNumber = (int)i.OrderNumber;
                    x.ContactName = i.Orders.ContactName;
                    x.OrderDate = i.Orders.Date;
                    x.OrderStatus = i.Orders.OrderStatus1.StatusName;
                    x.Bid =i.Orders.Bid;
                    x.StatusNumber = i.Orders.OrderStatus;
                    x.Points = i.Orders.PickUps.Select(p => new PickUpDTO()
                    {
                        PickUpNumber = p.PickUpNumber,
                        CollectionPoint = p.CollectionPoint,
                        CollectionTime = (TimeSpan)p.CollectionTime,
                        Destination = p.Destination

                    }).ToList();

                    ol.Add(x);
                }

                return Ok(ol);
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
        public IHttpActionResult Post([FromBody] OrderUpdates value)
        {
            try
            {
                if (value.OrderNumber!=null)
                {
                    FinalProjDbContext db = new FinalProjDbContext();
                    value.Date = DateTime.Today;
                    value.Time = DateTime.Now.TimeOfDay;
                    db.OrderUpdates.Add(value);
                    db.SaveChanges();
                    return Ok(value);
                }
                else
                {
                    return BadRequest($"order updets number: was not found");
                }

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
        public IHttpActionResult Delete(int id)
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                OrderUpdates o = db.OrderUpdates.SingleOrDefault(i => i.UpdateId == id);
                if (o != null)
                {
                  
                        db.OrderUpdates.Remove(o);
                        db.SaveChanges();
                    
                    return Ok(o);

                }
                else
                {
                    return BadRequest($"order updets number: {id} was not found");
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}