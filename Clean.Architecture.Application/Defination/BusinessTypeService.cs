using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using System;
using System.Collections.Generic;
namespace Clean.Architecture.Application.Defination
{
    public class BusinessTypeService : IBusinessTypeService
    {
        private readonly IBusinessTypeData _businessTypeData;
        public BusinessTypeService(IBusinessTypeData businessTypeData)
        {
            _businessTypeData = businessTypeData;
        }
        public IEnumerable<BusinessType> GetBusinessTypes()
        {
            try
            {
                return _businessTypeData.GetBusinessTypes();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
