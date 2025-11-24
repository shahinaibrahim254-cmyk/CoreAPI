using CoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("EMP")]//controller name
    [ApiController]
    public class EMPController : ControllerBase
    {
        EmployeeDB dbobj = new EmployeeDB();
        // GET: api/<EMPController>
        [HttpGet]
        [Route("getalldata")]
        public List<Employee> Get()
        {
            return dbobj.selectdb();
        }

        // GET api/<EMPController>/5
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("getwithid/{id}")]
        public Employee Get(int id)
        {
            var getEmployee = dbobj.selectdb().Where(x => x.eid == id).FirstOrDefault();
            return getEmployee;
            //return dbobj.selectprofiledb();
        }

        // POST api/<EMPController>
        [HttpPost]
        [Route("posttab")]
        public void Post([FromBody]EmployeeDTO clsobj)
        {
            dbobj.InsertDB(clsobj);
        }

        // PUT api/<EMPController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        [Route("updatetab/{id}")]
        public void Put(int id,Employee clsobj)
        {
            dbobj.UpdateDB(id,clsobj);
        }

        // DELETE api/<EMPController>/5
        [HttpDelete]
        [Route("delete/{id}")]
        //[HttpDelete("{id}")]
        public void Delete(int id)
        {
            dbobj.deletedb(id);
        }
    }
}
