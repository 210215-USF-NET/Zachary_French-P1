using OSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSMVC.Models
{
    /// <summary>
    /// Model for the List View of my Customers page
    /// </summary>
    public class CustomerIndexVM
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int ID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<Order> orderHistory { get; set; }

    }
}
