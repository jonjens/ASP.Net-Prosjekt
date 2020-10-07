using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingChallengeAsp.Data;
using CodingChallengeAsp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingChallengeAsp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersApiController : ControllerBase
    {
        private readonly FootballContext _context;

        public PlayersApiController(FootballContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Player>> GetRepositories()
        {
            var players = await _context.Player.ToListAsync();
            return Ok(players);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> PostTodoItem(Player players)
        {
            _context.Player.Add(players);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetRepositories), new { id = players.PlayerId }, players);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, Player players)
        {
            if (id != players.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(players).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Player>> DeleteTodoItem(int id)
        {
            var players = await _context.Player.FindAsync(id);
            if (players == null)
            {
                return NotFound();
            }

            _context.Player.Remove(players);
            await _context.SaveChangesAsync();

            return players;
        }

    }
}
