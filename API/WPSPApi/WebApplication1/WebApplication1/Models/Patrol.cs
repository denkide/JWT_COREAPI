using System;
using System.Collections.Generic;

namespace WPSPApi.Models
{
    public partial class Patrol
    {
        public string PatrolKey { get; set; }
        public int? Hc { get; set; }
        public int? Ahc { get; set; }
    }
}
