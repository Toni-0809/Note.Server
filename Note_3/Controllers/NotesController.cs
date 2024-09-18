using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Note_3.Data;
using Note_3.DTOs;
using Note_3.Entities;
using Note_3.Mapper;

namespace Note_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly DataContext _context;

        public NotesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotesDTO>>> GetNotes()
        {
            return await _context.Notes.Select(x=>x.ToNotesDTO()).ToListAsync();
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotesDTO>> GetNotes(int id)
        {
            var notes = await _context.Notes.FindAsync(id);

            if (notes == null)
            {
                return NotFound();
            }

            return notes.ToNotesDTO();
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotes(int id, UpdateNotesDTO notes)
        {
            var existingCinema = await _context.Notes.FindAsync(id);

            if (existingCinema is null)
            {
                return NotFound();
            }

            _context.Entry(existingCinema)
                     .CurrentValues
                     .SetValues(notes.ToEntity(id));

            await _context.SaveChangesAsync();

            return NoContent();
        }
        // POST: api/Notes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostNotes(AddNotesDTO notes)
        {
            _context.Notes.Add(notes.ToEntity());
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotes(int id)
        {
            var notes = await _context.Notes.FindAsync(id);
            if (notes == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(notes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
