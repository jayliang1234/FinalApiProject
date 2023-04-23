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
          if (_context.Abilities == null)
          {
              return NotFound();
          }
            return await _context.Abilities.ToListAsync();
        }

        // GET: api/Abilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Abilities>> GetAbilities(int id)
        {
          if (_context.Abilities == null)
          {
              return NotFound();
          }
            var abilities = await _context.Abilities.FindAsync(id);

            if (abilities == null)
            {
                return NotFound();
            }

            return abilities;
        }

        // PUT: api/Abilities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbilities(int id, Abilities abilities)
        {
            if (id != abilities.AbilityId)
            {
                return BadRequest();
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
                    return NotFound();
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
          if (_context.Abilities == null)
          {
              return Problem("Entity set 'FinalProjectDBContext.Abilities'  is null.");
          }
            _context.Abilities.Add(abilities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbilities", new { id = abilities.AbilityId }, abilities);
        }

        // DELETE: api/Abilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbilities(int id)
        {
            if (_context.Abilities == null)
            {
                return NotFound();
            }
            var abilities = await _context.Abilities.FindAsync(id);
            if (abilities == null)
            {
                return NotFound();
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
