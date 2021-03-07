namespace OSModels
{
    public class Cart
    {
        public int ID {get; set;}
        public int CustID {get; set;}
        public int LocID {get; set;}
        public int ProdID {get; set;}
        public int Quantity {get; set;}

        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public Product Product { get; set; }


        public override string ToString()
        {
            return "imagine implementing this\ncouldn't be me";
        }
    }
}