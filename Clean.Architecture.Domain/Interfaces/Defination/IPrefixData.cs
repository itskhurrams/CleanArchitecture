using Clean.Architecture.Domain.Defination;
using System.Collections.Generic;

namespace Clean.Architecture.Domain.Interfaces.Defination
{
    public interface IPrefixData
    {
        IEnumerable<Prefix> GetPrefixes();
        Prefix GetPrefixById(short Id);
    }
}
