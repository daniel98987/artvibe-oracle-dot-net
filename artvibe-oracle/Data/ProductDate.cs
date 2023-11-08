using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace artvibe_oracle.Data
{
    public class ProductDate
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [ForeignKey("ProductType")]
        [Required]
        public Guid ProductTypeId { get; set; }
        public ProductTypeDate ProductType { get; set; }


    }
}
