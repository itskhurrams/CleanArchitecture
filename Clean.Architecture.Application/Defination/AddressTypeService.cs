using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Application.Interfaces.Persistance.Defination;
using Clean.Architecture.Domain.Defination;
using System;
using System.Collections.Generic;
namespace Clean.Architecture.Application.Defination
{
    public class AddressTypeService : IAddressTypeService
    {
        private readonly IAddressTypeData _addressTypeData;
        public AddressTypeService(IAddressTypeData addressTypeData)
        {
            _addressTypeData = addressTypeData;
        }
        public IEnumerable<AddressType> GetAddressTypes()
        {
            try
            {
                return _addressTypeData.GetAddressTypes();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
