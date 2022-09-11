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
	public class ChiTietPNSvc : GenericSvc<ChiTietPNRep, Ctphieunhap>
	{
		private ChiTietPNRep chiTietPNRep;
		public ChiTietPNSvc()
		{
			chiTietPNRep = new ChiTietPNRep();
		}

		public override SingleRsp Read(int id)
		{
			var res = new SingleRsp();
			res.Data = _rep.Read(id);
			return res;
		}
		public SingleRsp CreateChiTietPN(ChiTietPNReq chiTietPNReq)
		{
			var res = new SingleRsp();
			Ctphieunhap d = new Ctphieunhap();
			d.Sopn = chiTietPNReq.Sopn;
			d.Mavtu = chiTietPNReq.Mavtu;
			d.Slnhap = chiTietPNReq.Slnhap;
			d.Dgnhap = chiTietPNReq.Dgnhap;
			res = chiTietPNRep.CreateChiTietPN(d);
			return res;
		}
		public override SingleRsp Update(Ctphieunhap d)
		{
			var res = new SingleRsp();

			var p1 = d.Sopn > 0 ? _rep.Read(d.Sopn) : _rep.Read(d.Sopn);
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
		public SingleRsp UpdateChiTietPN(ChiTietPNReq chiTietPNReq)
		{
			var res = new SingleRsp();
			Ctphieunhap d = new Ctphieunhap();
			d.Sopn = chiTietPNReq.Sopn;
			d.Mavtu = chiTietPNReq.Mavtu;
			d.Slnhap = chiTietPNReq.Slnhap;
			d.Dgnhap = chiTietPNReq.Dgnhap;
			res = chiTietPNRep.UpdateChiTietPN(d);
			return res;
		}

		public SingleRsp XoaCtPhieuNhap(int id)
		{
			var res = new SingleRsp();
			try
			{
				res.Data = _rep.XoaCtPhieuNhap(id);
			}
			catch (Exception ex)
			{
				res.SetError(ex.StackTrace);
			}
			return res;
		}
	}
}
