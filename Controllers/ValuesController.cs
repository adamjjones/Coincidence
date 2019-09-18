using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coincidence.Models;
using Microsoft.AspNetCore.Mvc;

namespace coincidence
{
  [Route("api/[controller]")]
  [ApiController]
  public class CoincidenceController : ControllerBase
  {
    public CoincidenceController(DatabaseContext _context)
    {
      this.context = _context;
    }

    private DatabaseContext context;

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Coincidence> InsertData([FromBody]Coincidence insertion)
    {
      context.Coincidence.Add(insertion);
      context.SaveChanges();
      return insertion;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
