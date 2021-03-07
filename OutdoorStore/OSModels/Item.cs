using System;
using Serilog;

namespace OSModels
{
    public class Item
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProdID { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }

        private void ThrowNullException()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("../Logs/UILogs.json").CreateLogger();
            Log.Error("Null value provided to Product method.");

            throw new Exception("Null value not valid");
        }
    }
}