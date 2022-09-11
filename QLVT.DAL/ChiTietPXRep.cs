using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLVT.Common.DAL;
using QLVT.Common.Rsp;
using QLVT.DAL.Models;

namespace QLVT.DAL
{
	public class ChiTietPXRep: GenericRep<QLVTContext, Ctphieuxuat>
	{
		public ChiTietPXRep() { }
		public override Ctphieuxuat Read(int id)
		{
			var res = All.FirstOrDefault(n => n.Sopx == id);
			return res;
		}
        public SingleRsp CreateChiTietPX(Ctphieuxuat ctphieuxuat)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Ctphieuxuats.Add(ctphieuxuat);
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
        public SingleRsp UpdateChiTietPX (Ctphieuxuat ctphieuxuat)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Ctphieuxuats.Update(ctphieuxuat);
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

        public int XoaCTPhieuXuat(int id)
        {
            var m = base.All.First(i => i.Sopx == id);
            Context.Ctphieuxuats.Remove(m);
            Context.SaveChanges();
            return m.Sopx;
        }
    }
}
