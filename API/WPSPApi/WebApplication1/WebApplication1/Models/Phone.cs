using System;
using System.Collections.Generic;

namespace WPSPApi.Models
{
    public partial class Phone
    {
        public int PhId { get; set; }
        public string PhoneNumber { get; set; }
        public string Type { get; set; }
        public int PatrollerId { get; set; }
    }
}
