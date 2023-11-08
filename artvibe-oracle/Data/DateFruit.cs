using System.ComponentModel.DataAnnotations;

namespace artvibe_oracle.Data
{
	public class DateFruit
	{
		public Guid Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Color { get; set; }
		[Required]
		public DateTime FechaDeCosecha { get; set; }


	}
}
