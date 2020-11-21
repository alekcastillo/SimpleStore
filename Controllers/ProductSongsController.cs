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
            return await _context.ProductSongs.ToListAsync();
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


        /*

         [HttpPost]
public async Task<ActionResult<ProductBook>> PostProductBook(ProductBookDAO productBookDao)
{
    var product = new Product();
    product.Title = productBookDao.Title;
    product.Price = productBookDao.Price;
    product.ReleaseYear = productBookDao.ReleaseYear;
    product.Language = productBookDao.Language;
    product.Type = ProductType.Book;
    product.FilePath = productBookDao.FilePath;
    product.PreviewFilePath = productBookDao.PreviewFilePath;

    _context.Products.Add(product);

    var book = new ProductBook();
    book.Code = ""; //Consecutivo;
    book.Product = product;

    var bookSubject = _context.ProductBookSubjects.Single(bookSubject => bookSubject.Id == productBookDao.SubjectId);
    book.Subject = bookSubject;
    book.Author = productBookDao.Author;
    book.Publisher = productBookDao.Publisher;

    _context.ProductBooks.Add(book);

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateException)
    {
        if (ProductExists(product.Id))
        {
            return Conflict();
        }
        else if (ProductBookExists(book.Code))
        {
            return Conflict();
        }
        else
        {
            throw;
        }
    }

    return CreatedAtAction("GetProductBook", new { id = book.Code }, book);
}


 */

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

            _context.ProductSongs.Add(song);
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
