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
  public class LocationsController : ControllerBase
  {
    public LocationsController(DatabaseContext _context)
    {
      this.context = _context;
    }

    private DatabaseContext context;

    public int Id { get; private set; }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Locations>> GetAllResults()
    {
      var Allresults = context.Locations.OrderByDescending(results => results.Id);

      return Allresults.ToList();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult GetOneEntry(int id)
    {
      var OneResult = context.Locations.FirstOrDefault(r => r.Id == id);
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
    public ActionResult<Locations> InsertData([FromBody]Locations insertion)
    {
      context.Locations.Add(insertion);
      context.SaveChanges();
      return insertion;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Locations> Update(int id, [FromBody]Locations newDetails)
    {
      context.Entry(newDetails).State = EntityState.Modified;
      context.SaveChanges();
      return newDetails;
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<Locations> DeleteEntry(int id)
    {
      var DeleteResult = context.Locations.FirstOrDefault(r => r.Id == id);
      context.Locations.Remove(DeleteResult);
      context.SaveChanges();
      return Ok();

    }
  }
}
