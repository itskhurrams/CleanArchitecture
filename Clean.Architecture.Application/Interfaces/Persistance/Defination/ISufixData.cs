using Clean.Architecture.Domain.Defination;
using System.Collections.Generic;

namespace Clean.Architecture.Application.Interfaces.Persistance.Defination
{
    public interface ISufixData
    {
        IEnumerable<Sufix> GetSufixes();
        Sufix GetSufixById(short Id);
    }
}
