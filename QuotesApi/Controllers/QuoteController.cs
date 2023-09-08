using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotesApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuotesApi.Controllers
{
    [Route("[controller]")]
    public class QuoteController : Controller
    {
        static List<Quote> quotes = new List<Quote>
        {
            new Quote { Author ="Yiğitcan Ölmez", Id = Guid.NewGuid(), Description = "Biyografi", Title ="Y.Ö.1" },
            new Quote { Author ="Yiğitcan Ölmez", Id = Guid.NewGuid(), Description = "Biyografi", Title ="Y.Ö.2" },

        };

        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return quotes;
        }

        [HttpPost("Post")]
        public IActionResult Post([FromBody] Quote quote)
        {
            quotes.Add(quote);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Quote quote)
        {
            quotes[id] = quote;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            quotes.RemoveAt(id);
            return Ok();
        }
    }
}

