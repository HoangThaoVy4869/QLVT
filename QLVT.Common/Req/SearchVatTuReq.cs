using System;
using System.Collections.Generic;
using System.Text;

namespace QLVT.Common.Req
{
	public class SearchVatTuReq
	{
		public string Keyword { get; set; }
		public int Page { get; set; }
		public int Size { get; set; }
	}
}
