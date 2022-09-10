using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLVT.Common.DAL;
using QLVT.Common.Rsp;
using QLVT.DAL.Models;

namespace QLVT.DAL
{
	public class PhieuNhapRep: GenericRep<QLVTContext, Phieunhap>
	{
		public PhieuNhapRep() { }
		public override Phieunhap Read(int id)
		{
			var res = All.FirstOrDefault(p => p.Sopn == id);
			return res;
		}

        public SingleRsp UpdatePhieuNhap(Phieunhap phieunhap)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Phieunhaps.Update(phieunhap);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
