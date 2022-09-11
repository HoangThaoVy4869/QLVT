using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLVT.Common.DAL;
using QLVT.Common.Rsp;
using QLVT.DAL.Models;

namespace QLVT.DAL
{
	public class ChiTietPNRep: GenericRep<QLVTContext, Ctphieunhap>
	{
		public ChiTietPNRep() { }
		public override Ctphieunhap Read(int id)
		{
			var res = All.FirstOrDefault(n => n.Sopn == id);
			return res;
		}
        public SingleRsp CreateChiTietPN(Ctphieunhap ctphieunhap)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Ctphieunhaps.Add(ctphieunhap);
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
        public SingleRsp UpdateChiTietPN(Ctphieunhap ctphieunhap)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Ctphieunhaps.Update(ctphieunhap);
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

        public int XoaCtPhieuNhap(int id)
        {
            var m = base.All.First(i => i.Sopn == id);
            Context.Ctphieunhaps.Remove(m);
            Context.SaveChanges();
            return m.Sopn;
        }

    }
}
