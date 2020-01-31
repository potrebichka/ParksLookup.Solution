using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParksLookup.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ParksLookup.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NationalParksController : ControllerBase
  {
    private ParksLookupContext _db;

    public NationalParksController(ParksLookupContext db)
    {
      _db = db;
    }

    // GET api/nationalparks
    [HttpGet]
    public ActionResult<IEnumerable<NationalPark>> Get(string state, string name)
    {
      var query = _db.NationalParks.AsQueryable();
      if (state != null)
      {
        query = query.Where(entry => entry.States.Contains(state));
      }
      if (name != null)
      {
        query = query.Where(entry => entry.FullName.ToLower().Contains(name.ToLower()));
      }
      return query.ToList();
    }

    // GET api/nationalparks/1
    [HttpGet("{id}")]
    public ActionResult<NationalPark> Get(int id)
    {
        return _db.NationalParks.FirstOrDefault(park => park.NationalParkId == id);
    }

    // //POST api/destinations
    // [HttpPost]
    // public void Post([FromBody] Destination destination)
    // {
    //   _db.Destinations.Add(destination);
    //   _db.SaveChanges();
    // }

    // // PUT api/destinations/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] Destination destination)
    // {
    //     destination.DestinationId = id;
    //     _db.Entry(destination).State = EntityState.Modified;
    //     _db.SaveChanges();
    // }

    // // DELETE api/destinations/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    //   var destinationToDelete = _db.Destinations.FirstOrDefault(entry => entry.DestinationId == id);
    //   _db.Destinations.Remove(destinationToDelete);
    //   _db.SaveChanges();
    // }

    // // get random destination api/destinations/random
    // [HttpGet("random")]
    // public ActionResult<Destination> Random ()
    // {
    //   List<Destination> destinations = _db.Destinations.ToList();
    //   var rnd = new Random();
    //   int rndIdx = rnd.Next(0,destinations.Count-1);
    //   return destinations[rndIdx];
    // }
  }
}