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
	public class TonKhoSvc : GenericSvc<TonKhoRep, Tonkho>
	{
		private TonKhoRep tonKhoRep;
		public TonKhoSvc()
		{
			tonKhoRep = new TonKhoRep();
		}

		public override SingleRsp Read(int id)
		{
			var res = new SingleRsp();
			res.Data = _rep.Read(id);
			return res;
		}

		public SingleRsp CreateTonKho (TonKhoReq tonKhoReq)
		{
			var res = new SingleRsp();
			Tonkho t = new Tonkho();
			t.Maso = tonKhoReq.Maso;
			t.Mavtu = tonKhoReq.Mavtu;
			t.Tongsln = tonKhoReq.Tongsln;
			t.Tongslx = tonKhoReq.Tongslx;
			t.Sldau = tonKhoReq.Sldau;
			t.Slcuoi = tonKhoReq.Slcuoi;
			t.Ngaythang = tonKhoReq.Ngaythang;
			res = tonKhoRep.CreateTonKho(t);
			return res;
		}

		public override SingleRsp Update(Tonkho t)
		{
			var res = new SingleRsp();

			var p1 = t.Maso > 0 ? _rep.Read(t.Maso) : _rep.Read(t.Maso);
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

		public SingleRsp UpdateTonKho (TonKhoReq tonKhoReq)
		{
			var res = new SingleRsp();
			Tonkho t = new Tonkho();
			t.Maso = tonKhoReq.Maso;
			t.Mavtu = tonKhoReq.Mavtu;
			t.Tongsln = tonKhoReq.Tongsln;
			t.Tongslx = tonKhoReq.Tongslx;
			t.Sldau = tonKhoReq.Sldau;
			t.Slcuoi = tonKhoReq.Slcuoi;
			t.Ngaythang = tonKhoReq.Ngaythang;
			res = tonKhoRep.UpdateTonKho(t);
			return res;
		}

		public SingleRsp XoaTonKho(int id)
		{
			var res = new SingleRsp();
			try
			{
				res.Data = _rep.XoaTonKho(id);
			}
			catch (Exception ex)
			{
				res.SetError(ex.StackTrace);
			}
			return res;
		}

		public SingleRsp SearchSlTonKhoByMaVT(int maVatTu)
		{
			var res = new SingleRsp();
			var tonKho = tonKhoRep.searchSLTonKho(maVatTu);
			res.Data = tonKho;
			return res;

		}
	}
}
