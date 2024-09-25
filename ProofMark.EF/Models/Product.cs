namespace ProofMark.EF.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public int FactoryId { get; set; }
		public Factory? Factory { get; set; }
		public List<ProductItem>? Items { get; set; }
		public DateTime CreatedAt { get; set; }
        public bool IsDelete { get; set; }

    }
}
