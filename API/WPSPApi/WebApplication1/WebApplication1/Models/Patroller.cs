using System;
using System.Collections.Generic;

namespace WPSPApi.Models
{
    public partial class Patroller
    {
        public int PatrollerId { get; set; }
        public int SkipatrolNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PatrolKey { get; set; }
        public string PatrolType { get; set; }
        public int? PriPhId { get; set; }
        public string EMail { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Partner { get; set; }
        public string Family { get; set; }
        public string JoinYear { get; set; }
        public string PictureLink { get; set; }
    }
}
