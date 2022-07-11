using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataProject_Final;

namespace WebApplication.Controllers
{
    public class EmployeesController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                Employees[] e = db.Employees.ToArray();

                return Ok(e);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    
        // GET api/<controller>/5/
        public IHttpActionResult Get(int id)
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                Employees e = db.Employees.SingleOrDefault(i => i.EmployeeNumber == id);
                if (e != null)
                {
                    return Ok(e);
                }
                return BadRequest($"employee number: {id} was not found");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Employees value)
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                db.Employees.Add(value);
                db.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody] Employees value)
        {
            try
            {
                FinalProjDbContext db = new FinalProjDbContext();
                Employees e = db.Employees.SingleOrDefault(i => i.EmployeeNumber == id);
                e.EmployeeNumber = value.EmployeeNumber;
                e.Id = value.Id;
                e.FirstName = value.FirstName;
                e.LastName = value.LastName;
                e.Mail = value.Mail;
                e.PhoneNumber = value.PhoneNumber;
                e.StartWorking = value.StartWorking;
                e.Img = value.Img;
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
                FinalProjDbContext db = new FinalProjDbContext();
                Employees e = db.Employees.SingleOrDefault(em => em.EmployeeNumber == id);
                if (e != null)
                {
                    db.Employees.Remove(e);
                    db.SaveChanges();
                    return Ok(e);
                }
                else
                {
                    return BadRequest($"employee number: {id} was not found");
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}