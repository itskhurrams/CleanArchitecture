using Clean.Architecture.Domain.Defination;

using System.Collections.Generic;

namespace Clean.Architecture.Domain.Interfaces.Defination {
    public interface IBusinessTypeData {
        IEnumerable<BusinessType> GetBusinessTypes();
        BusinessType GetBusinessTypeById(short Id);
    }
}
