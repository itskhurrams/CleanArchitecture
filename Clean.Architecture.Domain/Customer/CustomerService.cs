using System;

namespace Clean.Architecture.Domain.Customer {
    public class CustomerService {
        public long ID { get; set; }
        public long CustomerId { get; set; }
        public short BusinessTypeId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string LogoFileName { get; set; }
        public long LogoFileSize { get; set; }
        public Byte[] LogoFile { get; set; }
        public string LogoFileType { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
