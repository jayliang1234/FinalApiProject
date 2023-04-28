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
    public class ChampionsController : ControllerBase
    {
        private readonly FinalProjectDBContext _context;

        public ChampionsController(FinalProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Champions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Champion>>> GetChampions()
        {
            var response = new Response();
            response.statusCode = 200;
            response.statusDescription = "Success!";
            if (_context.Champions == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Request failed, database is empty";
                return BadRequest(new { response.statusCode, response.statusDescription });
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success!";
                var champions = await _context.Champions.ToListAsync();
                return Ok(new { response.statusCode, response.statusDescription, champions });
            }
        }

        // GET: api/Champions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Champion>> GetChampion(int id)
        {
            var champion = await _context.Champions.FindAsync(id);

            var response = new Response();

            response.statusCode = 400;

            if (champion != null)
            {
                response.statusCode = 200;
                response.statusDescription = "Success!";
                return Ok(new { response.statusCode, response.statusDescription, champion });

            }
            else
            {
                response.statusCode = 400;
                response.statusDescription = "Request failed, because championId is not in the database";
                return BadRequest(new { response.statusCode, response.statusDescription });
            }
        }

        // PUT: api/Champions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChampion(int id, Champion champion)
        {
            var response = new Response();

            if (id != champion.ChampionId)
            {
                response.statusCode = 400;
                response.statusDescription = "id does not match with championId";
                return BadRequest(new { response.statusCode, response.statusDescription });
            }

            _context.Entry(champion).State = EntityState.Modified;

            try
            {
                response.statusCode = 200;
                response.statusDescription = "Successfully edited champion";
                await _context.SaveChangesAsync();
                return Ok(new { response.statusCode, response.statusDescription, champion });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChampionExists(id))
                {
                    response.statusCode = 400;
                    response.statusDescription = "Request Failed Champion does not exist";
                    return BadRequest(new { response.statusCode, response.statusDescription });
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Champions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Champion>> PostChampion(Champion champion)
        {
            var response = new Response();
            if (_context.Champions == null)
            {
                response.statusCode = 200;
                response.statusDescription = "Error, Entity set 'FinalProjectDBContext.Champions'  is null.";
                return BadRequest(new { response.statusCode, response.statusDescription });
            }
            _context.Champions.Add(champion);
            await _context.SaveChangesAsync();
            response.statusCode = 200;
            response.statusDescription = "Successfully added champion";
            return Ok(new { response.statusCode,response.statusDescription, champion });
        }

        // DELETE: api/Champions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChampion(int id)
        {
            var response = new Response();
            if (_context.Champions == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Champion does not exist";
                return BadRequest(new { response.statusCode, response.statusDescription});
            }

            var champion = await _context.Champions.FindAsync(id);
            if (champion == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Champion does not exist";
                return BadRequest(new { response.statusCode, response.statusDescription});
            }

            _context.Champions.Remove(champion);
            await _context.SaveChangesAsync();
            response.statusCode = 200;
            response.statusDescription = "Successfully deleted champion";
            return Ok(new { response.statusCode, response.statusDescription, champion });
        }

        private bool ChampionExists(int id)
        {
            return (_context.Champions?.Any(e => e.ChampionId == id)).GetValueOrDefault();
        }
    }
}
