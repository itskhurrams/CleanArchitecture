using Clean.Architecture.Domain.Defination;

using System.Collections.Generic;

namespace Clean.Architecture.Application.Interfaces.Application.Defination {
    public interface IAddressTypeService {
        IEnumerable<AddressType> GetAddressTypes();
    }
}
