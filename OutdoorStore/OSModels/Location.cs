using System.Collections.Generic;

namespace OSModels
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Inventory> Inventory { get; set; }

        public override string ToString()
        {
            return $"Location: {this.Name}\n\t ID:{this.ID} - Address: {this.Address}";
        }
    }
}