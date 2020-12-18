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
    public class ProductMoviesController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public ProductMoviesController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductMovies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductMovie>>> GetProductMovies()
        {
            return await _context.ProductMovies.ToListAsync();
        }

        // GET: api/ProductMovies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductMovie>> GetProductMovie(string id)
        {
            var productMovie = await _context.ProductMovies.FindAsync(id);

            if (productMovie == null)
            {
                return NotFound();
            }

            return productMovie;
        }

        // PUT: api/ProductMovies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductMovie(string id, ProductMovie productMovie)
        {
            if (id != productMovie.Code)
            {
                return BadRequest();
            }

            _context.Entry(productMovie).State = EntityState.Modified;

            ChangeLog.AddUpdatedLog(_context, "Movies", productMovie);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductMovieExists(id))
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



        // POST: api/ProductMovies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductMovie>> PostProductMovie(ProductMovieDAO productMovieDao)
        {

            var product = new Product();
            product.Title = productMovieDao.Title;
            product.Price = productMovieDao.Price;
            product.ReleaseYear = productMovieDao.ReleaseYear;
            product.Language = productMovieDao.Language;
            product.Type = ProductType.Movie;
            product.FilePath = productMovieDao.FilePath;
            product.PreviewFilePath = productMovieDao.PreviewFilePath;

            _context.Products.Add(product);

            var movie = new ProductMovie();
            movie.Code = ""; //Consecutivo;
            movie.Product = product;

            var movieGenre = _context.ProductMovieGenres.Single(movieGenre => movieGenre.Id == productMovieDao.GenreId);

            List<ProductMovieActor> movieActor = new List<ProductMovieActor>();

            if (productMovieDao.ActorIds != null)
            {
                for (int i = 0; i < productMovieDao.ActorIds.Count; i++)
                {
                    var actor = new ProductMovieActor();
                    actor = _context.ProductMovieActors.Single(actor => actor.Id == productMovieDao.ActorIds[i]);
                    movieActor.Add(actor);
                }
            }
            movie.Genre = movieGenre;

            movie.Actors = movieActor;

            _context.ProductMovies.Add(movie);

            ChangeLog.AddCreatedLog(_context, "Movies", movie);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
               if (ProductMovieExists(movie.Code))
                {
                    //return Conflict();
                    
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductMovie", new { id = movie.Code }, movie);
        }

        // DELETE: api/ProductMovies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductMovie>> DeleteProductMovie(string id)
        {
            var productMovie = await _context.ProductMovies.FindAsync(id);

            ChangeLog.AddDeletedLog(_context, "Movies", productMovie);

            if (productMovie == null)
            {
                return NotFound();
            }

            _context.ProductMovies.Remove(productMovie);
            await _context.SaveChangesAsync();

            return productMovie;
        }

        private bool ProductMovieExists(string id)
        {
            return _context.ProductMovies.Any(e => e.Code == id);
        }
    }
}
