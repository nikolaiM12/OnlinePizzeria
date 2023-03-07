using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Provider
    {
        [Key]
        public string? ProviderId { get; set; } 
        public string Name { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Veliche { get; set; }
        public bool IsAvailable { get; set; } 
        public double Rating { get; set; } 
        public ICollection<Order> DeliveredOrders { get; set; } 
    }
}
