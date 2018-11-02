using System;
using System.Collections.Generic;

namespace WPSPApi.Models
{
    public partial class PatrollerCoordinator
    {
        public int PatrollerCoordinatorId { get; set; }
        public int PatrollerId { get; set; }
        public string CoordinatorId { get; set; }
    }
}
