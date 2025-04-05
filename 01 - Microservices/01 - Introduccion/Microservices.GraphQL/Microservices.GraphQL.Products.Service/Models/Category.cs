using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.GraphQL.Products.Service.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }

        [UseFiltering]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
