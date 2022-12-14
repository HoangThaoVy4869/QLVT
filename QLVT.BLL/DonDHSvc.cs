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
	public class DonDHSvc : GenericSvc<DonDHRep, Dondh>
	{
		private DonDHRep donDHRep;
		public DonDHSvc()
		{
			donDHRep = new DonDHRep();
		}

		public override SingleRsp Read(int id)
		{
			var res = new SingleRsp();
			res.Data = _rep.Read(id);
			return res;
		}

		public SingleRsp CreateDondh(DonDHReq donDHReq)
		{
			var res = new SingleRsp();
			Dondh d = new Dondh();
			d.Sodh = donDHReq.Sodh;
			d.Ngaydh = donDHReq.Ngaydh;
			d.Manhacc = donDHReq.Manhacc;
			res = donDHRep.CreateDondh(d);
			return res;
		}

		public override SingleRsp Update(Dondh d)
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

		public SingleRsp UpdateDondh (DonDHReq donDHReq)
		{
			var res = new SingleRsp();
			Dondh d = new Dondh();
			d.Sodh = donDHReq.Sodh;
			d.Ngaydh = donDHReq.Ngaydh;
			d.Manhacc = donDHReq.Manhacc;
			res = donDHRep.UpdateDondh(d);
			return res;
		}

		public SingleRsp XoaDH(int id)
		{
			var res = new SingleRsp();
			try
			{
				res.Data = _rep.XoaDonHang(id);
			}
			catch (Exception ex)
			{
				res.SetError(ex.StackTrace);
			}
			return res;
		}

		public SingleRsp SearchDonDHBySoDH (int Sopx)
		{
			var res = new SingleRsp();
			var donHangs = donDHRep.searchDonDH(Sopx);
			res.Data = donHangs;
			return res;

		}
	}
}
