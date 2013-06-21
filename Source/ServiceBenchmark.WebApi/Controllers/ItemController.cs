namespace ServiceBenchmark.WebApi.Controllers
{
	using System;
	using System.Web.Http;
	using ServiceBenchmark.Common;

	public class ItemController : ApiController
	{
		public Item Get(Guid id)
		{
			//System.Diagnostics.Debug.WriteLine("Request for item " + id.ToString());
			return new Item(id, "Made in Web API");
		}
	}
}