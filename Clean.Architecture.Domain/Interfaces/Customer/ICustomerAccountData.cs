using Clean.Architecture.Domain.Customer;

using System.Collections.Generic;

namespace Clean.Architecture.Domain.Interfaces.Customer {
    public interface ICustomerAccountData {
        IEnumerable<CustomerAccount> GetCustomers();
        CustomerAccount GetCustomerById(long Id);
        long SaveCustomer(CustomerAccount customerAccount);
        CustomerAccount Login(string UserName, string Password);
        bool CheckAvailability(string Username);
        long DeleteCustomer(long Id);
    }
}
