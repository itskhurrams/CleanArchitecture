using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Application.Interfaces.Persistance.Defination;
using Clean.Architecture.Domain.Defination;
using System;
using System.Collections.Generic;
namespace Clean.Architecture.Application.Defination
{
    public class MeritalStatusService : IMeritalStatusService
    {
        private readonly IMeritalStatusData _meritalStatusData;
        public MeritalStatusService(IMeritalStatusData meritalStatusData)
        {
            _meritalStatusData = meritalStatusData;
        }
        public IEnumerable<MeritalStatus> GetMeritalStatuses()
        {
            try
            {
                return _meritalStatusData.GetMeritalStatuses();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
