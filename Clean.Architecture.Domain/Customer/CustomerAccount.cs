using System;
using System.Collections.Generic;

namespace Clean.Architecture.Domain.Customer {
    public class CustomerAccount {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string PassCode { get; set; }
        public string CustomerName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<CustomerService> CustomerServicesList { get; set; }
    }
}
