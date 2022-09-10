using System;
using System.Collections.Generic;

#nullable disable

namespace QLVT.DAL.Models
{
    public partial class Vattu
    {
        public Vattu()
        {
            Ctdondhs = new HashSet<Ctdondh>();
            Ctphieunhaps = new HashSet<Ctphieunhap>();
            Ctphieuxuats = new HashSet<Ctphieuxuat>();
            Tonkhos = new HashSet<Tonkho>();
        }

        public int Mavtu { get; set; }
        public string Tenvtu { get; set; }
        public string Dvtinh { get; set; }
        public float? Phantram { get; set; }

        public virtual ICollection<Ctdondh> Ctdondhs { get; set; }
        public virtual ICollection<Ctphieunhap> Ctphieunhaps { get; set; }
        public virtual ICollection<Ctphieuxuat> Ctphieuxuats { get; set; }
        public virtual ICollection<Tonkho> Tonkhos { get; set; }
    }
}
