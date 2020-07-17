using Clean.Architecture.Domain.Customer;

using System.Collections.Generic;

namespace Clean.Architecture.Application.Interfaces.Application.Customer {
    public interface ICustomerAccountService {
        IEnumerable<CustomerAccount> GetCustomers();
        CustomerAccount GetCustomerById(long Id);
        long SaveCustomer(CustomerAccount customerAccount);
        CustomerAccount Login(string UserName, string Password);
        bool CheckAvailability(string Username);
    }
}
