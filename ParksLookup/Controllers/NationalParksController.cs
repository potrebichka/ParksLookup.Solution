using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParksLookup.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;

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

    [Authorize(Roles = "Administrator,Accountant")]
    //POST api/nationalparks
    [HttpPost]
    public void Post([FromBody] NationalPark park)
    {
      _db.NationalParks.Add(park);
      _db.SaveChanges();
    }

    [Authorize(Roles = "Administrator,Accountant")]
    // PUT api/nationalparks/70
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] NationalPark park)
    {
      park.NationalParkId = id;
      _db.Entry(park).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [Authorize(Roles = "Administrator")]
    // DELETE api/nationalparks/70
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var parkToDelete = _db.NationalParks.FirstOrDefault(entry => entry.NationalParkId == id);
      _db.NationalParks.Remove(parkToDelete);
      _db.SaveChanges();
    }

    // get random national park api/nationalparks/random
    [HttpGet("random")]
    public ActionResult<NationalPark> Random ()
    {
      List<NationalPark> parks = _db.NationalParks.ToList();
      var rnd = new Random();
      int rndIdx = rnd.Next(0,parks.Count-1);
      return parks[rndIdx];
    }
  }
}