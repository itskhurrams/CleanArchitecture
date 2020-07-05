using Clean.Architecture.Domain.Defination;
using System.Collections.Generic;

namespace Clean.Architecture.Application.Interfaces.Persistance.Defination
{
    public interface IMeritalStatusData
    {
        IEnumerable<MeritalStatus> GetMeritalStatuses();
        MeritalStatus GetMeritalStatusById(short Id);
    }
}
