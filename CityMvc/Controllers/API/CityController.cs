using CityMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityMvc.Controllers.API
{
    public class CityController : ApiController
    {
        static string ConnectionString = "Data Source=desktop-l8k7db0;Initial Catalog=CityDB;Integrated Security=True;Pooling=False";

        CityDataClasses1DataContext CityDB = new CityDataClasses1DataContext(ConnectionString);

        // GET: api/City
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(CityDB.Citizens.ToList());
            }
            catch(SqlException err)
            {
                return Ok(new { err.Message });
            }
            catch(Exception err)
            {
                return Ok(new { err.Message });
            }
        }

        // GET: api/City/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Citizen citizen = CityDB.Citizens.First((CitizenItem) => CitizenItem.Id == id);
            return Ok(new{ citizen });
            }
           catch(SqlException err)
            {
                return Ok(new { err.Message });
            }
            catch(Exception err)
            {
                return Ok(new { err.Message });
            }
        }

        // POST: api/City
        public IHttpActionResult Post([FromBody]Citizen citizen)
        {
            try
            {
                CityDB.Citizens.InsertOnSubmit(citizen);
                CityDB.SubmitChanges();
                return Ok("item was added");
            }
            catch(SqlException err)
            {
                return Ok(new { err.Message });
            }
            catch(Exception err)
            {
                return Ok(err.Message);
            }
        }

        // PUT: api/City/5
        public IHttpActionResult Put(int id, [FromBody]Citizen citizen)
        {
            try
            {
            Citizen StudentFound = CityDB.Citizens.First((CitizenItem) => CitizenItem.Id == id);
            StudentFound.FName = citizen.FName;
            StudentFound.LName = citizen.LName;
            StudentFound.BirthDay = citizen.BirthDay;
            StudentFound.Addres = citizen.Addres;
            StudentFound.Seniority = citizen.Seniority;
            CityDB.SubmitChanges();
            return Ok("item was update");
            }
            catch (SqlException err)
            {
                return Ok(new { err.Message });
            }
            catch(Exception err)
            {
                return Ok(new { err.Message });
            }

        }

        // DELETE: api/City/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
            CityDB.Citizens.DeleteOnSubmit(CityDB.Citizens.First((CitizenItem) => (CitizenItem.Id == id));
            CityDB.SubmitChanges();
            return Ok("item deleted");
            }
            catch(SqlException err)
            {
                return Ok(new { err.Message });
            }
            catch(Exception err)
            {
                return Ok(new { err.Message });
            }

        }
    }
}
