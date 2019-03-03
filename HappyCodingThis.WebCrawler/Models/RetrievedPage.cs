using AngleSharp.Dom.Html;
using System;

namespace HappyCodingThis.WebCrawler.Models
{
	public class RetrievedPage
	{
		public IHtmlDocument HtmlDoc { get; set; }
		public Uri Uri { get; set; }
		public string PageTitle { get; set; }
		public string Path { get; set; }
		public string ParentPath { get; set; }
		public RetrievedPage Parent { get; set; }
		public Guid Id { get; set; }
		public Guid ParentId { get; set; }
	}
}
