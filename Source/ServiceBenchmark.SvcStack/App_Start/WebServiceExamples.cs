namespace ServiceBenchmark.SvcStack
{
	using ServiceBenchmark.Common;
	using ServiceStack.ServiceInterface;

	#region Item Service

	public class ItemService : Service
	{
		public object Any(ItemRequest request)
		{
			return new ItemResponse
				       {
					       Item = new Item(request.ItemId, "Made in ServiceStack")
				       };
		}
	}

	#endregion
}