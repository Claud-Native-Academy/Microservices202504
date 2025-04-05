using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.GraphQL.Products.Service.Models
{
    public class Product
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }

        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

}
