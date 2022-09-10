using System;
using System.Collections.Generic;

#nullable disable

namespace QLVT.DAL.Models
{
    public partial class Phieunhap
    {
        public Phieunhap()
        {
            Ctphieunhaps = new HashSet<Ctphieunhap>();
        }

        public int Sopn { get; set; }
        public DateTime? Ngaynhap { get; set; }
        public int? Sodh { get; set; }

        public virtual Dondh SodhNavigation { get; set; }
        public virtual ICollection<Ctphieunhap> Ctphieunhaps { get; set; }
    }
}
