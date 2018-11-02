using System;
using System.Collections.Generic;

namespace WPSPApi.Models
{
    public partial class Econtact
    {
        public int EContactId { get; set; }
        public int PatrollerId { get; set; }
        public string EName { get; set; }
        public string ERelationship { get; set; }
        public string EPhone { get; set; }
        public string EEmail { get; set; }
        public string EAddress { get; set; }
        public string ENotes { get; set; }
    }
}
