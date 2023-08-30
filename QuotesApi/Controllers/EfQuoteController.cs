using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
        [ResponseCache(Duration = 60,Location = ResponseCacheLocation.Client)]
        public IActionResult Get(string sort)
            {
            //ıenumerable database tarafına select * from olarak gider
            //Iqueryable database tarafına select * from where .... olarak gider
            IQueryable<Quote> quotes;
            quotes = sort switch
            {
                "desc" => _context.Quotes.OrderByDescending(q => q.CreatedAt),
                "asc" => _context.Quotes.OrderBy(q => q.CreatedAt),
                _ => _context.Quotes
            };
            return Ok(quotes);

        }
        [HttpGet("[action]")]


        public IActionResult PagingQuote(int pageNumber, int pageSize)
        {
            var quotes = _context.Quotes.Skip((pageNumber - 1) * pageSize).Take(pageSize);


            return Ok(quotes);


        }
        [HttpGet("[action]")]
        public IActionResult SearchingQuote(string type)
        {
            var quotes = _context.Quotes.Where(p => p.Title.Contains(type));
            return Ok();
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
            quote.Id = Guid.NewGuid();
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
