using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Note_3.Data;
using Note_3.Entities;

namespace Note_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteListsController : ControllerBase
    {
        private readonly DataContext _context;

        public NoteListsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/NoteLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteList>>> GetNoteList()
        {
            return await _context.NoteList.ToListAsync();
        }

        // GET: api/NoteLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteList>> GetNoteList(int id)
        {
            var noteList = await _context.NoteList.FindAsync(id);

            if (noteList == null)
            {
                return NotFound();
            }

            return noteList;
        }

        // PUT: api/NoteLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoteList(int id, NoteList noteList)
        {
            if (id != noteList.Id)
            {
                return BadRequest();
            }

            _context.Entry(noteList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteListExists(id))
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

        // POST: api/NoteLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NoteList>> PostNoteList(NoteList noteList)
        {
            _context.NoteList.Add(noteList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNoteList", new { id = noteList.Id }, noteList);
        }

        // DELETE: api/NoteLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteList(int id)
        {
            var noteList = await _context.NoteList.FindAsync(id);
            if (noteList == null)
            {
                return NotFound();
            }

            _context.NoteList.Remove(noteList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoteListExists(int id)
        {
            return _context.NoteList.Any(e => e.Id == id);
        }
    }
}
