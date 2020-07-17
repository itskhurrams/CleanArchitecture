using System;

namespace Clean.Architecture.Domain.Defination {
    public class Package {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }


}
