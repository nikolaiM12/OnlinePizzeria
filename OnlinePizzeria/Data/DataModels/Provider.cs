using OnlinePizzeria.Data.DataModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePizzeria.Model
{
    public class Provider : BaseClass
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Veliche { get; set; }
        public bool IsAvailable { get; set; }
        public double Rating { get; set; }
        public List<Order> Order { get; set; }
    }
}
