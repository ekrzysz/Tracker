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
    public class EntriesController : ControllerBase
    {

        private readonly ILogger<EntriesController> _logger;

        private readonly EntriesDbContext _context;


        public EntriesController(EntriesDbContext context) => _context = context;

        [HttpGet("[controller]")]
        public async Task<IActionResult> Get()
        {
            var entriesResult = await _context.Entries.ToListAsync();
            return entriesResult == null ? NotFound() : Ok(entriesResult);
        }
        /*
        [HttpGet("[controllers]/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById_IActionResult(int id)
        {
            var product = _context.Entries.Find(id);
            return product == null ? NotFound() : Ok(product);
        }
        */
        
        [HttpGet("[controller]/{date}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public DateTime GetBetweenDates(DateTime date)
        {
            var entryDate = new DateTime();
            var entriesRestult = _context.Entries;
            foreach(var entry in entriesRestult.Where(entriesRestult => entriesRestult.Date.Date == date))
            {
                entryDate = entry.Date;
            }
            return entryDate;
        }

        [HttpPost("[controller]")]
        public async Task<IActionResult> Post(Entries e)
        {
            _context.Entries.Add(e);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Post), new { id = e.Id }, e);
        }



        //TODO
        //POST :id
        //POST :id-id
        //[HttpPost(Name = "")]        



    }
}
