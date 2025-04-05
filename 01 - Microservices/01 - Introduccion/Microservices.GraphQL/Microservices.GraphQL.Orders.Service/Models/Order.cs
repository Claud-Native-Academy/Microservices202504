using Microservices.GraphQL.Orders.Service.GraphQL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.GraphQL.Orders.Service.Models
{
    public class Order
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; } 
        public double TotalPrice { get; set; }        
    }

}
