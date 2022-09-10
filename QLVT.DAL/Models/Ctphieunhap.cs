using System;
using System.Collections.Generic;

#nullable disable

namespace QLVT.DAL.Models
{
    public partial class Ctphieunhap
    {
        public int Sopn { get; set; }
        public int Mavtu { get; set; }
        public int? Slnhap { get; set; }
        public decimal? Dgnhap { get; set; }

        public virtual Vattu MavtuNavigation { get; set; }
        public virtual Phieunhap SopnNavigation { get; set; }
    }
}
