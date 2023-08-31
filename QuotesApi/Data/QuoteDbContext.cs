using Microsoft.EntityFrameworkCore;
using QuotesApi.Models;

namespace QuotesApi.Data
{
    public class QuoteDbContext : DbContext
    {
        public QuoteDbContext(DbContextOptions<QuoteDbContext> opt) : base(opt)
        {

        }
        public DbSet<Quote> Quotes { get; set; }
    }
}
