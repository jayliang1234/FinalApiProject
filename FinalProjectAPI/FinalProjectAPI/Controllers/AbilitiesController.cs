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
                return BadRequest(response);
            }
            else
            {
                return await _context.Abilities.ToListAsync();
            }
        }

        // GET: api/Abilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Abilities>> GetAbilities(int id)
        {
            var response = new Response();
            if (_context.Abilities == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Request failed, because _context.abilities is null";
                return BadRequest(response);
            }
            var abilities = await _context.Abilities.FindAsync(id);

            if (abilities == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Request failed, because abilities is null";
                return BadRequest(response);
            }

            return abilities;
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
                response.statusDescription = "Request failed, because id does not match AbilityId is null";
                return BadRequest(response);
            }

            _context.Entry(abilities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbilitiesExists(id))
                {
                    response.statusCode = 404;
                    response.statusDescription = "Request failed, because Entity set 'FinalProjectDBContext.Abilities'  is null";
                    return NotFound(response);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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
                return NotFound(response);
                
            }
            _context.Abilities.Add(abilities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbilities", new { id = abilities.AbilityId }, abilities);
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
                return NotFound(response);
            }
            var abilities = await _context.Abilities.FindAsync(id);
            if (abilities == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Request failed, abilities is null";
                return NotFound(response);
            }

            _context.Abilities.Remove(abilities);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbilitiesExists(int id)
        {
            return (_context.Abilities?.Any(e => e.AbilityId == id)).GetValueOrDefault();
        }
    }
}
