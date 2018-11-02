using System;
using System.Collections.Generic;

namespace WPSPApi.Models
{
    public partial class Apply
    {
        public int ApplyId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Type { get; set; }
        public string Class { get; set; }
        public int PatrollerNum { get; set; }
        public string UniqueId { get; set; }
        public string CreatedDate { get; set; }
    }
}
