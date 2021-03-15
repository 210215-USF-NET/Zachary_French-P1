using OSModels;

namespace OSMVC.Models
{
    public interface IMapper
    {
        CustomerIndexVM parseCustomerToVM(Customer custToBeCasted);
        Customer parseToCust(CustomerCreateVM custToBeCasted);
        CustomerCreateVM parseToCCVM(Customer custToBeCasted);
       }
}