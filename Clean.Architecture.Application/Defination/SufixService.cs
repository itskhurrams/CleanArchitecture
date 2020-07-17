using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using System;
using System.Collections.Generic;
namespace Clean.Architecture.Application.Defination {
    public class SufixService : ISufixService {
        private readonly ISufixData _SufixData;
        public SufixService(ISufixData SufixData) {
            _SufixData = SufixData;
        }
        public IEnumerable<Sufix> GetSufixes() {
            try {
                return _SufixData.GetSufixes();
            }
            catch (Exception exception) {
                throw exception;
            }
        }
    }
}
