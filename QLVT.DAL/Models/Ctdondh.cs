using System;
using System.Collections.Generic;

#nullable disable

namespace QLVT.DAL.Models
{
    public partial class Ctdondh
    {
        public int Sodh { get; set; }
        public int Mavtu { get; set; }
        public int? Sldat { get; set; }

        public virtual Vattu MavtuNavigation { get; set; }
        public virtual Dondh SodhNavigation { get; set; }
    }
}
