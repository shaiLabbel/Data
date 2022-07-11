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
    public class OrdersController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
    
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                List<OrderDTO> o = new List<OrderDTO>();
                o = db.Orders.Select(x => new OrderDTO()
                {
                    ContactName = x.ContactName,
                    ContactNumber = x.ContactNumber,
                    OrderNumber = x.OrderNumber,
                    Type = x.Type,
                    Passengers = (int)x.Pssengers,
                    OrderStatus = x.OrderStatus1.StatusName,
                    Date = x.Date,
                    Driver = x.Employees.FirstName,
                    Bid = x.Bid,
                    Points = x.PickUps.Select(p => new PickUpDTO()
                    {
                        PickUpNumber = p.PickUpNumber,
                        CollectionPoint=p.CollectionPoint,
                        CollectionTime=(TimeSpan)p.CollectionTime,
                        Destination=p.Destination

                    }).ToList()

                }).ToList();

                if (o != null)
                {
                    return Ok(o);
                }
                return BadRequest($" fail with get all orders");



            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Orders/GetFilterOrders")]
        public IHttpActionResult GetFilterOrders()
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                List<OrderDTO> o = new List<OrderDTO>();
                o = db.Orders.Select(x => new OrderDTO()
                {
                    ContactName = x.ContactName,
                    ContactNumber = x.ContactNumber,
                    OrderNumber = x.OrderNumber,
                    Type = x.Type,
                    Passengers = (int)x.Pssengers,
                    OrderStatus = x.OrderStatus1.StatusName,
                    Date = x.Date,
                    Driver = x.Employees.FirstName,
                    Bid = x.Bid,
                    Points = x.PickUps.Select(p => new PickUpDTO()
                    {
                        PickUpNumber = p.PickUpNumber,
                        CollectionPoint = p.CollectionPoint,
                        CollectionTime = (TimeSpan)p.CollectionTime,
                        Destination = p.Destination

                    }).ToList()

                }).Where(x => x.Driver == null).ToList();

                return Ok(o);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {

            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                OrderDTO o = new OrderDTO();
                   o = db.Orders.Select(x => new OrderDTO()
                   {
                       ContactName = x.ContactName,
                       ContactNumber = x.ContactNumber,
                       OrderNumber = x.OrderNumber,
                       Type = x.Type,
                       Passengers = (int)x.Pssengers,
                       OrderStatus = x.OrderStatus1.StatusName,
                       Date = x.Date,
                       Bid=x.Bid
                       
                   }).SingleOrDefault(x=> x.OrderNumber==id);

                if (o != null)
                {
                    return Ok(o);
                }
                return BadRequest($"order number: {id} was not found");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Orders value)
        {
            try
            {

                FinalProjDbContext db = new FinalProjDbContext();
                db.Orders.Add(value);
                db.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/Orders/PutBidAndStatus/{id}")]
        public IHttpActionResult Put(int id, [FromBody] Orders value)
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                Orders o = db.Orders.SingleOrDefault(i => i.OrderNumber == id);
                o.Bid = value.Bid;
                o.OrderStatus = value.OrderStatus;
                db.SaveChanges();
                return Ok(o.OrderStatus);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        [Route("api/Orders/PutStatus/{id}")]
        public IHttpActionResult PutStatus(int id, [FromBody] Orders value)
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                Orders o = db.Orders.SingleOrDefault(i => i.OrderNumber == id);
                o.OrderStatus = value.OrderStatus;
                db.SaveChanges();
                return Ok(o.OrderStatus);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}