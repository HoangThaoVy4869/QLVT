using System;
using System.Collections.Generic;

#nullable disable

namespace QLVT.DAL.Models
{
    public partial class Ctphieuxuat
    {
        public int Sopx { get; set; }
        public int Mavtu { get; set; }
        public int? Slxuat { get; set; }
        public decimal? Dgxuat { get; set; }

        public virtual Vattu MavtuNavigation { get; set; }
        public virtual Phieuxuat SopxNavigation { get; set; }
    }
}
