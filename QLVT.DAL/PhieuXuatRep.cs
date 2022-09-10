using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLVT.Common.DAL;
using QLVT.Common.Rsp;
using QLVT.DAL.Models;

namespace QLVT.DAL
{
	public class PhieuXuatRep: GenericRep<QLVTContext, Phieuxuat>
	{
		public PhieuXuatRep() { }
        public override Phieuxuat Read(int id)
        {
            var res = All.FirstOrDefault(p => p.Sopx == id);
            return res;
        }

        public SingleRsp UpdatePhieuXuat(Phieuxuat phieuxuat)
        {
            var res = new SingleRsp();
            using (var context = new QLVTContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Phieuxuats.Update(phieuxuat);
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
