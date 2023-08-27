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
            new Quote { Author ="Yiğitcan Ölmez", Id = Guid.NewGuid(), Description = "Biyografi", Title ="Y.Ö." },
            new Quote { Author ="Yiğitcan Ölmez", Id = Guid.NewGuid(), Description = "Biyografi", Title ="Y.Ö." },

        };
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return quotes;
        }
        [HttpPost]
        public IActionResult Post([FromBody]Quote quote)
        {
            quotes.Add(quote);
            return Ok();
        }
    }
}

