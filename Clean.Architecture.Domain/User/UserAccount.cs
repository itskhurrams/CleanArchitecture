using System;
using System.Collections.Generic;

namespace Clean.Architecture.Domain.User
{
    public class UserAccount
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string PassCode { get; set; }
        public short PrefixId { get; set; }
        public string PrefixTitle { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public short SufixId { get; set; }
        public string SufixTitle { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string CellNumber { get; set; }
        public short MaritalStatusId { get; set; }
        public string MaritalStatusTitle { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<UserAddress> UserAddressList { get; set; }
        public List<UserPackage> UserPackageList { get; set; }
        public List<UserCustomerService> UserCustomerServiceList { get; set; }
    }
}
