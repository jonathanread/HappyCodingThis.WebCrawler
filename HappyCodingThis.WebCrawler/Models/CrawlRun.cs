using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HappyCodingThis.WebCrawler.Models
{
	public class CrawlRun
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		public TimeSpan Elapsed { get; set; }
		public string RootUrl { get; set; }
		public Exception ErrorMessage { get; set; }
		public List<RetrievedPage> Pages { get; set; }
	}
}
