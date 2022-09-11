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
	public class ChiTietDHSvc : GenericSvc<ChiTietDHRep, Ctdondh>
	{
		private ChiTietDHRep chiTietDHRep;
		public ChiTietDHSvc()
		{
			chiTietDHRep = new ChiTietDHRep();
		}

		public override SingleRsp Read(int id)
		{
			var res = new SingleRsp();
			res.Data = _rep.Read(id);
			return res;
		}
		public SingleRsp CreateCTDonDH (ChiTietDHReq chiTietDHReq)
		{
			var res = new SingleRsp();
			Ctdondh d = new Ctdondh();
			d.Sodh = chiTietDHReq.Sodh;
			d.Mavtu = chiTietDHReq.Mavtu;
			d.Sldat = chiTietDHReq.Sldat;
			res = chiTietDHRep.CreateCTDonDH(d);
			return res;
		}
		public override SingleRsp Update(Ctdondh d)
		{
			var res = new SingleRsp();

			var p1 = d.Sodh > 0 ? _rep.Read(d.Sodh) : _rep.Read(d.Sodh);
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
		public SingleRsp UpdateChiTietDH (ChiTietDHReq chiTietDHReq)
		{
			var res = new SingleRsp();
			Ctdondh d = new Ctdondh();
			d.Sodh = chiTietDHReq.Sodh;
			d.Mavtu = chiTietDHReq.Mavtu;
			d.Sldat = chiTietDHReq.Sldat;
			res = chiTietDHRep.UpdateChiTietDH(d);
			return res;
		}

		public SingleRsp XoaCtDonDH(int id)
		{
			var res = new SingleRsp();
			try
			{
				res.Data = _rep.XoaCtDonDH(id);
			}
			catch (Exception ex)
			{
				res.SetError(ex.StackTrace);
			}
			return res;
		}
	}
}
