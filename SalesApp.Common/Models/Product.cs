using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesApp.Common.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime PublishOn { get; set; }
    }
}
