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
	}
}
