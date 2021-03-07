using System;
using System.Collections.Generic;

namespace OSModels
{
    public class Order
    {
        
        public int ID { get; set; }
        public int CustID { get; set; }
        public int LocID { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }

        public Customer Customer { get; set; }
        public Location Location { get; set; }

        public void AddToTotalPrice(Product product)
        {
            this.TotalPrice += product.Price;
        }

        public override string ToString()
        {
            return $"Order#: {ID}\nTotal Cost: {TotalPrice}";
        }
    }
}