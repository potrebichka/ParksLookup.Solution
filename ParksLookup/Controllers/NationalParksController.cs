using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParksLookup.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;

namespace ParksLookup.Controllers
{
  [Produces("application/json")]
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
    /// <summary>
    /// View list of all national parks.
    /// </summary>
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
    /// <summary>
    /// View information about specific national park.
    /// </summary>
    /// <param name="id"></param>  
    [HttpGet("{id}")]
    public ActionResult<NationalPark> Get(int id)
    {
        return _db.NationalParks.FirstOrDefault(park => park.NationalParkId == id);
    }

    //POST api/nationalparks
    /// <summary>
    /// Create a new national park. Admin, Accountant only.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /NationalPark
    ///     {
    ///        "states": "DC",
    ///        "latlong": "lat:38.88101431, long:-77.03632572",
    ///        "description": "Author of the Declaration of Independence, statesman and visionary for the founding of a nation.",
    ///        "designation": "",
    ///        "parkcode": "thje",
    ///        "parkid": "2D0C31DF-BE78-42A8-812E-1A44602B3D40",
    ///        "directionsinfo": "GPS Coordinates: 38.881387, -77.036508\n\nThomas Jefferson Memorial is part of the National Mall and Memorial Parks. The site lies at the southern end of the National Mall, adjacent to the Tidal Basin in West Potomac Park. The memorial rests within the sightline to and from the White House, which stands one mile to the north.",
    ///        "directionsurl": "http://www.nps.gov/thje/planyourvisit/directions.htm",
    ///        "fullname": "Thomas Jefferson Memorial",
    ///        "url": "https://www.nps.gov/thje/index.htm",
    ///        "weatherinfo": "Washington DC gets to see all four seasons. Humidity will make the temps feel hotter in summer and colder in winter.\n\nSpring (March - May) Temp: Average high is 65.5 degrees with a low of 46.5 degrees\n\nSummer (June - August) Temp: Average high is 86 degrees with a low of 68.5 degrees\n\nFall (September - November) Temp: Average high is 68 degrees with a low of 51.5 degrees\n\nWinter (December - February) Temp: Average high is 45 degrees with a low of 30 degrees\n\n(Source: www.usclimatedata.com)",
    ///        "name": "Thomas Jefferson Memorial"
    ///     }
    ///
    /// </remarks>
    /// <param name="park"></param>
    /// <returns>A newly created NationalPark</returns>
    /// <response code="201">A new national park was created</response>
    /// <response code="400">If the NationalPark is null</response>  
    [Authorize(Roles = "Administrator,Accountant")]
    [HttpPost]
    public void Post([FromBody] NationalPark park)
    {
      _db.NationalParks.Add(park);
      _db.SaveChanges();
    }


    // PUT api/nationalparks/70
    /// <summary>
    /// Update information about specific national park. Admin only.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Update /NationalPark
    ///     {
    ///        "states": "DC",
    ///        "latlong": "lat:38.88101431, long:-77.03632572",
    ///        "description": "Author of the Declaration of Independence, statesman and visionary for the founding of a nation.",
    ///        "designation": "",
    ///        "parkcode": "thje",
    ///        "parkid": "2D0C31DF-BE78-42A8-812E-1A44602B3D40",
    ///        "directionsinfo": "GPS Coordinates: 38.881387, -77.036508\n\nThomas Jefferson Memorial is part of the National Mall and Memorial Parks. The site lies at the southern end of the National Mall, adjacent to the Tidal Basin in West Potomac Park. The memorial rests within the sightline to and from the White House, which stands one mile to the north.",
    ///        "directionsurl": "http://www.nps.gov/thje/planyourvisit/directions.htm",
    ///        "fullname": "Thomas Jefferson Memorial",
    ///        "url": "https://www.nps.gov/thje/index.htm",
    ///        "weatherinfo": "Washington DC gets to see all four seasons. Humidity will make the temps feel hotter in summer and colder in winter.\n\nSpring (March - May) Temp: Average high is 65.5 degrees with a low of 46.5 degrees\n\nSummer (June - August) Temp: Average high is 86 degrees with a low of 68.5 degrees\n\nFall (September - November) Temp: Average high is 68 degrees with a low of 51.5 degrees\n\nWinter (December - February) Temp: Average high is 45 degrees with a low of 30 degrees\n\n(Source: www.usclimatedata.com)",
    ///        "name": "Thomas Jefferson Memorial"
    ///     }
    ///
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="park"></param>
    /// <returns>An updated National Park</returns>
    /// <response code="201">Returns the updated National Park</response>
    /// <response code="400">If the NationalPark is null</response>   
    [Authorize(Roles = "Administrator,Accountant")]
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] NationalPark park)
    {
      park.NationalParkId = id;
      _db.Entry(park).State = EntityState.Modified;
      _db.SaveChanges();
    }


    // DELETE api/nationalparks/70
    /// <summary>
    /// Delete a specific national park. Admin only.
    /// </summary>
    /// <param name="id"></param>  
    [Authorize(Roles = "Administrator")]
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var parkToDelete = _db.NationalParks.FirstOrDefault(entry => entry.NationalParkId == id);
      _db.NationalParks.Remove(parkToDelete);
      _db.SaveChanges();
    }

    // RANDOM api/nationalparks/random
    /// <summary>
    /// Get random national park.
    /// </summary>
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