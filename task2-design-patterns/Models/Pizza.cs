using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public double Diameter { get; set; }

        public Pizza(int id, string name, decimal price, string size, double diameter) { 
            this.Id = id; 
            this.Name = name; 
            this.Price = price; 
            this.Size = size; 
            this.Diameter = diameter; 
        }

        public override string ToString() { 
            return $"Pizza [Id={this.Id}, Name={this.Name}, Price={this.Price:C}, Size={this.Size}, Diameter={this.Diameter}]"; 
        }
    }
}
