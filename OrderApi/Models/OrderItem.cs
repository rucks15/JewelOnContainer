using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Models
    {
    public class OrderItem
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public int Units { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public OrderItem(string productName, string pictureUrl, decimal unitPrice, int units, int productId)
            {
            
            ProductName = productName;
            PictureUrl = pictureUrl;
            UnitPrice = unitPrice;
            Units = units;
            ProductId = productId;
            
            }
        public void SetPictureUrl(string pictureUrl)
            {
            if (pictureUrl != null)
                {
                PictureUrl = pictureUrl;
                }
            }

        public void AddUnits(int units)
            {
            Units += units;
            }
        }
    }
