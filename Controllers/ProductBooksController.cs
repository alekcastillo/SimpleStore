using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleStore.DAO;
using SimpleStore.Entities;
using SimpleStore.Infrastructure;
using SimpleStore.Entities.Attributes;

namespace SimpleStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBooksController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public ProductBooksController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductBook>>> GetProductBooks()
        {
            return await _context.ProductBooks
                .Include(productBook => productBook.Product)
                .Include(productBook => productBook.Subject)
                .ToListAsync();
        }

        // GET: api/ProductBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBook>> GetProductBook(string id)
        {
            var productBook = await _context.ProductBooks.FindAsync(id);

            if (productBook == null)
            {
                return NotFound();
            }

            return productBook;
        }

        // PUT: api/ProductBooks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductBook(string id, ProductBookDAO productBookDao)
        {
            var product = new Product();
            product.Title = productBookDao.Title;
            product.Price = productBookDao.Price;
            product.ReleaseYear = productBookDao.ReleaseYear;
            product.Language = productBookDao.Language;
            product.Type = ProductType.Book;
            product.FilePath = productBookDao.FilePath;
            product.PreviewFilePath = productBookDao.PreviewFilePath;

            var productBook = new ProductBook();
            var bookSubject = new ProductBookSubject();
            productBook.Subject = bookSubject;
            productBook.Author = productBookDao.Author;
            productBook.Publisher = productBookDao.Publisher;
            productBook.Product = product;
            productBook.Code = productBookDao.Code;

            ChangeLog.AddCreatedLog(_context, "Books", productBook);

            if (id != productBookDao.Code)
            {
                return BadRequest();
            }


            if (id != productBook.Code)
            {
                return BadRequest();
            }

            _context.Entry(productBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductBookExists(id))
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
            var bookSubject = new ProductBookSubject();
            
            book.Author = productBookDao.Author;
            book.Publisher = productBookDao.Publisher;

            var booksConsecutive = _context.TableConsecutives.Single(tableConsecutive => tableConsecutive.Table == "Libros");
            book.Code = booksConsecutive.GetCurrentCode();
            book.Product = product;

            try
            {
                bookSubject = _context.ProductBookSubjects.Single(bookSubject => bookSubject.Id == productBookDao.SubjectId);
            }
            catch
            {
                bookSubject = null;
            }

            book.Subject = bookSubject;

            _context.ProductBooks.Add(book);

            ChangeLog.AddCreatedLog(_context, "Books", book);

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

        // DELETE: api/ProductBooks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductBook>> DeleteProductBook(string id)
        {
            var productBook = await _context.ProductBooks.FindAsync(id);

            ChangeLog.AddDeletedLog(_context, "Books", productBook);

            if (productBook == null)
            {
                return NotFound();
            }

            _context.ProductBooks.Remove(productBook);
            await _context.SaveChangesAsync();

            return productBook;
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        private bool ProductBookExists(string id)
        {
            return _context.ProductBooks.Any(e => e.Code == id);
        }
    }
}
