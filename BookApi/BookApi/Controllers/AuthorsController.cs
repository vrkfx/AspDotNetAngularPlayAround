using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookApi.Data;
using BookApi.Models;

namespace BookApi.Controllers
{

    //https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly BookDBContext _context;

        public AuthorsController(BookDBContext context)
        {
            _context = context;
        }

        // GET: api/Author
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //      return View(await _context.Authors.ToListAsync());
        //}


        //Use IEnumerable will return all the records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorsByID(int id)
        {
            var authorr = await _context.Authors.FindAsync(id);

            if (authorr == null)
            {
                return NotFound();
            }

            return authorr;
        }



        // PUT Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Author author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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


        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorId == id);
        }

        //Http Delete Request 
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) { return NotFound(); }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        //Post Request

        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author) 
        { 
            _context.Authors.Add(author);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (AuthorExists(author.AuthorId))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAuthors), new { id = author.AuthorId }, author);
        }

    }
}
