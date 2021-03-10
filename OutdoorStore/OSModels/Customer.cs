using System;
using System.Collections.Generic;
using Serilog;

namespace OSModels
{
    /// <summary>
    /// This class contains necessary properties and fields for customer info. 
    /// </summary>
    public class Customer
    {


        public string Name { get; set; }

        public string Address { get; set; }

        public int ID { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public List<Order> orderHistory { get; set; }

        private void ThrowNullException()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Log.Error("Null value provided to Product method.");

            throw new Exception("Null value not valid");
        }

        public override string ToString()
        {
            return $"Customer: {this.Name}\n\tID: {this.ID} - Home: {this.Address} - Phone {this.Phone}";
        }
    }
}