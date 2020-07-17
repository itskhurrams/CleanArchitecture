using Clean.Architecture.Domain.Defination;

using System.Collections.Generic;

namespace Clean.Architecture.Domain.Interfaces.Defination {
    public interface ISufixData {
        IEnumerable<Sufix> GetSufixes();
        Sufix GetSufixById(short Id);
    }
}
