using Clean.Architecture.Domain.Customer;
using System.Collections.Generic;
using System.Data.Common;

namespace Clean.Architecture.Application.Interfaces.Persistance.Customer
{
    public interface ICustomerServiceData
    {
        IEnumerable<CustomerService> GetCustomerServiceByCustomerId(long CustomerId);
        long DeleteCustomerServicesByCustomerId(long CustomerId);
        void SaveCustomerServices(long CustomerId, List<CustomerService> CustomerServicesList, DbTransaction dbTrasection = null);

    }
}
