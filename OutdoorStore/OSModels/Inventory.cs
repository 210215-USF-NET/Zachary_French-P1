namespace OSModels
{
    public class Inventory
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int LocationID { get; set; }
        public int ProductID { get; set; }
    
        public Product Product { get; set; }
    }
}