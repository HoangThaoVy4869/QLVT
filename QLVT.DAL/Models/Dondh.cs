using System;
using System.Collections.Generic;

#nullable disable

namespace QLVT.DAL.Models
{
    public partial class Dondh
    {
        public Dondh()
        {
            Ctdondhs = new HashSet<Ctdondh>();
            Phieunhaps = new HashSet<Phieunhap>();
        }

        public int Sodh { get; set; }
        public DateTime? Ngaydh { get; set; }
        public int? Manhacc { get; set; }

        public virtual Nhacungcap ManhaccNavigation { get; set; }
        public virtual ICollection<Ctdondh> Ctdondhs { get; set; }
        public virtual ICollection<Phieunhap> Phieunhaps { get; set; }
    }
}
