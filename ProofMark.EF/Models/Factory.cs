namespace ProofMark.EF.Models
{
	public class Factory
	{
		public int Id { get; set; }
		public string? UserId { get; set; }
		public User? User { get; set; }
		public string? CompanyName { get; set; }
		public string? Address { get; set; }
		public string? ContactPerson { get; set; }
		public string? PhoneNumber { get; set; }
	}
}
