using System;
using System.ComponentModel.DataAnnotations;

namespace QuotesApi.Models
{
	public class Quote
	{
		public Guid Id { get; set; }
		[Required]
		public string Title { get; set; }
		public string Author { get; set; }
		public string Description { get; set; }
		
                public DateTime CreatedAt { get; set; }
 

    }
}

