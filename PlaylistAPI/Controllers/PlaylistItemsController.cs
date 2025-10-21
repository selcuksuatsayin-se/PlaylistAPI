using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaylistAPI.Models;


namespace PlaylistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistItemsController : ControllerBase
    {
        private readonly PlaylistContext _context;

        public PlaylistItemsController(PlaylistContext context)
        {
            _context = context;
        }

        // GET: api/PlaylistItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistItem>>> GetPlaylistItems()
        {
            if (_context.PlaylistItems == null)
            {
                return NotFound();
            }
            return await _context.PlaylistItems.ToListAsync();
        }

        // GET: api/PlaylistItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistItem>> GetPlaylistItem(long id)
        {
            if (_context.PlaylistItems == null)
            {
                return NotFound();
            }
            var playlistItem = await _context.PlaylistItems.FindAsync(id);

            if (playlistItem == null)
            {
                return NotFound();
            }
            return playlistItem;
        }

        // POST: api/PlaylistItems
        [HttpPost]
        public async Task<ActionResult<PlaylistItem>> PostPlaylistItem(PlaylistItem playlistItem)
        {
            if (_context.PlaylistItems == null)
            {
                return Problem("Entitiy set 'PlaylistContext.PlaylistItems' is null.");
            }
            if (_context.PlaylistItems == null)
            {
                return Problem("Invalid json");
            }
            if (string.IsNullOrWhiteSpace(playlistItem.Title) || string.IsNullOrWhiteSpace(playlistItem.Artist))
                return Problem("Title ve Artist zorunludur.");

            _context.PlaylistItems.Add(playlistItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPlaylistItem", new { id = playlistItem.Id }, playlistItem);
        }

        // PUT: api/PlaylistItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylistItem(long id, PlaylistItem updatedItem)
        {

            var existingItem = await _context.PlaylistItems.FindAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Title = updatedItem.Title;
            existingItem.Artist = updatedItem.Artist;
            existingItem.Duration = updatedItem.Duration;
            existingItem.CoverImageUrl = updatedItem.CoverImageUrl;


            await _context.SaveChangesAsync();

            return NoContent();
        }

        //DELETE: api/PlaylistItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylistItem(long id)
        {
            if (_context.PlaylistItems == null)
            {
                return NotFound();
            }

            var playlistItem = await _context.PlaylistItems.FindAsync(id);

            if (playlistItem == null)
            {
                return NotFound();
            }

            _context.PlaylistItems.Remove(playlistItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("search")]
        public List<PlaylistItem> SearchPlaylistItem(String search)
        {
            if (_context.PlaylistItems == null)
            {
                return new List<PlaylistItem>();
            }
            List<PlaylistItem> ret = _context.PlaylistItems.Where(p => p.Title != null && p.Title.StartsWith(search)).ToList();
            return ret;
        }
    }
}
