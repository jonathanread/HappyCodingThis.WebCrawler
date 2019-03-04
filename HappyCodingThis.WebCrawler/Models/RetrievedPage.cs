using AngleSharp.Dom.Html;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyCodingThis.WebCrawler.Models
{
	public class RetrievedPage
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid RetrievedPageID { get; set; }

		public Guid ParentPageID { get; set; }

		public Guid CrawlRunID { get; set; }

		public IHtmlDocument HtmlDoc { get; set; }

		[DataType(DataType.Url)]
		public string Url { get; set; }

		public string PageTitle { get; set; }

		public string Path { get; set; }

		public string ParentPath { get; set; }

		public CrawlRun CrawlRun { get; set; }
	}
}
