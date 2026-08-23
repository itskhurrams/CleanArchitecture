using Clean.Architecture.Application.Interfaces.Application.Customer;
using Clean.Architecture.Domain.Customer;
using Clean.Architecture.Domain.Interfaces.Customer;

using System;
using System.Collections.Generic;

namespace Clean.Architecture.Application.Customer {
    public class CustomerAccountService : ICustomerAccountService {
        private readonly ICustomerAccountData _customerAccountData;
        public CustomerAccountService(ICustomerAccountData customerAccountData) {
            _customerAccountData = customerAccountData;
        }
        public bool CheckAvailability(string Username) {
            return _customerAccountData.CheckAvailability(Username);
        }

        public CustomerAccount GetCustomerById(long Id) {
            return _customerAccountData.GetCustomerById(Id);
        }

        public IEnumerable<CustomerAccount> GetCustomers() {
            return _customerAccountData.GetCustomers();
        }

        public CustomerAccount Login(string UserName, string Password) {
            return _customerAccountData.Login(UserName, Password);
        }

        public long SaveCustomer(CustomerAccount customerAccount) {
            return _customerAccountData.SaveCustomer(customerAccount);
        }
    }
}
