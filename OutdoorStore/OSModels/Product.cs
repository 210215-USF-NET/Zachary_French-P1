using System;
using Serilog;

namespace OSModels
{
    public class Product
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string ShortName { get; set; }
        public int Price { get; set; }
        public ProductCategory Category { get; set; }
        public string Description { get; set; }

        private void ThrowNullException()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Log.Error("Null value provided to Product method.");

            throw new Exception("Null value not valid");
        }

        public override string ToString()
        {
            return String.Format("{0,-70} {1,30}\n{2,-70} {3,30}\n\n{4,-89} {5,10}\n{6,-90} {7,10}\n= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =", 
                "Product Name:", "Price:", this.Name, this.Price, "Description:", "Product ID:", this.Description, this.ShortName);
        }

        public string ToStringTabbed()
        {
            return String.Format("\t{0,-70} {1,30}\n\t{2,-70} {3,30}\n\n\t{4,-90} {5,10}\n\t{6,-90} {7,10}\n\t= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =", 
                "Product Name:", "Price:", this.Name, this.Price, "Description:", "Product ID:", this.Description, this.ShortName);
        }
    }
}