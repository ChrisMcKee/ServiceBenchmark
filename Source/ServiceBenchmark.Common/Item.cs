namespace ServiceBenchmark.Common
{
	using System;

	public class Item
	{
		public Item(Guid itemId, string description)
		{
			ItemId = itemId;
			Description = description;
			ModifiedAt = DateTime.UtcNow;
		}

		public Guid ItemId { get; set; }
		public string Description { get; set; }
		public DateTime ModifiedAt { get; set; }
	}

	public class ItemRequest
	{
		public Guid ItemId { get; set; }
	}

	public class ItemResponse
	{
		public Item Item { get; set; }
	}
}