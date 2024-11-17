using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public string DeliveryType { get; set; }
        public string PaymentMethod { get; set; }

        public Order(int id, int number, DateTime dateTime, decimal price, string deliveryType, string paymentMethod) {
            this.Id = id; 
            this.Number = number; 
            this.DateTime = dateTime; 
            this.Price = price; 
            this.DeliveryType = deliveryType;
            this.PaymentMethod = paymentMethod; 
        }

        public override string ToString() { 
            return $"Order [Id={this.Id}, Number={this.Number}, DateTime={this.DateTime}, Price={this.Price:C}, DeliveryType={this.DeliveryType}, PaymentMethod={this.PaymentMethod}]"; 
        }
    }
}
