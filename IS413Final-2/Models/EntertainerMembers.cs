using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IS413Final_2.Models
{
    public partial class EntertainerMembers
    {
        public long? EntertainerId { get; set; }
        public long? MemberId { get; set; }
        public long? Status { get; set; }
    }
}
