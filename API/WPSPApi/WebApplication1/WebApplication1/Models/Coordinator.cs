using System;
using System.Collections.Generic;

namespace WPSPApi.Models
{
    public partial class Coordinator
    {
        public int CoordinatorId { get; set; }
        public string Position { get; set; }
        public int? PatrollerId { get; set; }
        public string CoordinatorType { get; set; }
    }
}
