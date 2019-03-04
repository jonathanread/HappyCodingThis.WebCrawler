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
		public Guid CrawlRunId { get; set; }
		public TimeSpan Elapsed { get; set; }
		public string RootUrl { get; set; }
		public string ErrorMessage { get; set; }
		public ICollection<RetrievedPage> Pages { get; set; }
	}
}
