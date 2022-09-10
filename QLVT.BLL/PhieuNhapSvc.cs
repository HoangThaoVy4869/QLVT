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
	public class PhieuNhapSvc : GenericSvc<PhieuNhapRep, Phieunhap>
	{
		private PhieuNhapRep phieuNhapRep;
		public PhieuNhapSvc()
		{
			phieuNhapRep = new PhieuNhapRep();
		}

		public override SingleRsp Read(int id)
		{
			var res = new SingleRsp();
			res.Data = _rep.Read(id);
			return res;
		}

		public override SingleRsp Update(Phieunhap p)
		{
			var res = new SingleRsp();

			var p1 = p.Sodh > 0 ? _rep.Read(p.Sopn) : _rep.Read(p.Sopn);
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

		public SingleRsp UpdatePhieuNhap (PhieuNhapReq phieuNhapReq)
		{
			var res = new SingleRsp();
			Phieunhap p = new Phieunhap();
			p.Sopn = phieuNhapReq.Sopn;
			p.Ngaynhap = phieuNhapReq.Ngaynhap;
			p.Sodh = phieuNhapReq.Sodh;
			res = phieuNhapRep.UpdatePhieuNhap(p);
			return res;
		}
	}
}
