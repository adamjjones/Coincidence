using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coincidence.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    public int Id { get; private set; }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Coincidence>> GetAllResults()
    {
      var Allresults = context.Coincidence.OrderByDescending(results => results.DateOrdered);

      return Allresults.ToList();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult GetOneEntry(int id)
    {
      var OneResult = context.Coincidence.FirstOrDefault(r => r.Id == id);
      if (OneResult == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(OneResult);
      }
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
    public ActionResult<Coincidence> Update(int id, [FromBody]Coincidence newDetails)
    {
      context.Entry(newDetails).State = EntityState.Modified;
      context.SaveChanges();
      return newDetails;
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<Coincidence> DeleteEntry(int id)
    {
      var DeleteResult = context.Coincidence.FirstOrDefault(r => r.Id == id);
      context.Coincidence.Remove(DeleteResult);
      context.SaveChanges();
      return Ok();

    }
  }
}
