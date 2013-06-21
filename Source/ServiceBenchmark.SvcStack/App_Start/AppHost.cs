using ServiceBenchmark.SvcStack.App_Start;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof (AppHost), "Start")]

namespace ServiceBenchmark.SvcStack.App_Start
{
	using System;
	using Funq;
	using ServiceBenchmark.Common;
	using ServiceStack.Common;
	using ServiceStack.Common.Web;
	using ServiceStack.ServiceHost;
	using ServiceStack.Text;
	using ServiceStack.WebHost.Endpoints;

	public class AppHost
		: AppHostBase
	{
		public AppHost() //Tell ServiceStack the name and where to find your web services
			: base("StarterTemplate ASP.NET Host", typeof (ItemService).Assembly)
		{
		}

		public override void Configure(Container container)
		{
			JsConfig.EmitCamelCaseNames = true;
			Routes.Add<ItemRequest>("/Item/{ItemID}");

			var config = new EndpointHostConfig
				             {
					             DefaultContentType = ContentType.Json,
					             AllowJsonpRequests = true,
					             EnableFeatures = Feature.All.Remove(GetDisabledFeatures())
				             };

			SetConfig(config);
		}

		private static Feature GetDisabledFeatures()
		{
			const string disabled = "Soap, Soap11, Soap12";

			Feature d;
			if (!string.IsNullOrWhiteSpace(disabled)
			    && Enum.TryParse(disabled, true, out d))
			{
				return d;
			}
			return Feature.None;
		}

		public static void Start()
		{
			new AppHost().Init();
		}
	}
}