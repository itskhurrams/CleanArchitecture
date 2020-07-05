using Clean.Architecture.Domain.Defination;
using System.Collections.Generic;

namespace Clean.Architecture.Application.Interfaces.Persistance.Defination
{
    public interface IAddressTypeData
    {
        IEnumerable<AddressType> GetAddressTypes();
        AddressType GetAddressTypeById(short Id);
    }
}
