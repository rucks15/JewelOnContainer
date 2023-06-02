using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelWebClient.Models
    {
    public enum OrderStatus
        {
        Preparing=1,
        Shipped=2,
        Delivered=3
        }
    public class Order
        {
        [BindNever]
        public int OrderId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [BindNever]
        public DateTime OrderDate { get; set; }
        [BindNever]
        public string BuyerId { get; set; }
        [BindNever]
        public string BuyerName { get; set;}
        public OrderStatus OrderStatus { get; set; }

        [Required]
        public string Address { get; set; }
        public string PaymentAuthCode { get; set; }

        [DisplayFormat(DataFormatString ="{0:N2}")]
        public decimal OrderTotal { get; set; }
        public List<OrderItem> OrderItems { get; } = new List<OrderItem>();
        public string StripeToken { get; set; }

        }
    }
