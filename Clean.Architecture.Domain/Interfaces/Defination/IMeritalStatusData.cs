using Clean.Architecture.Domain.Defination;

using System.Collections.Generic;

namespace Clean.Architecture.Domain.Interfaces.Defination {
    public interface IMeritalStatusData {
        IEnumerable<MeritalStatus> GetMeritalStatuses();
        MeritalStatus GetMeritalStatusById(short Id);
    }
}
