namespace ProofMark.EF.Models
{
	public class ProductItem
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public Product? Product { get; set; }
		public string? SerialNumber { get; set; }
		public string? QRCode { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
