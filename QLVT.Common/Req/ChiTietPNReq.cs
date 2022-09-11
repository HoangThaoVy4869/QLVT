using System;
using System.Collections.Generic;
using System.Text;

namespace QLVT.Common.Req
{
	public class ChiTietPNReq
	{
		public int Sopn { get; set; }
		public int Mavtu { get; set; }
		public int? Slnhap { get; set; }
		public decimal? Dgnhap { get; set; }
	}
}
