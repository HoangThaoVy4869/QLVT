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
	public class ChiTietPXSvc : GenericSvc<ChiTietPXRep, Ctphieuxuat>
	{
		private ChiTietPXRep chiTietPXRep;
		public ChiTietPXSvc()
		{
			chiTietPXRep = new ChiTietPXRep();
		}
		public override SingleRsp Read(int id)
		{
			var res = new SingleRsp();
			res.Data = _rep.Read(id);
			return res;
		}
		public SingleRsp CreateChiTietPX(ChiTietPXReq chiTietPXReq)
		{
			var res = new SingleRsp();
			Ctphieuxuat d = new Ctphieuxuat();
			d.Sopx = chiTietPXReq.Sopx;
			d.Mavtu = chiTietPXReq.Mavtu;
			d.Slxuat = chiTietPXReq.Slxuat;
			d.Dgxuat = chiTietPXReq.Dgxuat;
			res = chiTietPXRep.CreateChiTietPX(d);
			return res;
		}
		public override SingleRsp Update(Ctphieuxuat d)
		{
			var res = new SingleRsp();

			var p1 = d.Sopx > 0 ? _rep.Read(d.Sopx) : _rep.Read(d.Sopx);
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
		public SingleRsp UpdateChiTietPX(ChiTietPXReq chiTietPXReq)
		{
			var res = new SingleRsp();
			Ctphieuxuat d = new Ctphieuxuat();
			d.Sopx = chiTietPXReq.Sopx;
			d.Mavtu = chiTietPXReq.Mavtu;
			d.Slxuat = chiTietPXReq.Slxuat;
			d.Dgxuat = chiTietPXReq.Dgxuat;
			res = chiTietPXRep.UpdateChiTietPX(d);
			return res;
		}

		public SingleRsp XoaCTPhieuXuat(int id)
		{
			var res = new SingleRsp();
			try
			{
				res.Data = _rep.XoaCTPhieuXuat(id);
			}
			catch (Exception ex)
			{
				res.SetError(ex.StackTrace);
			}
			return res;
		}

	}
}
