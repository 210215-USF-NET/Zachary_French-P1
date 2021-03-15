using OSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSMVC.Models
{
    public class Mapper : IMapper
    {
        public CustomerIndexVM parseCustomerToVM(Customer custToBeCasted)
        {
            return new CustomerIndexVM
            {
                Name = custToBeCasted.Name,
                Address = custToBeCasted.Address,
                ID = custToBeCasted.ID,
                Phone = custToBeCasted.Phone,
                Email = custToBeCasted.Email
            };
        }

        public CustomerCreateVM parseToCCVM(Customer custToBeCasted)
        {
            return new CustomerCreateVM
            {
                Name = custToBeCasted.Name,
                Address = custToBeCasted.Address,
                Phone = custToBeCasted.Phone,
                Email = custToBeCasted.Email
            };
        }

        public Customer parseToCust(CustomerCreateVM custToBeCasted)
        {
            return new Customer
            {
                Name = custToBeCasted.Name,
                Address = custToBeCasted.Address,
                Phone = custToBeCasted.Phone,
                Email = custToBeCasted.Email
            };
        }
    }
}
