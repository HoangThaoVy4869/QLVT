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
	public class PhieuXuatSvc : GenericSvc<PhieuXuatRep, Phieuxuat>
	{
		private PhieuXuatRep phieuXuatRep;
		public PhieuXuatSvc()
		{
			phieuXuatRep = new PhieuXuatRep();
		}

		public override SingleRsp Read(int id)
		{
			var res = new SingleRsp();
			res.Data = _rep.Read(id);
			return res;
		}

		public override SingleRsp Update(Phieuxuat p)
		{
			var res = new SingleRsp();

			var p1 = p.Sopx > 0 ? _rep.Read(p.Sopx) : _rep.Read(p.Sopx);
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

		public SingleRsp UpdatePhieuXuat (PhieuXuatReq phieuXuatReq)
		{
			var res = new SingleRsp();
			Phieuxuat p = new Phieuxuat();
			p.Sopx = phieuXuatReq.Sopx;
			p.Ngayxuat = phieuXuatReq.Ngayxuat;
			p.Tenkh = phieuXuatReq.Tenkh;
			res = phieuXuatRep.UpdatePhieuXuat(p);
			return res;
		}
	}
}
