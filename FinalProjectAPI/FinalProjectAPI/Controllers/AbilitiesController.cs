using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectAPI.Models;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilitiesController : ControllerBase
    {
        private readonly FinalProjectDBContext _context;

        public AbilitiesController(FinalProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Abilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abilities>>> GetAbilities()
        {
            var response = new Response();
            if (_context.Abilities == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Request failed, database is empty";
                return BadRequest(new { response.statusCode, response.statusDescription});
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success";
                var ability = await _context.Abilities.ToListAsync();
                return Ok(new { response.statusCode, response.statusDescription,ability });
            }
        }

        // GET: api/Abilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Abilities>> GetAbilities(int id)
        {
            var response = new Response();
            var abilities = await _context.Abilities.FindAsync(id);

            if (abilities == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Request failed, champion id not in database";
                return BadRequest(new { response.statusCode, response.statusDescription});
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success";
                return Ok(new { response.statusCode, response.statusDescription, abilities});
            }
        }

        // PUT: api/Abilities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbilities(int id, Abilities abilities)
        {
            var response = new Response();

            if (id != abilities.AbilityId)
            {
                response.statusCode = 400;
                response.statusDescription = "Request failed, champion id not in database";
                return BadRequest(new { response.statusCode, response.statusDescription });
            }

            _context.Entry(abilities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                response.statusCode = 200;
                response.statusDescription = "Successfully editted";
                return Ok(new { response.statusCode, response.statusDescription, abilities });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbilitiesExists(id))
                {
                    response.statusCode = 400;
                    response.statusDescription = "Request failed, because Entity set 'FinalProjectDBContext.Abilities'  is null";
                    return BadRequest(new { response.statusCode, response.statusDescription });
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Abilities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Abilities>> PostAbilities(Abilities abilities)
        {
            var response = new Response();
            if (_context.Abilities == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Request failed, because Entity set 'FinalProjectDBContext.Abilities'  is null";
                return BadRequest(new { response.statusCode, response.statusDescription });

            }
            _context.Abilities.Add(abilities);
            await _context.SaveChangesAsync();
            response.statusCode = 200;
            response.statusDescription = "Successfully added champion";
            return Ok(new { response.statusCode, response.statusDescription, abilities });
        }

        // DELETE: api/Abilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbilities(int id)
        {
            var response = new Response();
            if (_context.Abilities == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Request failed, because Entity set 'FinalProjectDBContext.Abilities'  is null";
                return BadRequest(new { response.statusCode, response.statusDescription });
            }
            var abilities = await _context.Abilities.FindAsync(id);
            if (abilities == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Request failed, abilities not found";
                return BadRequest(new { response.statusCode, response.statusDescription });
            }

            _context.Abilities.Remove(abilities);
            await _context.SaveChangesAsync();
            response.statusCode = 200;
            response.statusDescription = "Successfully deleted";
            return Ok(new { response.statusCode, response.statusDescription, abilities });
        }

        private bool AbilitiesExists(int id)
        {
            return (_context.Abilities?.Any(e => e.AbilityId == id)).GetValueOrDefault();
        }
    }
}
