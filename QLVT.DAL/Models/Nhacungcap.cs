using System;
using System.Collections.Generic;

#nullable disable

namespace QLVT.DAL.Models
{
    public partial class Nhacungcap
    {
        public Nhacungcap()
        {
            Dondhs = new HashSet<Dondh>();
        }

        public int Manhacc { get; set; }
        public string Tennhacc { get; set; }
        public string Diachi { get; set; }
        public string Dienthoai { get; set; }

        public virtual ICollection<Dondh> Dondhs { get; set; }
    }
}
