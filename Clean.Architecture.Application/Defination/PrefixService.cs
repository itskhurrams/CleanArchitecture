using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Domain.Defination;
using Clean.Architecture.Domain.Interfaces.Defination;

using System;
using System.Collections.Generic;
namespace Clean.Architecture.Application.Defination {
    public class PrefixService : IPrefixService {
        private readonly IPrefixData _prefixData;
        public PrefixService(IPrefixData prefixData) {
            _prefixData = prefixData;
        }
        public IEnumerable<Prefix> GetPrefixes() {
            try {
                return _prefixData.GetPrefixes();
            }
            catch (Exception exception) {
                throw exception;
            }
        }
    }
}
