using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using my_ef_data.Context;
using Microsoft.EntityFrameworkCore;
using my_ef_data.Models;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using Newtonsoft.Json.Linq;

namespace my_sample_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {

        //dependency injection field (database)
        private readonly ApplicationDbContext applicationDbContext;
        //constructor
        public PeopleController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        // GET: api/people
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var people = await applicationDbContext.People.ToListAsync();
            return Ok(people);
        }

        // GET api/people/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await applicationDbContext.People.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(person);
        }

        // POST api/people
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Person person)
        {
            await applicationDbContext.AddAsync(person);
            await applicationDbContext.SaveChangesAsync();
            return Ok();
        }

        // PUT api/people/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Person person)
        {
            var dbPerson = await applicationDbContext.People.FirstOrDefaultAsync(x => x.Id == id);
            if(dbPerson != null)
            {
                dbPerson.Vorname = person.Vorname;
                dbPerson.Nachname = person.Nachname;
                dbPerson.Geburtsdatum = person.Geburtsdatum;
                dbPerson.Lieblingsfarbe = person.Lieblingsfarbe;
                await applicationDbContext.SaveChangesAsync();
            }

            return Ok();
        }

        // DELETE api/people/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await applicationDbContext.People.FirstOrDefaultAsync(x => x.Id == id);
            if (person != null)
            {
                applicationDbContext.People.Remove(person);
                await applicationDbContext.SaveChangesAsync();
            }
            return Ok();
        }
    }
}

