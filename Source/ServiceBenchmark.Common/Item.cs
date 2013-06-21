namespace ServiceBenchmark.Common
{
	using System;

	public class Item
	{
		public Item(Guid itemID, string description)
		{
			this.ItemID = itemID;
			this.Description = description;
			this.ModifiedAt = DateTime.UtcNow;
		}

		public Guid ItemID { get; set; }
		public string Description { get; set; }
		public DateTime ModifiedAt { get; set; }
	}

	public class ItemRequest
	{
		public Guid ItemID { get; set; }
	}

	public class ItemResponse
	{
		public Item Item { get; set; }
	}
}