using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLVT.Common.BLL;
using QLVT.Common.Req;
using QLVT.Common.Rsp;
using QLVT.DAL;
using QLVT.DAL.Models;

namespace QLVT.BLL
{
	public class VatTuSvc: GenericSvc<VatTuRep,Vattu>
	{
		private VatTuRep vatTuRep;
		public VatTuSvc() 
		{
			vatTuRep = new VatTuRep();
		}
		public override SingleRsp Read(int id)
		{
			var res = new SingleRsp();
			res.Data = _rep.Read(id);
			return res;
		}

		public override SingleRsp Update(Vattu v)
		{
			var res = new SingleRsp();

			var v1 = v.Mavtu > 0 ? _rep.Read(v.Mavtu) : _rep.Read(v.Mavtu);
			if (v1 == null)
			{
				res.SetError("EZ103", "No data.");
			}
			else
			{
				res = base.Update(v1);
				res.Data = v1;
			}

			return res;
		}


		public SingleRsp CreateVatTu(VatTuReq vatTuReq)
		{
			var res = new SingleRsp();
			Vattu vt = new Vattu();
			vt.Mavtu = vatTuReq.Mavtu;
			vt.Tenvtu = vatTuReq.Tenvtu;
			vt.Dvtinh = vatTuReq.Dvtinh;
			vt.Phantram = vatTuReq.Phantram;
			res = vatTuRep.CreateVatTu(vt);
			return res;
		}

		public SingleRsp UpdateVatTu(VatTuReq vatTuReq)
		{
			var res = new SingleRsp();
			Vattu vt = new Vattu();
			vt.Mavtu = vatTuReq.Mavtu;
			vt.Tenvtu = vatTuReq.Tenvtu;
			vt.Dvtinh = vatTuReq.Dvtinh;
			vt.Phantram = vatTuReq.Phantram;
			res = vatTuRep.UpdateVatTu(vt);
			return res;
		}


		// Tim kiem + phan trang
		public SingleRsp SearchVatTu(SearchVatTuReq searchVatTuReq)
		{
			var res = new SingleRsp();
			var vattus = vatTuRep.SearchVatTu(searchVatTuReq.Keyword);
			int vCount, totalPages, offset;
			vCount = vattus.Count;
			offset = (searchVatTuReq.Page - 1) * searchVatTuReq.Size;
			totalPages = (vCount%searchVatTuReq.Size)==0 ? vCount / searchVatTuReq.Size : 1 + (vCount / searchVatTuReq.Size);
			var v = new
			{
				Data = vattus.Skip(offset).Take(searchVatTuReq.Size).ToList(),
				Page = searchVatTuReq.Page,
				Size = searchVatTuReq.Size
			};
			res.Data = v;
			return res;
		}
	}
}
