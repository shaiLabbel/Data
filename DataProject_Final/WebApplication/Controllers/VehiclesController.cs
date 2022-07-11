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
    public class VehiclesController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                List<VehiclesDTO> v = db.Vehicles.Select(x => new VehiclesDTO()
                {
                    VehicleNumber = x.VehicleNumber,
                    ManuFacturer = x.Manufacturers.Manufacturer,
                    Type = x.VehiclesTypes.Type,
                    TestValidityDate=x.TestValidityDate,
                    EntryCompany=x.EntryCompany,
                    Remarks=x.Remarks

                }).ToList(); ;

                return Ok(v);
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
        public IHttpActionResult Post([FromBody] Vehicles value)
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();


                db.Vehicles.Add(value);
                db.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(string id, [FromBody] Vehicles value)
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                Vehicles v = db.Vehicles.SingleOrDefault(i => i.VehicleNumber == id);

                v.TestValidityDate = value.TestValidityDate;
                v.EntryCompany = value.EntryCompany;
                v.Remarks = value.Remarks;
                v.Img = value.Img;
                db.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                string number = id.ToString();
                FinalProjDbContext db = new FinalProjDbContext();
                Vehicles v = db.Vehicles.SingleOrDefault(i => i.VehicleNumber == number);
                if (v != null)
                {
                    db.Vehicles.Remove(v);
                    db.SaveChanges();
                    return Ok(v);
                }
                else
                {
                    return BadRequest($"Vehicle number: {number} was not found");
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}