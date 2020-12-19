using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleStore.DAO;
using SimpleStore.Entities;
using SimpleStore.Entities.Attributes;
using SimpleStore.Infrastructure;

namespace SimpleStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSongsController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public ProductSongsController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductSongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSong>>> GetProductSongs()
        {
            return await _context.ProductSongs
                .Include(productSong => productSong.Product)
                .Include(productSong => productSong.Genre)
                .ToListAsync();
        }

        // GET: api/ProductSongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSong>> GetProductSong(string id)
        {
            var productSong = await _context.ProductSongs.FindAsync(id);

            if (productSong == null)
            {
                return NotFound();
            }

            return productSong;
        }

        // PUT: api/ProductSongs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSong(string id, ProductSong productSong)
        {
            if (id != productSong.Code)
            {
                return BadRequest();
            }

            _context.Entry(productSong).State = EntityState.Modified;

            ChangeLog.AddUpdatedLog(_context, "Songs", productSong);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSongExists(id))
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

        // POST: api/ProductSongs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductSong>> PostProductSong(ProductSongDAO productSongDao)
        {

            var product = new Product();
            product.Title = productSongDao.Title;
            product.Price = productSongDao.Price;
            product.ReleaseYear = productSongDao.ReleaseYear;
            product.Language = productSongDao.Language;
            product.Type = ProductType.Song;
            product.FilePath = productSongDao.FilePath;
            product.PreviewFilePath = productSongDao.PreviewFilePath;

            _context.Products.Add(product);

            var song = new ProductSong();

            song.Album = productSongDao.Album;
            song.Country = productSongDao.Country;

            var songGenere = _context.ProductSongGenres.Single(songGenere => songGenere.Id == productSongDao.GenreId);

            song.Genre = songGenere;

            song.Artist = productSongDao.Artist;
            song.Label = productSongDao.Label;
            song.Product = product;

            var songsConsecutive = _context.TableConsecutives.Single(tableConsecutive => tableConsecutive.Table == "Musica");
            song.Code = songsConsecutive.GetCurrentCode();
            song.InterpretationType = (SongInterpretationType)productSongDao.InterpretationType;

            _context.ProductSongs.Add(song);

            ChangeLog.AddCreatedLog(_context, "Songs", song);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductSongExists(song.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductSong", new { id = song.Code }, song);
        }

        // DELETE: api/ProductSongs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductSong>> DeleteProductSong(string id)
        {
            var productSong = await _context.ProductSongs.FindAsync(id);

            ChangeLog.AddDeletedLog(_context, "Songs", productSong);

            if (productSong == null)
            {
                return NotFound();
            }

            _context.ProductSongs.Remove(productSong);
            await _context.SaveChangesAsync();

            return productSong;
        }

        private bool ProductSongExists(string id)
        {
            return _context.ProductSongs.Any(e => e.Code == id);
        }
    }
}
