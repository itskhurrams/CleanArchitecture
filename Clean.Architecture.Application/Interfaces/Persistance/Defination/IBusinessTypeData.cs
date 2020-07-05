using Clean.Architecture.Domain.Defination;
using System.Collections.Generic;

namespace Clean.Architecture.Application.Interfaces.Persistance.Defination
{
    public interface IBusinessTypeData
    {
        IEnumerable<BusinessType> GetBusinessTypes();
        BusinessType GetBusinessTypeById(short Id);
    }
}
