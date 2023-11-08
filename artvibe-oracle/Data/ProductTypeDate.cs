using System.ComponentModel.DataAnnotations;

namespace artvibe_oracle.Data
{
    public class ProductTypeDate
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<ProductDate> ProductDate { get; set; }
    }


}
