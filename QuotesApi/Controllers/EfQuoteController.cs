using Microsoft.AspNetCore.Mvc;
using QuotesApi.Data;
using QuotesApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfQuoteController : ControllerBase
    {
        private QuoteDbContext _context;

        public EfQuoteController(QuoteDbContext context)
        {
            _context = context;
        }

        // GET: api/<EfQuoteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var quote = _context.Quotes.Find(id);
            return Ok(quote ?? null);
        }

        // POST api/<EfQuoteController>
        [HttpPost]
        public void Post([FromBody] Quote quote)
        {
            _context.Quotes.Add(quote);
            _context.SaveChanges();
        }

        // PUT api/<EfQuoteController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Quote newModel)
        {
            var oldModel = _context.Quotes.Find(id);
            oldModel.Author = newModel.Author;
            oldModel.Description = newModel.Description;
            oldModel.Title = newModel.Title;
            _context.SaveChanges();
        }

        // DELETE api/<EfQuoteController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var model = _context.Quotes.Find(id);
            _context.Quotes.Remove(model);
            _context.SaveChanges();
        }
    }
}
