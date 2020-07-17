using Clean.Architecture.Domain.Defination;

using System.Collections.Generic;

namespace Clean.Architecture.Domain.Interfaces.Defination {
    public interface IAddressTypeData {
        IEnumerable<AddressType> GetAddressTypes();
        AddressType GetAddressTypeById(short Id);
    }
}
