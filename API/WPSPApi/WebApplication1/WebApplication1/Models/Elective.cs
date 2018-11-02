using System;
using System.Collections.Generic;

namespace WPSPApi.Models
{
    public partial class Elective
    {
        public int ElectiveId { get; set; }
        public string CourseType { get; set; }
        public int PatrollerId { get; set; }
        public string Year { get; set; }
    }
}
