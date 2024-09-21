using Microsoft.AspNetCore.Identity;
using static ProofMark.Core.Enums.Enums;

namespace ProofMark.EF.Models
{
	public class User : IdentityUser
	{
		public UserType UserType { get; set; }
		public DateTime CreateAt { get; set; }
		public bool IsActive { get; set; } = true;
    }
}
