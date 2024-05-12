using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Tracker.Data;
using Tracker.Models;

namespace Tracker.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class EntryController : ControllerBase
    {

        private readonly ILogger<EntryController> _logger;

        private readonly EntryDbContext _context;


        public EntryController(EntryDbContext context) => _context = context;

        [HttpGet("[controller]")]
        public async Task<IEnumerable<Entry>> Get()
            => await _context.Entries.ToListAsync();

        [HttpGet("[controller]/{date}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Entry), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBetweenDates(DateTime date)
        {
            var entryDate = new DateTime();
            var entriesRestult = _context.Entries;
            foreach (var entry in entriesRestult.Where(entriesRestult => entriesRestult.Date.Date == date))
            {
                entryDate = entry.Date;
                return Ok(entryDate);
            }
            return NotFound();
        }

        [HttpPost("[controller]")]
        public async Task<IActionResult> Post(Entry e)
        {
            Console.WriteLine(e);
            Console.WriteLine("test");
            _context.Entries.Add(e);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Post), new { id = e.Id }, e);
        }
    }
}
