using System;
using System.Collections.Generic;
using System.Text;
using QLVT.Common.BLL;
using QLVT.Common.Req;
using QLVT.Common.Rsp;
using QLVT.DAL;
using QLVT.DAL.Models;

namespace QLVT.BLL
{
	public class NhaCungCapSvc : GenericSvc<NhaCungCapRep, Nhacungcap>
	{
		private NhaCungCapRep nhaCungCapRep;
		public NhaCungCapSvc()
		{
			nhaCungCapRep = new NhaCungCapRep();
		}

		public override SingleRsp Read(int id)
		{
			var res = new SingleRsp();
			res.Data = _rep.Read(id);
			return res;
		}

		public override SingleRsp Update(Nhacungcap n)
		{
			var res = new SingleRsp();

			var p1 = n.Manhacc > 0 ? _rep.Read(n.Manhacc) : _rep.Read(n.Manhacc);
			if (p1 == null)
			{
				res.SetError("EZ103", "No data.");
			}
			else
			{
				res = base.Update(p1);
				res.Data = p1;
			}

			return res;
		}

		public SingleRsp UpdateNhaCC (NhaCungCapReq nhaCungCapReq)
		{
			var res = new SingleRsp();
			Nhacungcap n = new Nhacungcap();
			n.Manhacc = nhaCungCapReq.Manhacc;
			n.Tennhacc = nhaCungCapReq.Tennhacc;
			n.Diachi = nhaCungCapReq.Diachi;
			n.Dienthoai = nhaCungCapReq.Dienthoai;
			res = nhaCungCapRep.UpdateNhaCC(n);
			return res;
		}
	}
}
