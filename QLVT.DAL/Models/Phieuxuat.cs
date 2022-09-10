using System;
using System.Collections.Generic;

#nullable disable

namespace QLVT.DAL.Models
{
    public partial class Phieuxuat
    {
        public Phieuxuat()
        {
            Ctphieuxuats = new HashSet<Ctphieuxuat>();
        }

        public int Sopx { get; set; }
        public DateTime? Ngayxuat { get; set; }
        public string Tenkh { get; set; }

        public virtual ICollection<Ctphieuxuat> Ctphieuxuats { get; set; }
    }
}
