using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WEBAPI_MultipleParameters.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public ICollection<ItemDetails> Details { get; set; }
    }

    public class ItemDetails
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }

    public class OrderItemDetailsViewModel
    {
        public Order order { get; set; }
        public ItemDetails[] itemDetails { get; set; }
    }
}