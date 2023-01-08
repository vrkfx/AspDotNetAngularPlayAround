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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

    }
}
