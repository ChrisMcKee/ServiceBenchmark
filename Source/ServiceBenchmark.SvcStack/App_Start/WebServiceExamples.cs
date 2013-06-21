namespace ServiceBenchmark.SvcStack
{
	using ServiceBenchmark.Common;
	using ServiceStack.ServiceInterface;

	public class ItemService : Service
	{
		public object Get(ItemRequest request)
		{
			return new ItemResponse
				       {
					       Item = new Item(request.ItemId, "Made in ServiceStack")
				       };
		}
	}
}