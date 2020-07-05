using Clean.Architecture.Application.Interfaces.Application.Customer;
using Clean.Architecture.Application.Interfaces.Persistance.Customer;
using Clean.Architecture.Domain.Customer;
using System;
using System.Collections.Generic;

namespace Clean.Architecture.Application.Customer
{
    public class CustomerAccountService : ICustomerAccountService
    {
        private readonly ICustomerAccountData _customerAccountData;
        public CustomerAccountService(ICustomerAccountData customerAccountData)
        {
            _customerAccountData = customerAccountData;
        }
        public bool CheckAvailability(string Username)
        {
            try
            {
                return _customerAccountData.CheckAvailability(Username);
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public CustomerAccount GetCustomerById(long Id)
        {
            try
            {
                return _customerAccountData.GetCustomerById(Id);
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public IEnumerable<CustomerAccount> GetCustomers()
        {
            try
            {
                return _customerAccountData.GetCustomers();
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public CustomerAccount Login(string UserName, string Password)
        {
            try
            {
                return _customerAccountData.Login(UserName, Password);
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public long SaveCustomer(CustomerAccount customerAccount)
        {
            try
            {
                return _customerAccountData.SaveCustomer(customerAccount);
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }
    }
}
